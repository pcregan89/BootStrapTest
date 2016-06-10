using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BootStrapTest.Admin.RelatedTopics
{
    public partial class List : System.Web.UI.Page
    {
        Helpers.HelpTopic helper = new Helpers.HelpTopic();
        Helpers.HelpCategory helperCat = new Helpers.HelpCategory();
        Helpers.HelpTopicRelated helperTR = new Helpers.HelpTopicRelated();
        dbDataContext db = new dbDataContext();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                rptHelpTopic.DataSource = helper.GetHelpTopics(db);
                rptHelpTopic.DataBind();

                ddlCategory.Items.Add("--Select--");
                foreach (tbl_Help_Category thc in helperCat.GetHelpCategories(db))
                {

                    ListItem li = new ListItem();
                    tbl_Help_Category cat;
                    Helpers.HelpCategory parentCatHelper = new Helpers.HelpCategory();
                    int foundParent, childCount = 0;
                    foundParent = ddlCategory.Items.IndexOf(ddlCategory.Items.FindByValue(thc.Help_Category_Parent_ID.ToString()));


                    if (thc.Help_Category_Parent_ID != null)
                    {
                        childCount++;
                        cat = parentCatHelper.GetHelpCategory(db, Convert.ToInt32(thc.Help_Category_Parent_ID));

                        for (int x; ;)
                        {
                            if (cat.Help_Category_Parent_ID != null)
                            {
                                childCount++;
                                cat = parentCatHelper.GetHelpCategory(db, Convert.ToInt32(cat.Help_Category_Parent_ID));
                            }
                            else
                                break;
                        }

                    }

                    li.Text = "";
                    li.Value = thc.Help_Category_ID.ToString();

                    if (foundParent > -1)
                    {
                        for (int x = 0; x < childCount; x++)
                        {
                            li.Text += HttpUtility.HtmlDecode("&nbsp;&nbsp;");
                        }

                        li.Text += "--" + thc.Help_Category_Name;
                        ddlCategory.Items.Insert(foundParent + 1, li);

                    }
                    else
                    {
                        li.Text = thc.Help_Category_Name;
                        ddlCategory.Items.Add(li);
                    }

                }
            }
        }

        protected void rptHelpTopic_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.DataItem != null)
            {
                tbl_Help_Topic cat = (tbl_Help_Topic)e.Item.DataItem;
                int relatedTopicID;

                Label lblCatParent = (Label)e.Item.FindControl("lblCatParent");
                lblCatParent.Text = helperCat.GetHelpCategory(db, cat.Help_Category_ID).Help_Category_Name;

                Label lblRelatedTopics = (Label)e.Item.FindControl("lblRelatedTopics");
                List<tbl_Help_Topic_Related> items = helperTR.GetHelpTopicRelatedTopic(db, cat.Help_Topic_ID);

                if (items.Count == 0)
                {
                    lblRelatedTopics.Text = "No related topics";
                }
                else
                {
                    foreach (tbl_Help_Topic_Related item in items)
                    {
                        if (item.Help_Topic_ID_First == cat.Help_Topic_ID)
                            relatedTopicID = item.Help_Topic_ID_Second;
                        else
                            relatedTopicID = item.Help_Topic_ID_First;

                        lblRelatedTopics.Text += "<a href=\"../../helptopic.aspx?id=" + relatedTopicID.ToString() + "\">" + helper.GetHelpTopic(db, relatedTopicID).Help_Topic_Header + "</a>" + "<br />";


                    }
                }
            }
        }

        protected void btnRefresh_Click(object sender, EventArgs e)
        {
            if (ddlCategory.SelectedIndex > 0)
            {
                rptHelpTopic.DataSource = helper.GetHelpTopicCategory(db, Convert.ToInt32(ddlCategory.SelectedValue));
                rptHelpTopic.DataBind();
            }
            else
            {
                rptHelpTopic.DataSource = helper.GetHelpTopics(db);
                rptHelpTopic.DataBind();
            }
        }
    }
}