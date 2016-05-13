using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BootStrapTest.Admin.HelpTopicTags
{
    public partial class Form : System.Web.UI.Page
    {
        int id;
        Helpers.HelpTopic helperTopic = new Helpers.HelpTopic();
        Helpers.HelpTopicTag helpTag = new Helpers.HelpTopicTag();
        dbDataContext db = new dbDataContext();

        protected void Page_Load(object sender, EventArgs e)
        {
            //Check if ID is being passed from the List.aspx page
            if (HttpContext.Current.Request.QueryString.Get("id") != null)
                id = Convert.ToInt32(HttpContext.Current.Request.QueryString.Get("id"));
            else
                id = -1;

            tbl_Help_Topic topic = helperTopic.GetHelpTopic(db, id);
            Label lblTopic = (Label)Master.FindControl("ContentPlaceHolder1").FindControl("lblTopic");
            lblTopic.Text = "Editing tags for topic: " + topic.Help_Topic_Header;

            if (!IsPostBack)
            {
                Repeater rptTags = (Repeater)Master.FindControl("ContentPlaceHolder1").FindControl("rptTags");
                rptTags.DataSource = helpTag.GetHelpTopicTagTopic(db, id);
                rptTags.DataBind();
            }

            //Get unique tag text values
            //List<tbl_Help_Topic_Tag> autocomplete = helpTag.GetDistinctHelpTopics(db);
            //string[] tags = new string[autocomplete.Count];
            //int count = 0;
            //while (count < autocomplete.Count)
            //{
            //    tags[count] = autocomplete[count].Help_Topic_Tag_Text;
            //    count++;
            //}
        }

        protected void btnAddTag_Click(object sender, EventArgs e)
        {
            TextBox txtTags = (TextBox)Master.FindControl("ContentPlaceHolder1").FindControl("txtTags");

            if (txtTags.Text != "")
            {
                try
                {
                    helpTag.AddUpdateHelpTopicTag(db, 0, id, txtTags.Text);

                    //Rebind repeater
                    rptTags.DataSource = helpTag.GetHelpTopicTagTopic(db, id);
                    rptTags.DataBind();
                    txtTags.Text = "";
                    lblWarning.Text = "Tag added";
                    lblWarning.CssClass = "text-success";
                }
                catch (System.Data.SqlClient.SqlException)
                {
                    lblWarning.Text = "Tag already assigned to this article.";
                    lblWarning.CssClass = "text-danger";
                }
            }
            else
            {
                lblWarning.Text = "Please enter a tag to add.";
                lblWarning.CssClass = "text-danger";
            }
        }

        protected void btnRowDelete_Click(object sender, EventArgs e)
        {
            Label lblWarning = (Label)Master.FindControl("ContentPlaceholder1").FindControl("lblWarning");
            bool del = false;
            //Get button that fired the command
            LinkButton btn = (LinkButton)sender;

            //Get repeater item holding the button
            RepeaterItem item = (RepeaterItem)btn.NamingContainer;

            //Get ID label for selected repeater item
            Label lblID = (Label)item.FindControl("lblID");

            //Get tag ID from label
            int tagID = Convert.ToInt32(lblID.Text);
            
            del = helpTag.DeleteHelpTopicTag(db, tagID);

            if (del)
            {
                lblWarning.Text = "Record deleted";
                lblWarning.CssClass = "text-success";
                lblWarning.Visible = true;

                //Refresh Repeater data source
                rptTags.DataSource = helpTag.GetHelpTopicTagTopic(db, id);
                rptTags.DataBind();
            }
            else
            {
                lblWarning.Text = "Could not delete record";
                lblWarning.CssClass = "text-danger";
                lblWarning.Visible = true;
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            //Return to List.aspx
            Response.Redirect("../HelpTopicTags/List.aspx");
        }
        
        //Compare tags in list to keyword
        public static string [] GetAutoComplete(string keyword)
        {
            //Get unique tags to populate autocomplete
            Helpers.HelpTopicTag helpTag = new Helpers.HelpTopicTag();
            dbDataContext db = new dbDataContext();
            List<tbl_Help_Topic_Tag> autocomplete = helpTag.GetDistinctHelpTopics(db);
            string[] tags = new string[autocomplete.Count];
            int count = 0;
            while (count < autocomplete.Count)
            {
                if (autocomplete[count].Help_Topic_Tag_Text.Contains(keyword))
                    tags[count] = autocomplete[count].Help_Topic_Tag_Text;
                count++;
            }

            return tags;
        }
    }
}