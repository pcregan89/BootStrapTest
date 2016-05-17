using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;

namespace BootStrapTest
{
    public partial class Home : System.Web.UI.Page
    {
        Helpers.HelpTopic helper = new Helpers.HelpTopic();
        dbDataContext db = new dbDataContext();

        protected void Page_Load(object sender, EventArgs e)
        {
            Repeater rptPriority = (Repeater)Master.FindControl("ContentPlaceHolder1").FindControl("rptPriority");
            rptPriority.DataSource = helper.GetHelpTopicPriority(db);
            rptPriority.DataBind();

            Repeater rptTopics = (Repeater)Master.FindControl("ContentPlaceHolder1").FindControl("rptTopics");
            //rptTopics.DataSource = helper.GetHelpTopicCategory(db, catID);
            rptTopics.DataSource = helper.GetHelpTopics(db);
            rptTopics.DataBind();

        }

        protected void lnkPriority_Click(object sender, EventArgs e)
        {
            LinkButton lnk = (LinkButton)sender;
            RepeaterItem item = (RepeaterItem)lnk.NamingContainer;
            Label lblID = (Label)item.FindControl("lblID");
            Response.Redirect("/HelpTopic.aspx?id=" + lblID.Text);
        }

        protected void lnkShare_Click(object sender, EventArgs e)
        {
            LinkButton lnk = (LinkButton)sender;
            RepeaterItem item = (RepeaterItem)lnk.NamingContainer;
            Label lblID = (Label)item.FindControl("lblID");
            Label lblHead = (Label)item.FindControl("lblHeader");

            helper.UpdateHelpTopicShareCount(db, Convert.ToInt32(lblID.Text));
            Response.Redirect("mailto:?subject=" + lblHead.Text + " - Meat Connected");
        }

        protected void rptTopics_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.DataItem != null)
            {
                Label lblID = (Label)e.Item.FindControl("lblID");
                tbl_Help_Topic topic = helper.GetHelpTopic(db, Convert.ToInt32(lblID.Text));

                Label lblUpdated = (Label)e.Item.FindControl("lblUpdated");
                lblUpdated.Text += topic.Help_Topic_Last_Updated.Value.ToString();
            }
        }
    }
}