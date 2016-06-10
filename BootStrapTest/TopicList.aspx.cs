using System;
using System.Web;
using System.Web.UI.WebControls;

namespace BootStrapTest
{
    public partial class TopicList : System.Web.UI.Page
    {
        Helpers.HelpTopic helper = new Helpers.HelpTopic();
        Helpers.HelpTopicTag helpTags = new Helpers.HelpTopicTag();
        dbDataContext db = new dbDataContext();

        protected void Page_Load(object sender, EventArgs e)
        {
            int id = 0;
            if (HttpContext.Current.Request.QueryString.Get("CatID") != null)
            {
                id = Convert.ToInt32(HttpContext.Current.Request.QueryString.Get("CatID"));
            }

            Repeater rptTopics = (Repeater)Master.FindControl("ContentPlaceHolder1").FindControl("rptTopics");
            if (id != 0)
            {
                rptTopics.DataSource = helper.GetHelpTopicCategory(db, id);
                rptTopics.DataBind();
            }
            else
            {
                rptTopics.DataSource = helper.GetHelpTopics(db);
                rptTopics.DataBind();
            }
            if (rptTopics.Items.Count == 0)
            {
                Label lblWarning = (Label)Master.FindControl("ContentPlaceHolder1").FindControl("lblWarning");
                lblWarning.Text = "There are no topics for the selected category";
                lblWarning.Visible = true;
            }
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
                int topicID = Convert.ToInt32(lblID.Text);
                tbl_Help_Topic topic = helper.GetHelpTopic(db, topicID);

                Label lblUpdated = (Label)e.Item.FindControl("lblUpdated");
                lblUpdated.Text += topic.Help_Topic_Last_Updated.Value.ToShortDateString();

                Repeater rptTags = (Repeater)e.Item.FindControl("rptTags");
                rptTags.DataSource = helpTags.GetHelpTopicTagTopic(db, topicID);
                rptTags.DataBind();

                if (rptTags.Items.Count == 0)
                    rptTags.Visible = false;
            }
        }

        protected void lnkPerm_Click(object sender, EventArgs e)
        {
            LinkButton lnk = (LinkButton)sender;
            RepeaterItem item = (RepeaterItem)lnk.NamingContainer;
            Label lblID = (Label)item.FindControl("lblID");
            
            string script = "window.open('PopupTopic.aspx?id=" + lblID.Text + "','Graph','height=600,width=400,top=50,left=200');";
            ClientScript.RegisterStartupScript(this.Page.GetType(), "", script, true);
        }
    }
}