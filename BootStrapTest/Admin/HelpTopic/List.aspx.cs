using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BootStrapTest.Admin.HelpTopic
{
    public partial class List : System.Web.UI.Page
    {
        Helpers.HelpTopic helper = new Helpers.HelpTopic();
        Helpers.HelpCategory helperCat = new Helpers.HelpCategory();
        dbDataContext db = new dbDataContext();
        List<int> deleteItems;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                rptHelpTopic.DataSource = helper.GetHelpTopics(db);
                rptHelpTopic.DataBind();

                ddlCategory.Items.Add("--Select--");
                foreach (tbl_Help_Category cat in helperCat.GetHelpCategories(db))
                {
                    ListItem li = new ListItem();
                    li.Text = cat.Help_Category_Name;
                    li.Value = cat.Help_Category_ID.ToString();

                    ddlCategory.Items.Add(li);
                }
            }
            else
            {
                //drop down list should be the only thing that causes a posback
                if (ddlCategory.SelectedIndex > 0)
                {
                    rptHelpTopic.DataSource = helper.GetHelpTopicCategory(db, Convert.ToInt32(ddlCategory.SelectedValue));
                    rptHelpTopic.DataBind();
                }
                else
                {
                    rptHelpTopic.DataSource = helper.GetHelpTopics(db);
                    rptHelpTopic.DataBind();
                }

                if (HttpContext.Current.Session["deleteItems"] != null)
                    deleteItems = (List<int>)HttpContext.Current.Session["deleteItems"];
                else
                    deleteItems = new List<int>();

                Title = "List of Help Topics";
            }
        }

        protected void rptHelpTopic_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {


            if (e.Item.DataItem != null)
            {
                tbl_Help_Topic cat = (tbl_Help_Topic)e.Item.DataItem;
                CheckBox checkbox = e.Item.FindControl("selectedRow") as CheckBox;

                Label lblCatParent = (Label)e.Item.FindControl("lblCatParent");
                lblCatParent.Text = helperCat.GetHelpCategory(db, cat.Help_Category_ID).Help_Category_Name;

                checkbox.InputAttributes.Add("Value", cat.Help_Topic_ID.ToString());
                checkbox.CheckedChanged += new EventHandler(selected_CheckedChanged);

                Label priority = (Label)e.Item.FindControl("lblPriority");
                if (!cat.Help_Topic_Priority.HasValue)
                {
                    priority.Text = "None";
                }
            }
        }

        protected void deleteButton_Click(object sender, EventArgs e)
        {
            bool? deleted = null;
            int deletedCount = deleteItems.Count;

            foreach(int item in deleteItems)
            {
                deleted = helper.DeleteHelpTopic(db, item);
            }

            HttpContext.Current.Session["deleteItems"] = null;
            Server.TransferRequest(Request.Url.AbsolutePath, false);
        }

        protected void selected_CheckedChanged(object sender, EventArgs e)
        {
                CheckBox item = sender as CheckBox;
                int topicID = Convert.ToInt32(item.InputAttributes["Value"].ToString());

                if (item.Checked)
                {
                    
                    if (!deleteItems.Contains(topicID))
                        deleteItems.Add(topicID);
                }
                else
                {
                    if (deleteItems.Contains(topicID))
                        deleteItems.Remove(topicID);
                }

                HttpContext.Current.Session["deleteItems"] = deleteItems;

        }
    }
}