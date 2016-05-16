using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI.WebControls;

namespace BootStrapTest
{
    public partial class Search : System.Web.UI.Page
    {
        string keyword;
        Helpers.HelpTopic helpTopic = new Helpers.HelpTopic();
        Helpers.HelpTopicTag helpTag = new Helpers.HelpTopicTag();
        dbDataContext db = new dbDataContext();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (HttpContext.Current.Request.QueryString.Get("keyword") != null)
                keyword = HttpContext.Current.Request.QueryString.Get("keyword");
            else
                keyword = "";

            if (keyword != "")
            {
                List<tbl_Help_Topic> source = helpTopic.GetHelpTopicKeyword(db, keyword);
                List<tbl_Help_Topic_Tag> tags = helpTag.GetHelpTopicTagKeyword(db, keyword);

                if (tags.Count != 0)
                {
                    foreach (tbl_Help_Topic_Tag item in tags)
                    {
                        tbl_Help_Topic topic = helpTopic.GetHelpTopic(db, item.Help_Topic_ID);
                        if (!source.Contains(topic))
                            source.Add(topic);
                    }
                }

                Repeater rptSearch = (Repeater)Master.FindControl("ContentPlaceHolder1").FindControl("rptSearch");
                rptSearch.DataSource = source;
                rptSearch.DataBind();
            }
        }

        protected void lnkHead_Click(object sender, EventArgs e)
        {
            LinkButton lnk = (LinkButton)sender;
            RepeaterItem item = (RepeaterItem)lnk.NamingContainer;
            Label lblID = (Label)item.FindControl("lblID");
            Response.Redirect("/HelpTopic.aspx?id=" + lblID.Text);
        }
    }
}