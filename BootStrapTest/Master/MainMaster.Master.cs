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
            rptTopics.DataSource = helper.GetHelpCategoryChildrenOrdered(db, 0);
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
            Label lblPageID = (Label)Page.FindControl("ContentPlaceHolder1").FindControl("lblPageID");
            lblPageID.Text = lblID.Text;
        }

        protected void lnkChildCat_Click(object sender, EventArgs e)
        {
            LinkButton lnk = (LinkButton)sender;
            RepeaterItem item = (RepeaterItem)lnk.NamingContainer;
            Label lblID = (Label)item.FindControl("lblChildID");
            Label lblPageID = (Label)FindControl("ContentPlaceHolder1").FindControl("lblPageID");
            lblPageID.Text = lblID.Text;
        }

        protected void rptTopics_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.DataItem != null)
            {
                Label lblID = (Label)e.Item.FindControl("lblID");
                int catID = 0;
                try
                {
                    catID = Convert.ToInt32(lblID.Text);
                }
                catch (FormatException) { }
                
                Repeater rptChild = (Repeater)e.Item.FindControl("rptChild");
                rptChild.DataSource = helper.GetHelpCategoryChildrenOrdered(db, catID);
                rptChild.DataBind();

                if (rptChild.Items.Count == 0)
                    rptChild.Visible = false;
            }
        }
    }
}