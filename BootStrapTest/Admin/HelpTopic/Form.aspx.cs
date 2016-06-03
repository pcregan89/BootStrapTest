using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BootStrapTest.Admin.HelpTopic
{
    public partial class Form : System.Web.UI.Page
    {
        int topicID;
        Helpers.HelpTopic helper = new Helpers.HelpTopic();
        Helpers.HelpCategory helperCat = new Helpers.HelpCategory();
        dbDataContext db = new dbDataContext();
        List<int> helpPrioritiesUsed = new List<int>();
        tbl_Help_Topic tht;
        string message;

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                topicID = Convert.ToInt32(HttpContext.Current.Request.QueryString.Get("id"));
                message = HttpContext.Current.Request.QueryString.Get("message");
            }
            catch (FormatException)
            {
                topicID = 0;
            }

            if (!String.IsNullOrEmpty(message))
                result.Text = message;

            //don't reload the values when the button is clicked
            if (!Page.IsPostBack)
            {
                helpTopicCategory.Items.Clear();
                helpTopicCategory.Items.Add("--Select--");

                ddlPriority.Items.Clear();
                ddlPriority.Items.Add("--None--");

                foreach (tbl_Help_Topic item in helper.GetHelpTopics(db))
                {
                    if (item.Help_Topic_Priority != 0)
                    {
                        helpPrioritiesUsed.Add(Convert.ToInt32(item.Help_Topic_Priority));
                    }
                }

             

                    foreach (tbl_Help_Category thc in helperCat.GetHelpCategories(db))
                    {

                        ListItem li = new ListItem();
                        li.Text = thc.Help_Category_Name;
                        li.Value = thc.Help_Category_ID.ToString();
                        helpTopicCategory.Items.Add(li);

                    }


                if (topicID > 0)
                {
                    try
                    {
                        heading.Text = "Update Help Topic";
                        tht = helper.GetHelpTopic(db, topicID);

                        helpTopicText.Text = tht.Help_Topic_Text;
                        helpTopicTitle.Text = tht.Help_Topic_Header;

                        if (tht.Help_Topic_Logged_Out_Available)
                            availableLoggedOut.Checked = true;

                        helpTopicCategory.Items.FindByValue(tht.Help_Category_ID.ToString()).Selected = true;

                        if (tht.Help_Topic_Priority != null)
                        { 
                            ListItem liCurrent = new ListItem();
                            liCurrent.Text = tht.Help_Topic_Priority.ToString();
                            liCurrent.Value = tht.Help_Topic_Priority.ToString();

                            ddlPriority.Items.Add(liCurrent);
                            ddlPriority.Items.FindByText(liCurrent.Text).Selected = true;
                        }
                        
                    }
                    catch(InvalidOperationException)
                    {
                        heading.Text = "Invalid help topic";
                        result.Text = "Invalid help topic";
                        result.CssClass = "bg-danger";
                        submitButton.Visible = false;
                    }
                    
                   
                    
                }
                else
                {
                    heading.Text = "New Help Topic";
                }

                Title = heading.Text;

                for (int x = 1; x <= 5; x++)
                {
                    if (!helpPrioritiesUsed.Contains(x))
                    {
                        ListItem lip = new ListItem();
                        lip.Text = x.ToString();
                        lip.Value = x.ToString();
                        ddlPriority.Items.Add(lip);
                    }
                }
            }

        }

        protected void submitButton_Click(object sender, EventArgs e)
        
        {
            int category;
            string topicHeader, topicTitle = "";
            bool loggedOutAvailable;
            int? topicPriority;

            if (helpTopicCategory.SelectedIndex > 0)
            {

                category = Convert.ToInt32(helpTopicCategory.SelectedValue);
                topicHeader = helpTopicTitle.Text.Trim();

                StringBuilder sb = new StringBuilder(
    HttpUtility.HtmlEncode(helpTopicText.Text));

                // whitelist of html to allow
                sb.Replace("&lt;strong&gt;", "<strong>");
                sb.Replace("&lt;/strong&gt;", "</strong>");
                sb.Replace("&lt;em&gt;", "<em>");
                sb.Replace("&lt;/em&gt;", "</em>");
                sb.Replace("&lt;p&gt;", "<p>");
                sb.Replace("&quot;&gt;", "\">");
                sb.Replace("&lt;/p&gt;", "</p>");
                sb.Replace("&lt;br&gt;", "<br>");
                sb.Replace("&lt;del&gt;", "<del>");
                sb.Replace("&lt;/del&gt;", "</del>");
                sb.Replace("&lt;sup&gt;", "<sup>");
                sb.Replace("&lt;/sup&gt;", "</sup>");
                sb.Replace("&lt;sub&gt;", "<sub>");
                sb.Replace("&lt;/sub&gt;", "</sub>");
                sb.Replace("&lt;a", "<a");
                sb.Replace("&lt;/a&gt;", "</a>");
                sb.Replace("&lt;img", "<img");
                
                sb.Replace("&lt;li&gt;", "<li>");
                sb.Replace("&lt;/li&gt;", "</li>");
                sb.Replace("&lt;ul&gt;", "<ul>");
                sb.Replace("&lt;/ul&gt;", "</ul>");
                sb.Replace("&lt;ol&gt;", "<ol>");
                sb.Replace("&lt;/ol&gt;", "</ol>");
                sb.Replace("&lt;span", "<span");
                sb.Replace("&lt;/span&gt;", "</span>");
                sb.Replace("&amp;nbsp;", " ");
                sb.Replace("&quot;", "\"");
                sb.Replace("&gt;", ">");

                topicTitle = sb.ToString();
                

                loggedOutAvailable = availableLoggedOut.Checked;

                if (ddlPriority.SelectedIndex > 0)
                {
                    topicPriority = Convert.ToInt32(ddlPriority.SelectedValue);
                }
                else
                {
                    topicPriority = 0;
                }
            }
            else
            {
                result.Text = "Please choose a category for the help topic";
                result.CssClass = "bg-danger";
                return;
            }

            int submit = helper.AddUpdateHelpTopic(db, topicID, topicHeader, topicTitle, category, loggedOutAvailable, topicPriority);

            if (submit == topicID)
            {
                var param = HttpUtility.ParseQueryString(Request.QueryString.ToString());
                String url = Request.Url.AbsolutePath;

                param.Set("id", topicID.ToString());

                if (topicID > 0)
                {            
                    param.Set("message", "Successfully updated help topic");
                    Response.Redirect(url + "?" + param.ToString());
                }
                else
                {
                    param.Set("message", "Successfully added new help topic");
                    Response.Redirect(url + "?" + param.ToString());
                }
            }
            else
            {
                if (topicID > 0)
                    result.Text = "Unable to update help topic";
                else
                    result.Text = "Unable to add new help topic";

                result.CssClass = "bg-danger";

            }

            if (topicID > 0)
            {
                tht = helper.GetHelpTopic(db, topicID);
                helpTopicText.Text = tht.Help_Topic_Text;
            }
        }
    }
}