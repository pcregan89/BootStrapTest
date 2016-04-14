using System;
using System.Web.UI.WebControls;

namespace BootStrapTest.Admin.HelpCategory
{
    public partial class List : System.Web.UI.Page
    {
        Helpers.HelpCategory helper = new Helpers.HelpCategory();
        dbDataContext db = new dbDataContext();

        protected void Page_Load(object sender, EventArgs e)
        {
            // Bind the repeater
            rptCategories.DataSource = helper.GetHelpCategories(db);
            rptCategories.DataBind();
        }

        protected void rptCategories_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if(e.Item.DataItem != null)
            {
                tbl_Help_Category cat = (tbl_Help_Category)e.Item.DataItem;
                if(cat.Help_Category_Parent_ID != null)
                {
                    Label lblCatParent = (Label)e.Item.FindControl("lblCatParent");
                    lblCatParent.Text = helper.GetHelpCategory(db, cat.Help_Category_Parent_ID.Value).Help_Category_Name;
                }
            }
        }
    }
}