using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BootStrapTest.Admin.HelpTopic
{
    public partial class List : System.Web.UI.Page
    {
        Helpers.HelpTopic helper = new Helpers.HelpTopic();
        Helpers.HelpCategory helperCat = new Helpers.HelpCategory();
        dbDataContext db = new dbDataContext();

        protected void Page_Load(object sender, EventArgs e)
        {
            rptHelpTopic.DataSource = helper.GetHelpTopics(db);
            rptHelpTopic.DataBind();
        }

        protected void rptHelpTopic_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            

            if (e.Item.DataItem != null)
            {
                tbl_Help_Topic cat = (tbl_Help_Topic)e.Item.DataItem;

                Label lblCatParent = (Label)e.Item.FindControl("lblCatParent");
                lblCatParent.Text = helperCat.GetHelpCategory(db, cat.Help_Category_ID).Help_Category_Name;
            }
        }
    }
}