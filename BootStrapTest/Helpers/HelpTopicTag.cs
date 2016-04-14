using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BootStrapTest.Helpers
{
    public class HelpTopicTag
    {
        //Get single TopicTag for TopicTag ID
        public tbl_Help_Topic_Tag GetHelpTopicTag(dbDataContext db, int id)
        {
            return db.tbl_Help_Topic_Tags.Single(t => t.Help_Topic_Tag_ID == id);
        }

        //Get all TopicTags for topic ID
        public List<tbl_Help_Topic_Tag> GetHelpTopicTagTopic(dbDataContext db, int id)
        {
            IQueryable<tbl_Help_Topic_Tag> list = db.tbl_Help_Topic_Tags.Where(t => t.Help_Topic_ID == id);
            return list.ToList();
        }

        //Add or update TopicTag
        public int AddUpdateHelpTopicTag(dbDataContext db, int id, string name)
        {
            tbl_Help_Topic_Tag tag;
            if (id > 0)
                tag = GetHelpTopicTag(db, id);
            else
            {   // Add new category
                tag = new tbl_Help_Topic_Tag();
                db.tbl_Help_Topic_Tags.InsertOnSubmit(tag);
            }

            if (name.Length > 0 && name.Length <= 100)
                tag.Help_Topic_Tag_Text = name;

            //Get new ID
            if (id == 0)
                id = db.tbl_Help_Topic_Tags.Last().Help_Topic_Tag_ID + 1;

            db.SubmitChanges();

            if (db.GetChangeSet().Updates.Contains(tag))
                return id;
            else
                return -1;
        }

        //Delete TopicTag based on TopicTag ID
        public bool DeleteHelpTopicTag(dbDataContext db, int id)
        {
            tbl_Help_Topic_Tag tag;
            bool del = true;
            tag = GetHelpTopicTag(db, id);

            if (tag != null)
            {
                db.tbl_Help_Topic_Tags.DeleteOnSubmit(tag);
                db.SubmitChanges();
            }
            else
                del = false;

            return del;
        }

        //Delete TopicTag based on Topic ID
        public bool DeleteHelpTopicTagTopic(dbDataContext db, int id)
        {
            List<tbl_Help_Topic_Tag> tag;
            bool del = true;
            tag = GetHelpTopicTagTopic(db, id);

            if (tag != null)
            {
                db.tbl_Help_Topic_Tags.DeleteAllOnSubmit(tag);
                db.SubmitChanges();
            }
            else
                del = false;

            return del;
        }
    }
}