using System;
using System.Web.UI.WebControls;

namespace BootStrapTest
{
    public partial class MainMaster : System.Web.UI.MasterPage
    {
        Helpers.HelpCategory helper = new Helpers.HelpCategory();
        dbDataContext db = new dbDataContext();
        int catID = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            Repeater rptCategories = (Repeater)FindControl("rptCategories");
            rptCategories.DataSource = helper.GetHelpCategoryChildren(db, catID);
            rptCategories.DataBind();
        }

        protected void CategoryLink_Click(object sender, EventArgs e)
        {
            //Get button that fired the command
            LinkButton btn = (LinkButton)sender;

            //Get repeater item holding the button
            RepeaterItem item = (RepeaterItem)btn.NamingContainer;

            //Get ID label for selected repeater item
            Label lblID = (Label)item.FindControl("lblID");

            //Get category ID from label
            catID = Convert.ToInt32(lblID.Text);

            //Refresh menu with child categories
            Repeater rptCategories = (Repeater)FindControl("rptCategories");
            rptCategories.DataSource = helper.GetHelpCategoryChildren(db, catID);
            rptCategories.DataBind();

            LinkButton lnkHead = (LinkButton)FindControl("lnkHead");
            Label lblHeadID = (Label)FindControl("lblHeadID");
            Label lblIcon = (Label)FindControl("lblIcon");

            tbl_Help_Category cat;
            if (catID != 0)
            {
                cat = helper.GetHelpCategory(db, catID);
                lnkHead.Text = cat.Help_Category_Name;
                lblHeadID.Text = cat.Help_Category_ID.ToString();
                lblIcon.CssClass.Remove(0, lblIcon.CssClass.Length);
                lblIcon.CssClass = "fa fa-level-up fa-flip-horizontal icon-data fa-fw";
            }
            else
            {
                lnkHead.Text = "Home";
                lblHeadID.Text = "";
                lblIcon.CssClass.Remove(0, lblIcon.CssClass.Length);
                lblIcon.CssClass = "fa fa-home icon-data fa-fw";
            }
        }

        protected void lnkHead_Click(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                LinkButton lnkHead = (LinkButton)FindControl("lnkHead");
                Label lblHeadID = (Label)FindControl("lblHeadID");
                Label lblIcon = (Label)FindControl("lblIcon");

                //Get category ID from label
                catID = Convert.ToInt32(lblHeadID.Text);

                try
                {
                    catID = Convert.ToInt32(helper.GetHelpCategory(db, catID).Help_Category_Parent_ID);
                }
                catch (FormatException)
                {
                    catID = 0;
                }

                //Refresh menu with child categories
                Repeater rptCategories = (Repeater)FindControl("rptCategories");
                rptCategories.DataSource = null;
                rptCategories.DataBind();
                rptCategories.DataSource = helper.GetHelpCategoryChildren(db, catID);
                rptCategories.DataBind();


                tbl_Help_Category cat;
                if (catID != 0)
                {
                    cat = helper.GetHelpCategory(db, catID);
                    lnkHead.Text = cat.Help_Category_Name;
                    lblHeadID.Text = cat.Help_Category_ID.ToString();
                    lblIcon.CssClass.Remove(0, lblIcon.CssClass.Length);
                    lblIcon.CssClass = "fa fa-level-up fa-flip-horizontal icon-data fa-fw";
                }
                else
                {
                    lnkHead.Text = "Home";
                    lblHeadID.Text = "";
                    lblIcon.CssClass.Remove(0, lblIcon.CssClass.Length);
                    lblIcon.CssClass = "fa fa-home icon-data fa-fw";
                }
            }
        }
    }
}