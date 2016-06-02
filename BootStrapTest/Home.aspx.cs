﻿using System;
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
            rptPriority.DataSource = helper.GetHelpTopicPriority(db);

            //Sort by views
            //rptPriority.DataSource = helper.GetHelpTopicViews(db);

            //Sort by shares
            //rptPriority.DataSource = helper.GetHelpTopicShare(db);

            //Sort by likes
            //rptPriority.DataSource = helper.GetHelpTopicLike(db);
            rptPriority.DataBind();

        }
    }
}