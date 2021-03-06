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
        List<int> deleteItems = new List<int>();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                rptHelpTopic.DataSource = helper.GetHelpTopics(db);
                rptHelpTopic.DataBind();

                ddlCategory.Items.Add("--Select--");
                foreach (tbl_Help_Category thc in helperCat.GetHelpCategories(db))
                {

                    ListItem li = new ListItem();
                    tbl_Help_Category cat;
                    Helpers.HelpCategory parentCatHelper = new Helpers.HelpCategory();
                    int foundParent, childCount = 0;
                    foundParent = ddlCategory.Items.IndexOf(ddlCategory.Items.FindByValue(thc.Help_Category_Parent_ID.ToString()));


                    if (thc.Help_Category_Parent_ID != null)
                    {
                        childCount++;
                        cat = parentCatHelper.GetHelpCategory(db, Convert.ToInt32(thc.Help_Category_Parent_ID));

                        for (int x; ;)
                        {
                            if (cat.Help_Category_Parent_ID != null)
                            {
                                childCount++;
                                cat = parentCatHelper.GetHelpCategory(db, Convert.ToInt32(cat.Help_Category_Parent_ID));
                            }
                            else
                                break;
                        }

                    }

                    li.Text = "";
                    li.Value = thc.Help_Category_ID.ToString();

                    if (foundParent > -1)
                    {
                        for (int x = 0; x < childCount; x++)
                        {
                            li.Text += HttpUtility.HtmlDecode("&nbsp;&nbsp;");
                        }

                        li.Text += "--" + thc.Help_Category_Name;
                        ddlCategory.Items.Insert(foundParent + 1, li);

                    }
                    else
                    {
                        li.Text = thc.Help_Category_Name;
                        ddlCategory.Items.Add(li);
                    }

                }
            }
            else
            {

                //drop down list should be the only thing that causes a posback

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

            foreach (RepeaterItem item in rptHelpTopic.Items)
            {
                CheckBox del = (CheckBox)item.FindControl("selectedRow");

                if (del.Checked)
                {
                    int topicID = Convert.ToInt32(del.InputAttributes["Value"].ToString());

                    if (!deleteItems.Contains(topicID))
                        deleteItems.Add(topicID);
                }
            }

                foreach (int item in deleteItems)
            {
                deleted = helper.DeleteHelpTopic(db, item);
            }

            deleteItems = null;
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

        protected void btnRefresh_Click(object sender, EventArgs e)
        {
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
        }
    }
}