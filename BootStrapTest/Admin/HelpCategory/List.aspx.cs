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
            if (!IsPostBack)
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

                if (helper.GetHelpCategories(db) == null)
                    lblWarning.Text = "There are no records in the database";
            }
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
            int no = 0, count = 0;
            Repeater rptCategories = (Repeater)Master.FindControl("ContentPlaceHolder1").FindControl("rptCategories");

            foreach (RepeaterItem item in rptCategories.Items)
            {
                CheckBox del = (CheckBox)item.FindControl("ckDelete");

                if (del.Checked == true)
                {
                    //If checkbox is checked, get ID and delete selected record from database
                    Label lblID = (Label)item.FindControl("lblID");
                    int catID = Convert.ToInt32(lblID.Text.ToString());
                    helper.DeleteHelpCategory(db, catID);
                    count++;
                }
                no++;
            }

            Label lblWarning = (Label)Master.FindControl("ContentPlaceHolder1").FindControl("lblWarning");

            //Check how many records were selected, adjust message accordingly.
            if (count == 0)
                lblWarning.Text = "No records were selected";
            else if (count == 1)
                lblWarning.Text = "Record deleted";
            else
                lblWarning.Text = "Records deleted";
    
            //Refresh Repeater data source
            rptCategories.DataSource = helper.GetHelpCategories(db);
            rptCategories.DataBind();
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            Response.Redirect("../../Admin/HelpCategory/Form.aspx?id=-1");
        }

        protected void btnRowDelete_Click(object sender, EventArgs e)
        {
            //Get button that fired the command
            LinkButton btn = (LinkButton)sender;

            //Get repeater item holding the button
            RepeaterItem item = (RepeaterItem)btn.NamingContainer;
            
            //Get ID label for selected repeater item
            Label lblID = (Label)item.FindControl("lblID");

            //Get category ID from label
            int catID = Convert.ToInt32(lblID.Text);
            
            bool del = helper.DeleteHelpCategory(db, catID);

            Label lblWarning = (Label)Master.FindControl("ContentPlaceHolder1").FindControl("lblWarning");
            if (del)
            {
                lblWarning.Text = "Record deleted";
                //Refresh Repeater data source
                rptCategories.DataSource = helper.GetHelpCategories(db);
                rptCategories.DataBind();
            }
            else
                lblWarning.Text = "Could not delete record";
        }
    }
}