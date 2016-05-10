using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace BootStrapTest.Admin.RelatedTopics
{
    public partial class Form : System.Web.UI.Page
    {
        protected Boolean hasRelatedTopics;
        int topicID;
        tbl_Help_Topic tht;
        tbl_Help_Category thc;
        Helpers.HelpTopic helper = new Helpers.HelpTopic();
        Helpers.HelpCategory helperCat = new Helpers.HelpCategory();
        dbDataContext db = new dbDataContext();
        Helpers.HelpTopicRelated htr = new Helpers.HelpTopicRelated();
        List<tbl_Help_Topic_Related> relatedTopics;
        protected bool invalidTopic;
        String message;

        protected void Page_Load(object sender, EventArgs e)
        {

            try
            {
                topicID = Convert.ToInt32(HttpContext.Current.Request.QueryString.Get("id"));
                tht = helper.GetHelpTopic(db, topicID);
                message = HttpContext.Current.Request.QueryString.Get("message");
            }
            catch (FormatException)
            {
                topicID = 0;
                invalidTopic = true;
            }
            catch (InvalidOperationException)
            {
                topicID = 0;
                invalidTopic = true;
            }

            if (!invalidTopic)
            {
                lblResult.Text = message;

                if (!Page.IsPostBack)
                {
                    if (topicID > 0)
                    {
                        relatedTopics = htr.GetHelpTopicRelatedTopic(db, topicID);
                        ContentPlaceHolder cont = (ContentPlaceHolder)this.Master.FindControl("ContentPlaceHolder1");
                        Panel panel = (Panel)cont.FindControl("noTopics");
                        tht = helper.GetHelpTopic(db, topicID);
                        lblHelpTopicHeader.Text = tht.Help_Topic_Header;

                        if (relatedTopics.Count == 0)
                        {
                            if (panel != null)
                                panel.Visible = true;
                        }
                        else
                        {
                            if (panel != null)
                                if (panel.Visible)
                                    panel.Visible = false;
                        }


                        if (relatedTopics.Count > 0)
                        {
                            hasRelatedTopics = true;
                            rptRelatedHelpTopics.DataSource = relatedTopics;
                            rptRelatedHelpTopics.DataBind();
                        }


                        ddlHelpTopics.Items.Clear();
                        ddlHelpTopics.Items.Add("--Select--");

                        foreach (tbl_Help_Topic item in helper.GetHelpTopics(db))
                        {

                            thc = helperCat.GetHelpCategory(db, item.Help_Category_ID);
                            tht = helper.GetHelpTopic(db, topicID);

                            ListItem li = new ListItem();
                            li.Text = item.Help_Topic_Header + "   (" + thc.Help_Category_Name + ")";
                            li.Value = item.Help_Topic_ID.ToString();

                            ListItem contains = new ListItem();

                            Boolean relatedToCurrentTopic = false;

                            foreach (tbl_Help_Topic_Related thr in relatedTopics)
                            {
                                if (thr.Help_Topic_ID_First == int.Parse(li.Value) || thr.Help_Topic_ID_Second == int.Parse(li.Value))
                                {
                                    relatedToCurrentTopic = true;
                                    break;
                                }
                            }

                            contains = ddlHelpTopics.Items.FindByValue(li.Value);

                            if (contains == null && !li.Value.Equals(topicID.ToString()) && !relatedToCurrentTopic)
                            {
                                ddlHelpTopics.Items.Add(li);
                            }
                        }
                    }

                }
            }
            else
            {
                heading.Text = "Invalid Help Topic";
            }
        }

        protected void rptRelatedHelpTopics_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {

            if (e.Item.DataItem != null)
            {

                tbl_Help_Topic_Related item = (tbl_Help_Topic_Related)e.Item.DataItem;
                Button deleteButton = (Button)e.Item.FindControl("btnDelete");

                int relatedTopicID;

                if (item.Help_Topic_ID_First == topicID)
                    relatedTopicID = item.Help_Topic_ID_Second;
                else
                    relatedTopicID = item.Help_Topic_ID_First;

                deleteButton.Attributes.Add("Value", item.Help_Topic_Related_ID.ToString());

                Label header = (Label)e.Item.FindControl("lblTopicHeader");
                Label category = (Label)e.Item.FindControl("lblTopicCategory");

                tbl_Help_Topic topic = helper.GetHelpTopic(db, relatedTopicID);
                tbl_Help_Category topicCategory = helperCat.GetHelpCategory(db, topic.Help_Category_ID);
                category.Text = topicCategory.Help_Category_Name;

                header.Text += "<a href=\"../../helptopic.aspx?id=" + relatedTopicID.ToString() + "\">" + helper.GetHelpTopic(db, relatedTopicID).Help_Topic_Header + "</a>" + "<br />";
            }
        }


        protected void btnAdd_Click(object sender, EventArgs e)
        {
            if (ddlHelpTopics.SelectedIndex > 0)
            {
                int submit = htr.AddUpdateHelpTopicRelated(db, -1, topicID, Convert.ToInt32(ddlHelpTopics.SelectedItem.Value));
                var param = HttpUtility.ParseQueryString(Request.QueryString.ToString());
                String url = Request.Url.AbsolutePath;

                param.Set("id", topicID.ToString());
                param.Set("message", "Successfully added related topic");

                Response.Redirect(url + "?" + param.ToString());

            }
            else
            {
                lblResult.Text = "Please choose an option";
            }
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            Button clicked = sender as Button;

            htr.DeleteHelpTopicRelated(db, int.Parse(clicked.Attributes["Value"]));

            var param = HttpUtility.ParseQueryString(Request.QueryString.ToString());
            String url = Request.Url.AbsolutePath;

            param.Set("id", topicID.ToString());
            param.Set("message", "Deleted related help topic");

            Response.Redirect(url + "?" + param.ToString());

        }
    }
}