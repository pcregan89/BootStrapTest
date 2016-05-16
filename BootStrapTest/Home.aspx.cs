using System;
using System.Web.UI.WebControls;

namespace BootStrapTest
{
    public partial class Home : System.Web.UI.Page
    {
        Helpers.HelpTopic helper = new Helpers.HelpTopic();
        dbDataContext db = new dbDataContext();

        protected void Page_Load(object sender, EventArgs e)
        {
            Repeater rptTopics = (Repeater)Master.FindControl("ContentPlaceHolder1").FindControl("rptTopics");
            rptTopics.DataSource = helper.GetHelpTopics(db);
            rptTopics.DataBind();
        }
    }
}