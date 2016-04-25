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

            //Validate name
            if (txtName.Text.Length <= 0 || txtName.Text.Length > 50)
            {
                valid = false;
            }

            //Check parent ID
            int parent;
            if (ddlParent.SelectedIndex == 0)
                parent = -1;
            else
                parent = Convert.ToInt32(ddlParent.SelectedValue);

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
                }
            }

            //Check radio button selection
            if (rbLoggedOut.SelectedValue == null)
            {
                valid = false;
            }

            //Add to database if valid
            int record = -1;
            if (valid)
            {
                record = helper.AddUpdateHelpCategory(db, id, txtName.Text.ToString(), order, parent, Convert.ToBoolean(rbLoggedOut.SelectedValue));
            }

            //Check if record entered, display error message if not
            if (record == -1)
                lblWarning.Text = "Could not save record";
            else
            {
                //Determine whether record added or updated from ID
                string msg = "";
                if (id == -1)
                    lblWarning.Text = "Record added";
                else
                    Response.Redirect("../HelpCategory/List.aspx?msg=Record Updated");


                //If record added, clear form to allow new record
                if (id == -1)
                {
                    txtName.Text = "";
                    txtOrder.Text = "";
                    rbLoggedOut.ClearSelection();
                    ddlParent.SelectedIndex = 0;
                }
            }
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            bool del = false, children = false;

            //Check category has no children
            List<tbl_Help_Category> child = helper.GetHelpCategoryChildren(db, id);

            if (child == null)
                del = helper.DeleteHelpCategory(db, id);
            else
            {
                //children = true;
                children = true;
            }

            if (del)
                Response.Redirect("../HelpCategory/List.aspx?msg=Record Deleted");
            else if (children == true)
                lblWarning.Text = "The record you selected (ID: " + id + ") has dependencies. Please check these before deleting.";
            else
                lblWarning.Text = "Could not delete record";
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            //Return to List.aspx on cancel
            Response.Redirect("../HelpCategory/List.aspx");
        }
    }
}