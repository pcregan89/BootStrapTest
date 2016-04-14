﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BootStrapTest.Helpers
{
    public class HelpTopic
    {
        //Get single topic based on Topic ID
        public tbl_Help_Topic GetHelpTopic(dbDataContext db, int id)
        {
            return db.tbl_Help_Topics.Single(t => t.Help_Topic_ID == id);
        }

        //Get all Topics for category ID
        public List<tbl_Help_Topic> GetHelpTopicCategory(dbDataContext db, int id)
        {
            IQueryable<tbl_Help_Topic> list = db.tbl_Help_Topics.Where(t => t.Help_Category_ID == id);
            return list.ToList();
        }

        //Add or edit topic
        public int AddUpdateHelpTopic(dbDataContext db, int id, string header, string text, int cat, bool loggedOut, int priority)
        {
            tbl_Help_Topic topic;
            if (id > 0)
                topic = GetHelpTopic(db, id);
            else
            {   // Add new category
                topic = new tbl_Help_Topic();
                db.tbl_Help_Topics.InsertOnSubmit(topic);
            }

            if (header.Length > 0 && header.Length <= 100)
                topic.Help_Topic_Header = header;
            if (text.Length > 0)
                topic.Help_Topic_Text = text;
            if (cat != 0)
                topic.Help_Category_ID = cat;
            if (priority != 0)
                topic.Help_Topic_Priority = priority;
            topic.Help_Topic_Logged_Out_Available = loggedOut;

            //Default values
            topic.Help_Topic_Dislikes = 0;
            topic.Help_Topic_Last_Updated = DateTime.Now;
            topic.Help_Topic_Likes = 0;
            topic.Help_Topic_Share_Count = 0;
            topic.Help_Topic_View_Count = 0;
                        
            //Get new ID
            if (id == 0)
                id = db.tbl_Help_Topics.Last().Help_Topic_ID + 1;

            db.SubmitChanges();

            if (db.GetChangeSet().Updates.Contains(topic))
                return id;
            else
                return -1;
        }

        public int AddUpdateHelpTopic(dbDataContext db, int id, string header, string text, int cat, bool loggedOut, int priority, int dislikes, int likes,
            int share, int view, DateTime update)
        {
            tbl_Help_Topic topic;
            if (id > 0)
                topic = GetHelpTopic(db, id);
            else
            {   // Add new category
                topic = new tbl_Help_Topic();
                db.tbl_Help_Topics.InsertOnSubmit(topic);
            }

            if (header.Length > 0 && header.Length <= 100)
                topic.Help_Topic_Header = header;
            if (text.Length > 0)
                topic.Help_Topic_Text = text;
            if (cat != 0)
                topic.Help_Category_ID = cat;
            if (priority != 0)
                topic.Help_Topic_Priority = priority;
            if (dislikes > 0)
                topic.Help_Topic_Dislikes = dislikes;
            if (likes > 0)
                topic.Help_Topic_Likes = likes;
            if (share > 0)
                topic.Help_Topic_Share_Count = share;
            if (view > 0)
                topic.Help_Topic_View_Count = view;
            topic.Help_Topic_Logged_Out_Available = loggedOut;
            topic.Help_Topic_Last_Updated = update;

            //Get new ID
            if (id == 0)
                id = db.tbl_Help_Topics.Last().Help_Topic_ID + 1;

            db.SubmitChanges();

            if (db.GetChangeSet().Updates.Contains(topic))
                return id;
            else
                return -1;
        }

        //Delete topic based on Topic ID
        public bool DeleteHelpTopic(dbDataContext db, int id)
        {
            tbl_Help_Topic topic;
            bool del = true;
            topic = GetHelpTopic(db, id);

            if (topic != null)
            {
                db.tbl_Help_Topics.DeleteOnSubmit(topic);
                db.SubmitChanges();
            }
            else
                del = false;

            return del;
        }

        //Delete topics based on Category ID
        public bool DeleteHelpTopicRelatedCategory(dbDataContext db, int id)
        {
            List<tbl_Help_Topic> topic;
            bool del = true;
            topic = GetHelpTopicCategory(db, id);

            if (topic != null)
            {
                db.tbl_Help_Topics.DeleteAllOnSubmit(topic);
                db.SubmitChanges();
            }
            else
                del = false;

            return del;
        }
    }
}