using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BootStrapTest
{
    public partial class PopupTopic : System.Web.UI.Page
    {
        Helpers.HelpTopic helper = new Helpers.HelpTopic();
        Helpers.HelpTopicRelated helpRel = new Helpers.HelpTopicRelated();
        dbDataContext db = new dbDataContext();
        int topicID = 0;
        string message = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                topicID = Convert.ToInt32(HttpContext.Current.Request.QueryString.Get("id"));
                message = HttpContext.Current.Request.QueryString.Get("message");

                if (topicID != 0)
                {
                    tbl_Help_Topic topic = helper.GetHelpTopic(db, topicID);
                    List<tbl_Help_Topic_Related> relate = helpRel.GetHelpTopicRelatedTopic(db, topicID);

                    lblHeader.Text = topic.Help_Topic_Header;
                    lblText.Text = topic.Help_Topic_Text;
                    lblUpdated.Text = topic.Help_Topic_Last_Updated.ToString();

                    rptRelated.DataSource = relate;
                    rptRelated.DataBind();

                    helper.UpdateHelpTopicViewCount(db, topicID);
                }

                if (message != "")
                    lblMessage.Text = message;
            }
            catch (FormatException)
            {
            }
        }

        protected void lnkRel_Click(object sender, EventArgs e)
        {
            LinkButton lnkRel = (LinkButton)sender;
            RepeaterItem rpt = (RepeaterItem)lnkRel.NamingContainer;
            Label lblID = (Label)rpt.FindControl("lblRelID");

            string script = "window.open('PopupTopic.aspx?id=" + lblID.Text + "','Graph','height=600,width=400,top=50,left=200');";
            ClientScript.RegisterStartupScript(this.Page.GetType(), "", script, true);
        }

        protected void rptRelated_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.DataItem != null)
            {
                tbl_Help_Topic_Related cat = (tbl_Help_Topic_Related)e.Item.DataItem;
                int relatedTopicID;

                if (cat.Help_Topic_ID_First == topicID)
                    relatedTopicID = cat.Help_Topic_ID_Second;
                else
                    relatedTopicID = cat.Help_Topic_ID_First;


                tbl_Help_Topic related = helper.GetHelpTopic(db, relatedTopicID);

                LinkButton lnkRel = (LinkButton)e.Item.FindControl("lnkRel");
                lnkRel.Text = related.Help_Topic_Header;
                Label lblRelID = (Label)e.Item.FindControl("lblRelID");
                lblRelID.Text = related.Help_Topic_ID.ToString();
            }
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

        protected void btnShare_Click(object sender, EventArgs e)
        {
            tbl_Help_Topic topic = new tbl_Help_Topic();
            Helpers.HelpTopic helper = new Helpers.HelpTopic();
            topic = helper.GetHelpTopic(db, topicID);

            helper.UpdateHelpTopicShareCount(db, topicID);
            Response.Redirect("mailto:?subject=" + topic.Help_Topic_Header + " - Meat Connected");
        }
    }
}