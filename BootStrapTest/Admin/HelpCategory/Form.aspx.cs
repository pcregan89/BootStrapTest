using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI.WebControls;

namespace BootStrapTest.Admin.HelpCategory
{
    public partial class Form : System.Web.UI.Page
    {
        int id;
        Helpers.HelpCategory helper = new Helpers.HelpCategory();
        Helpers.HelpTopic helpTop = new Helpers.HelpTopic();
        dbDataContext db = new dbDataContext();

        protected void Page_Load(object sender, EventArgs e)
        {
            //Check if ID is being passed from the List.aspx page
            if (HttpContext.Current.Request.QueryString.Get("id") != null)
                id = Convert.ToInt32(HttpContext.Current.Request.QueryString.Get("id"));
            else
                id = -1;

            if (!IsPostBack)
            {
                //Populate parent combobox
                ddlParent.Items.Add("--None--");
                foreach (tbl_Help_Category item in helper.GetHelpCategories(db))
                {
                    ListItem list = new ListItem();
                    list.Text = item.Help_Category_Name;
                    list.Value = item.Help_Category_ID.ToString();
                    ddlParent.Items.Add(list);
                }

                lblID.Text = "Category ID: " + id;

                //Check if ID exists and is not -1
                tbl_Help_Category cat;
                if (id == -1 || helper.GetHelpCategory(db, id) == null)
                {
                    id = -1;
                    lblHead.Text = "Add Help Category";
                    cat = new tbl_Help_Category();
                    Button btnDelete = (Button)Master.FindControl("ContentPlaceHolder1").FindControl("btnDelete");
                    btnDelete.Visible = false;
                }
                else
                {
                    //Populate fields
                    lblHead.Text = "Edit Help Category";
                    cat = helper.GetHelpCategory(db, id);
                    txtName.Text = cat.Help_Category_Name;
                    txtOrder.Text = cat.Help_Category_Order.ToString();

                    //Select Parent from dropdownlist
                    if (cat.Help_Category_Parent_ID != null)
                    {
                        tbl_Help_Category par = helper.GetHelpCategory(db, Convert.ToInt32(cat.Help_Category_Parent_ID));
                        ddlParent.SelectedValue = par.Help_Category_ID.ToString();
                    }
                    //Select logged out option
                    if (cat.Help_Category_Logged_Out_Available == true)
                        rbLoggedOut.SelectedIndex = 0;
                    else
                        rbLoggedOut.SelectedIndex = 1;
                }
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            bool valid = true;
            string msg = "";

            //Validate name
            if (txtName.Text.Length <= 0 || txtName.Text.Length > 50)
            {
                valid = false;
                msg += "Name must be between 1 and 50 characters<br/>";
            }

            //Check parent ID
            int parent;
            if (ddlParent.SelectedIndex == 0)
                parent = -1;
            else
                parent = Convert.ToInt32(ddlParent.SelectedValue);

            if (parent == id && id != -1)
            {
                valid = false;
                msg += "Cannot select a category as it's own parent<br/>";
            }

            //Check order
            int order = -1;
            if (txtOrder.Text.Length != 0)
            { 
                try
                {
                    order = Convert.ToInt32(txtOrder.Text);
                }
                catch (FormatException)
                {
                    valid = false;
                    msg += "Order must be numeric<br/>";
                }
            }

            //Check radio button selection
            if (rbLoggedOut.SelectedValue == "")
            {
                valid = false;
                msg += "You must select whether a category is available when a user is logged out";
            }

            //Add to database if valid
            int record = -1;
            if (valid)
            {
                record = helper.AddUpdateHelpCategory(db, id, txtName.Text.ToString(), order, parent, Convert.ToBoolean(rbLoggedOut.SelectedValue));
            }

            //Check if record entered, display error message if not
            if (record == -1)
            {
                lblWarning.Text = msg;
                lblWarning.CssClass = "text-danger";
            }
            else
            {
                //Determine whether record was added or updated from ID and return message to List page
                if (id == -1)
                    Response.Redirect("../HelpCategory/List.aspx?msg=Record Added");
                else
                    Response.Redirect("../HelpCategory/List.aspx?msg=Record Updated");


                //If record added, clear form to allow new record
                if (id == -1)
                {
                    txtName.Text = "";
                    txtOrder.Text = "";
                    rbLoggedOut.ClearSelection();

                    ddlParent.Items.Clear();
                    ddlParent.Items.Add("--None--");
                    foreach (tbl_Help_Category item in helper.GetHelpCategories(db))
                    {
                        ListItem list = new ListItem();
                        list.Text = item.Help_Category_Name;
                        list.Value = item.Help_Category_ID.ToString();
                        ddlParent.Items.Add(list);
                    }
                    ddlParent.SelectedIndex = 0;
                }
            }
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            bool del = false, children = false;

            //Check category has no children
            List<tbl_Help_Category> child = helper.GetHelpCategoryChildren(db, id);
            List<tbl_Help_Topic> topics = helpTop.GetHelpTopicCategory(db, id);

            if (child.Count == 0 && topics.Count == 0)
                helper.DeleteHelpCategory(db, id);
            else
                children = true;

            if (del)
                Response.Redirect("../HelpCategory/List.aspx?msg=Record Deleted");
            else if (children == true)
            {
                //Display error message if record has dependencies
                lblWarning.Text = "This record (ID: " + id + ") has dependencies. Please check these before deleting.";
                lblWarning.CssClass = "text-danger";
            }
            else
            {
                lblWarning.Text = "Could not delete record";
                lblWarning.CssClass = "text-danger";
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            //Return to List.aspx on cancel
            Response.Redirect("../HelpCategory/List.aspx");
        }
    }
}