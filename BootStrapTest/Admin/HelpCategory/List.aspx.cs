using System;
using System.Collections.Generic;
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
                {
                    lblWarning.Text = HttpContext.Current.Request.QueryString.Get("msg").ToString();
                    lblWarning.CssClass = "text-success";
                    lblWarning.Visible = true;
                }
                else
                {
                    lblWarning.Text = "";
                    lblWarning.Visible = false;
                }

                    // Bind the repeater
                    Repeater rptCategories = (Repeater)Master.FindControl("ContentPlaceHolder1").FindControl("rptCategories");
                rptCategories.DataSource = helper.GetHelpCategories(db);
                rptCategories.DataBind();

                if (helper.GetHelpCategories(db) == null)
                {
                    lblWarning.Text = "There are no records in the database";
                    lblWarning.CssClass = "text-danger";
                    lblWarning.Visible = true;
                }
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
            int count = 0;
            string children = "";
            Repeater rptCategories = (Repeater)Master.FindControl("ContentPlaceHolder1").FindControl("rptCategories");

            Label lblWarning = (Label)Master.FindControl("ContentPlaceHolder1").FindControl("lblWarning");
            lblWarning.Visible = false;

            foreach (RepeaterItem item in rptCategories.Items)
            {
                CheckBox del = (CheckBox)item.FindControl("ckDelete");

                if (del.Checked == true)
                {
                    //If checkbox is checked, get ID and delete selected record from database
                    Label lblID = (Label)item.FindControl("lblID");
                    int catID = Convert.ToInt32(lblID.Text.ToString());

                    //Check category has no children
                    List<tbl_Help_Category> child = helper.GetHelpCategoryChildren(db, catID);

                    if (child.Count == 0)
                        helper.DeleteHelpCategory(db, catID);
                    else
                        children += " " + catID + " ";

                    //Count records selected
                    count++;
                }
            }

            //Check how many records were selected, adjust message accordingly.
            if (count == 0)
            {
                lblWarning.Text = "No records were selected";
                lblWarning.CssClass = "text-danger";
                lblWarning.Visible = true;
            }
            else if (count == 1 && children.Length == 0)
            {
                lblWarning.Text = "Record deleted";
                lblWarning.CssClass = "text-success";
                lblWarning.Visible = true;
            }
            else if (count > 1 && children.Length == 0)
            {
                lblWarning.Text = "Records deleted";
                lblWarning.CssClass = "text-success";
                lblWarning.Visible = true;
            }
            else if (children.Length > 0)
            {
                lblWarning.Text = "The following selected records may have dependencies: " + children;
                lblWarning.CssClass = "text-danger";
                lblWarning.Visible = true;
            }
    
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
            Label lblWarning = (Label)Master.FindControl("ContentPlaceHolder1").FindControl("lblWarning");
            lblWarning.Text = "";

            bool del = false, children = false;
            //Get button that fired the command
            LinkButton btn = (LinkButton)sender;

            //Get repeater item holding the button
            RepeaterItem item = (RepeaterItem)btn.NamingContainer;
            
            //Get ID label for selected repeater item
            Label lblID = (Label)item.FindControl("lblID");

            //Get category ID from label
            int catID = Convert.ToInt32(lblID.Text);

            //Check category has no children
            List<tbl_Help_Category> child = helper.GetHelpCategoryChildren(db, catID);

            if (child.Count == 0)
                del = helper.DeleteHelpCategory(db, catID);
            else
                children = true;

            if (del)
            {
                lblWarning.Text = "Record deleted";
                lblWarning.CssClass = "text-success";
                lblWarning.Visible = true;
                //Refresh Repeater data source
                rptCategories.DataSource = helper.GetHelpCategories(db);
                rptCategories.DataBind();
            }
            else if (children == true)
            {
                lblWarning.Text = "The record you selected (ID: " + catID + ") has dependencies.";
                lblWarning.CssClass = "text-danger";
                lblWarning.Visible = true;
            }
            else
            {
                lblWarning.Text = "Could not delete record";
                lblWarning.CssClass = "text-danger";
                lblWarning.Visible = true;
            }
        }
    }
}