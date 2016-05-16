using System;
using System.Web.UI.WebControls;

namespace BootStrapTest
{
    public partial class MainMaster : System.Web.UI.MasterPage
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            TextBox txtSearch = (TextBox)FindControl("txtSearch");
            Response.Redirect("/Search.aspx?keyword=" + txtSearch.Text);
        }
    }
}