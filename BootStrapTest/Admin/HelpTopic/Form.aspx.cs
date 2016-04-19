using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BootStrapTest.Admin.HelpTopic
{
    public partial class Form : System.Web.UI.Page
    {
        int topicID = Convert.ToInt32(HttpContext.Current.Request.QueryString.Get("id"));
        Helpers.HelpTopic helper = new Helpers.HelpTopic();
        Helpers.HelpCategory helperCat = new Helpers.HelpCategory();
        dbDataContext db = new dbDataContext();

        protected void Page_Load(object sender, EventArgs e)
        {
            tbl_Help_Topic tht;

            //don't reload the values when the button is clicked
            if (!Page.IsPostBack)
            {
                foreach (tbl_Help_Category thc in helperCat.GetHelpCategories(db))
                {
                    helpTopicCategory.Items.Clear();
                    helpTopicCategory.Items.Add("--Select--");
                    ListItem li = new ListItem();
                    li.Text = thc.Help_Category_Name;
                    li.Value = thc.Help_Category_ID.ToString();
                    helpTopicCategory.Items.Add(li);

                }


                if (topicID > 0)
                {
                    heading.Text = "Update Help Topic";
                    tht = helper.GetHelpTopic(db, topicID);

                    helpTopicText.Text = tht.Help_Topic_Text;
                    helpTopicTitle.Text = tht.Help_Topic_Header;

                    if (tht.Help_Topic_Logged_Out_Available)
                        availableLoggedOut.Checked = true;

                    helpTopicCategory.Items.FindByValue(tht.Help_Category_ID.ToString());
                }
                else
                {
                    heading.Text = "New Help Topic";
                }
            }

        }

        protected void submitButton_Click(object sender, EventArgs e)
        {
            int category;
            string topicHeader, topicTitle;
            bool loggedOutAvailable;

            if (helpTopicCategory.SelectedIndex > 0)
            {

                category = Convert.ToInt32(helpTopicCategory.SelectedValue);
                topicHeader = helpTopicTitle.Text.Trim();
                topicTitle = helpTopicText.Text.Trim();
                loggedOutAvailable = availableLoggedOut.Checked;
            }
            else
            {
                result.Text = "Please choose a category for the help topic";
                result.CssClass = "bg-danger";
                return;
            }

            int submit = helper.AddUpdateHelpTopic(db, topicID, topicHeader, topicTitle, category, loggedOutAvailable);

            if (submit == topicID)
            {
                if (topicID > 0)
                    result.Text = "Successfully updated help topic";
                else
                    result.Text = "Successfully added new help topic";

                result.CssClass = "bg-success";
            }
            else
            {
                if (topicID > 0)
                    result.Text = "Unable to update help topic";
                else
                    result.Text = "Unable to add new help topic";

                result.CssClass = "bg-danger";

            }

        }
    }
}