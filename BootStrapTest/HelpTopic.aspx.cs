using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BootStrapTest
{
    public partial class HelpTopic : System.Web.UI.Page
    {
        int topicID;
        tbl_Help_Topic tht;
        tbl_Help_Topic_Tag thtt;
        Helpers.HelpTopic helper = new Helpers.HelpTopic();
        Helpers.HelpCategory helperCat = new Helpers.HelpCategory();
        Helpers.HelpTopicTag helperTag = new Helpers.HelpTopicTag();
        dbDataContext db = new dbDataContext();
        protected Boolean invalidHelpTopic;
        protected Boolean hasRelatedTopics;
        protected Boolean hasTags;
        String message;

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                topicID = Convert.ToInt32(HttpContext.Current.Request.QueryString.Get("id"));
                message = HttpContext.Current.Request.QueryString.Get("message");

                if (topicID == 0)
                    invalidHelpTopic = true;
            }
            catch (FormatException)
            {
                topicID = 0;
                helpTopicTitle.Text = "Invalid help topic";
                helpTopicText.Text = "There is no help topic with this ID.";
                invalidHelpTopic = true;
            }

            result.Text = message;

            if (!Page.IsPostBack)
            {
                if (topicID > 0)
                {
                    try
                    {
                        tht = helper.GetHelpTopic(db, topicID);
                        List<tbl_Help_Topic_Tag> tags = helperTag.GetHelpTopicTagTopic(db, topicID);
                        tbl_Help_Category thc = helperCat.GetHelpCategory(db, tht.Help_Category_ID);

                        helpTopicText.Text = tht.Help_Topic_Text;
                        helpTopicTitle.Text = tht.Help_Topic_Header;
                        helpTopicCategory.Text = "Category: " + "<strong>" + thc.Help_Category_Name + "</strong>";
                        lblLastUpdated.Text = "Last Updated: " + tht.Help_Topic_Last_Updated.Value.ToShortDateString();

                        if (tags.Count != 0)
                        {
                            hasTags = true;
                            lblTags.Text = "<strong>Tags:</strong>";

                            foreach (tbl_Help_Topic_Tag tag in tags)
                            {
                                lblTags.Text += "<a href=\"Search.aspx?keyword=" + tag.Help_Topic_Tag_Text + "\">" + tag.Help_Topic_Tag_Text + "</a>;";
                                
                            }
                            
                        }

                        helper.UpdateHelpTopicViewCount(db, topicID);
                        Helpers.HelpTopicRelated htr = new Helpers.HelpTopicRelated();
                        List<tbl_Help_Topic_Related> relatedTopics = htr.GetHelpTopicRelatedTopic(db, topicID);

                        if (relatedTopics.Count > 0)
                        {
                            hasRelatedTopics = true;
                            rptRelatedHelpTopics.DataSource = relatedTopics;
                            rptRelatedHelpTopics.DataBind();
                            
                        }


                                            
                    }
                    catch(InvalidOperationException)
                    {
                        helpTopicTitle.Text = "Invalid help topic";
                        helpTopicText.Text = "There is no help topic with this ID.";
                        invalidHelpTopic = true;
                    }
                }
                else
                {
                    helpTopicTitle.Text = "Invalid help topic";
                    helpTopicText.Text = "There is no help topic with this ID.";
                    invalidHelpTopic = true;
                }
            }

            Title = helpTopicTitle.Text + " - Meat Connected";
        }

        protected void btnLike_Click(object sender, EventArgs e)
        {
            var param = HttpUtility.ParseQueryString(Request.QueryString.ToString());
            String url = Request.Url.AbsolutePath;

            param.Set("id", topicID.ToString());

            if (HttpContext.Current.Session["clickedButton"] == null)
            {
                bool updated = helper.UpdateHelpTopicLikeCount(db, topicID);

                if (updated)
                {
                    param.Set("message", "Thank you for your feedback");
                    HttpContext.Current.Session["clickedButton"] = true;
                }
            }
            else
            {
                param.Set("message", "You have already given feedback for this topic");
            }

            Response.Redirect(url + "?" + param.ToString());

        }

        protected void btnDislike_Click(object sender, EventArgs e)
        {
            var param = HttpUtility.ParseQueryString(Request.QueryString.ToString());
            String url = Request.Url.AbsolutePath;

            param.Set("id", topicID.ToString());

            if (HttpContext.Current.Session["clickedButton"] == null)
            {
                bool updated = helper.UpdateHelpTopicDislikeCount(db, topicID);

                if (updated)
                {
                    param.Set("message","Thank you for your feedback");
                    HttpContext.Current.Session["clickedButton"] = true;
                }
            }
            else
            {
                param.Set("message", "You have already given feedback for this topic");
            }

            Response.Redirect(url + "?" + param.ToString());
        }

        protected void rptRelatedHelpTopics_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.DataItem != null)
            {
                tbl_Help_Topic_Related cat = (tbl_Help_Topic_Related)e.Item.DataItem;
                int relatedTopicID;

                if (cat.Help_Topic_ID_First == topicID)
                    relatedTopicID = cat.Help_Topic_ID_Second;
                else
                    relatedTopicID = cat.Help_Topic_ID_First;
                

                tbl_Help_Topic item = helper.GetHelpTopic(db, relatedTopicID);

                Label related = (Label)e.Item.FindControl("relatedTopics");
                related.Text = "<a href=\"helptopic.aspx?id="+relatedTopicID.ToString()+"\">" + item.Help_Topic_Header + "</a>";
            }
        }

        protected void btnShare_Click(object sender, EventArgs e)
        {
            helper.UpdateHelpTopicShareCount(db, topicID);
            Response.Redirect("mailto:?subject=" + helpTopicTitle.Text + " - Meat Connected" + "&body=" + helpTopicText.Text);  
        }

    }
}