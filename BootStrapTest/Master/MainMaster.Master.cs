using System;
using System.Web.UI.WebControls;

namespace BootStrapTest
{
    public partial class MainMaster : System.Web.UI.MasterPage
    {
        dbDataContext db = new dbDataContext();
        Helpers.HelpCategory helper = new Helpers.HelpCategory();

        protected void Page_Load(object sender, EventArgs e)
        {
            Repeater rptTopics = (Repeater)FindControl("rptTopics");
            rptTopics.DataSource = helper.GetHelpCategoryChildren(db, 0);
            rptTopics.DataBind();
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            TextBox txtSearch = (TextBox)FindControl("txtSearch");
            Response.Redirect("/Search.aspx?keyword=" + txtSearch.Text);
        }

        protected void lnkCategory_Click(object sender, EventArgs e)
        {
            LinkButton lnk = (LinkButton)sender;
            RepeaterItem item = (RepeaterItem)lnk.NamingContainer;
            Label lblID = (Label)item.FindControl("lblID");
            Label lblPageID = (Label)FindControl("lblPageID");
            lblID.Text = lblID.Text;
        }
    }
}