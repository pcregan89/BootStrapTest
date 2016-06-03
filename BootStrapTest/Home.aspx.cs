using System;
using System.Web;
using System.Web.UI.WebControls;

namespace BootStrapTest
{
    public partial class Home : System.Web.UI.Page
    {
        Helpers.HelpTopic helper = new Helpers.HelpTopic();
        Helpers.HelpTopicTag helpTags = new Helpers.HelpTopicTag();
        dbDataContext db = new dbDataContext();

        protected void Page_Load(object sender, EventArgs e)
        {
            Repeater rptPriority = (Repeater)Master.FindControl("ContentPlaceHolder1").FindControl("rptPriority");
            //Sort by priority
            rptPriority.DataSource = helper.GetHelpTopicPriority(db, 9);

            //Sort by views
            //rptPriority.DataSource = helper.GetHelpTopicViews(db, 9);

            //Sort by shares
            //rptPriority.DataSource = helper.GetHelpTopicShare(db, 9);

            //Sort by likes
            //rptPriority.DataSource = helper.GetHelpTopicLike(db, 9);
            rptPriority.DataBind();

        }
    }
}