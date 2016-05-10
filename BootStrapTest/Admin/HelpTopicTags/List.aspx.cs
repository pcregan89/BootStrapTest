using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BootStrapTest.Admin.HelpTopicTags
{
    public partial class List : System.Web.UI.Page
    {
        Helpers.HelpTopic helper = new Helpers.HelpTopic();
        Helpers.HelpCategory helperCat = new Helpers.HelpCategory();
        Helpers.HelpTopicTag helperTag = new Helpers.HelpTopicTag();
        dbDataContext db = new dbDataContext();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Repeater rptHelpTopic = (Repeater)Master.FindControl("ContentPlaceHolder1").FindControl("rptHelpTopic");
                rptHelpTopic.DataSource = helper.GetHelpTopics(db);
                rptHelpTopic.DataBind();
            }
        }

        protected void rptHelpTopic_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.DataItem != null)
            {
                tbl_Help_Topic cat = (tbl_Help_Topic)e.Item.DataItem;
                
                Label lblTags = (Label)e.Item.FindControl("lblTags");
                List<tbl_Help_Topic_Tag> items = helperTag.GetHelpTopicTagTopic(db, cat.Help_Topic_ID);

                string tags = "";
                if (items.Count == 0)
                {
                    tags = "No tags";
                }
                else
                {
                    foreach (tbl_Help_Topic_Tag tag in items)
                    {
                        tags += tag.Help_Topic_Tag_Text + ", ";
                    }
                }

                if (tags.Length > 100)
                    tags = tags.Substring(0, 97) + "...";

                lblTags.Text = tags;
            }
        }
    }
}