using System;
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
            if (HttpContext.Current.Request.QueryString.Get("id") != null)
                id = Convert.ToInt32(HttpContext.Current.Request.QueryString.Get("id"));
            else
                id = 5;

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

                tbl_Help_Category cat;
                if (id == -1)
                {
                    lblHead.Text = "Add Help Category";
                    cat = new tbl_Help_Category();
                }
                else
                {
                    lblHead.Text = "Edit Help Category";
                    cat = helper.GetHelpCategory(db, id);
                    txtName.Text = cat.Help_Category_Name;
                    txtOrder.Text = cat.Help_Category_Order.ToString();

                    if (cat.Help_Category_Parent_ID != null)
                    {
                        //txtParent.Text = helper.GetHelpCategory(db, Convert.ToInt32(cat.Help_Category_Parent_ID)).ToString();
                        tbl_Help_Category par = helper.GetHelpCategory(db, Convert.ToInt32(cat.Help_Category_Parent_ID));
                        ddlParent.SelectedValue = par.Help_Category_ID.ToString();
                    }
                    if (cat.Help_Category_Logged_Out_Available == true)
                        rbLoggedOut.SelectedIndex = 0;
                    else
                        rbLoggedOut.SelectedIndex = 1;
                }
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            int parent;
            if (ddlParent.SelectedIndex == 0)
                parent = -1;
            else
                parent = Convert.ToInt32(ddlParent.SelectedValue);

            int record = helper.AddUpdateHelpCategory(db, id, txtName.Text.ToString(), Convert.ToInt32(txtOrder.Text),
                parent, Convert.ToBoolean(rbLoggedOut.SelectedValue));

            if (record == -1)
                lblWarning.Text = "Could not save record";
            else
            {
                if (id == -1)
                    lblWarning.Text = "Record added";
                else
                    lblWarning.Text = "Record updated";
            }

        }
    }
}