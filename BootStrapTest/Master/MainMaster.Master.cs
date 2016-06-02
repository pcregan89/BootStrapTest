using System;
using System.Web;
using System.Web.UI.WebControls;

namespace BootStrapTest
{
    public partial class MainMaster : System.Web.UI.MasterPage
    {
        dbDataContext db = new dbDataContext();
        Helpers.HelpCategory helper = new Helpers.HelpCategory();

        protected void Page_Load(object sender, EventArgs e)
        {
            Repeater rptCategory = (Repeater)FindControl("rptCategory");
            

            int id = 0;
            if (HttpContext.Current.Request.QueryString.Get("id") != null)
            {
                id = Convert.ToInt32(HttpContext.Current.Request.QueryString.Get("id"));
            }

            rptCategory.DataSource = helper.GetHelpCategoryChildrenOrdered(db, id);
            rptCategory.DataBind();

            Label lblIcon = (Label)FindControl("lblHeadIcon");
            LinkButton lnkHome = (LinkButton)FindControl("lnkHome");
            HiddenField hfID = (HiddenField)FindControl("hfID");
            if (id != 0)
            {
                lblIcon.CssClass = "fa fa-level-up fa-flip-horizontal";
                Helpers.HelpTopic helperTopic = new Helpers.HelpTopic();
                tbl_Help_Topic topic = new tbl_Help_Topic();
                tbl_Help_Category cat = new tbl_Help_Category();

                if (this.Page is HelpTopic)
                {
                    topic = helperTopic.GetHelpTopic(db, id);
                }
                else
                {
                    cat = helper.GetHelpCategory(db, id);
                }
                  

                
                if (cat != null)
                {
                    if (cat.Help_Category_ID > 0)
                    {
                        lnkHome.Text = cat.Help_Category_Name;
                        hfID.Value = cat.Help_Category_ID.ToString();
                    }
                }
                else
                {
                    cat = helper.GetHelpCategory(db, topic.Help_Category_ID);

                    if (cat != null)
                    {
                        lnkHome.Text = cat.Help_Category_Name;
                        hfID.Value = cat.Help_Category_ID.ToString();
                    }
                }
            }
            else
            {
                lblIcon.CssClass = "fa fa-home";
                lnkHome.Text = "Home";
            }

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
            lblPageID.Text = lblID.Text;
            Response.Redirect("/TopicList.aspx?id=" + lblID.Text);
        }

        protected void rptCategory_ItemDataBound(object sender, RepeaterItemEventArgs e)
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

        protected void lnkHome_Click(object sender, EventArgs e)
        {
            LinkButton lnkHome = (LinkButton)sender;

            if (lnkHome.Text == "Home")
            {
                Response.Redirect("/Home.aspx");
            }
            else
            {
                HiddenField hf = (HiddenField)FindControl("hfID");
                int id = Convert.ToInt32(hf.Value);
                tbl_Help_Category cat = helper.GetHelpCategory(db, id);
                int parent = 0;
                try
                {
                    parent = Convert.ToInt32(cat.Help_Category_Parent_ID);
                }
                catch (FormatException) { }

                if (parent == 0)
                    Response.Redirect("/Home.aspx");
                else
                    Response.Redirect("/TopicList.aspx?id=" + parent);
            }
        }
    }
}