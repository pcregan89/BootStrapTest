using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BootStrapTest.Admin.HelpCategory
{
    public partial class Form : System.Web.UI.Page
    {
        Helpers.HelpCategory helper = new Helpers.HelpCategory();
        dbDataContext db = new dbDataContext();

        protected void Page_Load(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(HttpContext.Current.Request.QueryString.Get("id"));

            if (id == -1)
                lblHead.Text = "Add Help Category";
            else
                lblHead.Text = "Edit Help Category";

            tbl_Help_Category cat = helper.GetHelpCategory(db, id);
            lblID.Text += cat.Help_Category_ID.ToString();
            txtName.Text = cat.Help_Category_Name;

        }
    }
}