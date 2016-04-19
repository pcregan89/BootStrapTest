using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BootStrapTest.Admin.HelpCategory
{
    public partial class List : System.Web.UI.Page
    {
        Helpers.HelpCategory helper = new Helpers.HelpCategory();
        dbDataContext db = new dbDataContext();

        protected void Page_Load(object sender, EventArgs e)
        {
            Label lblWarning = (Label)Master.FindControl("ContentPlaceHolder1").FindControl("lblWarning");
            if (HttpContext.Current.Request.QueryString.Get("msg") != null)
                lblWarning.Text = HttpContext.Current.Request.QueryString.Get("msg").ToString();
            else
                lblWarning.Text = "";

            // Bind the repeater
            Repeater rptCategories = (Repeater)Master.FindControl("ContentPlaceHolder1").FindControl("rptCategories");
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

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            int no = 0;
            Repeater rptCategories = (Repeater)Master.FindControl("ContentPlaceHolder1").FindControl("rptCategories");

            foreach (RepeaterItem item in rptCategories.Items)
            {
                CheckBox del = (CheckBox)item.FindControl("ckDelete");

                if (del.Checked == true)
                {
                    tbl_Help_Category cat = (tbl_Help_Category)rptCategories.Items[no].DataItem;
                    helper.DeleteHelpCategory(db, cat.Help_Category_ID);
                }
                no++;
            }

            Label lblWarning = (Label)Master.FindControl("ContentPlaceHolder1").FindControl("lblWarning");
            lblWarning.Text = "Item deleted";
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            Response.Redirect("../../Admin/HelpCategory/Form.aspx?id=-1");
        }
    }
}