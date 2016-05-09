using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BootStrapTest.Helpers
{
    public class HelpTopicRelated
    {
        //Get single related topic for RelatedTopic ID
        public tbl_Help_Topic_Related GetHelpTopicRelated(dbDataContext db, int id)
        {
            return db.tbl_Help_Topic_Relateds.Single(t => t.Help_Topic_Related_ID == id);
        }

        //get all related help topics
        public List<tbl_Help_Topic_Related> GetHelpTopicsRelated(dbDataContext db)
        {
            IQueryable<tbl_Help_Topic_Related> list = db.tbl_Help_Topic_Relateds;
            return list.ToList();
        }

        //Get all RelatedTopics for topic ID
        public List<tbl_Help_Topic_Related> GetHelpTopicRelatedTopic(dbDataContext db, int id)
        {
            IQueryable<tbl_Help_Topic_Related> list = db.tbl_Help_Topic_Relateds.Where(t => t.Help_Topic_ID_First == id || t.Help_Topic_ID_Second == id);
            return list.ToList();
        }

        //Add or update RelatedTopic
        public int AddUpdateHelpTopicRelated(dbDataContext db, int id, int first, int second)
        {
            tbl_Help_Topic_Related rel;
            int returnValue;

            if (id > 0)
                rel = GetHelpTopicRelated(db, id);
            else
            {   // Add new category
                rel = new tbl_Help_Topic_Related();
                db.tbl_Help_Topic_Relateds.InsertOnSubmit(rel);
            }

            rel.Help_Topic_ID_First = first;
            rel.Help_Topic_ID_Second = second;

            

            if (db.GetChangeSet().Updates.Contains(rel))
                returnValue = id;
            else
                returnValue = -1;

            db.SubmitChanges();

            return returnValue;
        }

        //Delete related topic based on RelatedTopic ID
        public bool DeleteHelpTopicRelated(dbDataContext db, int id)
        {
            tbl_Help_Topic_Related rel;
            bool del = true;
            rel = GetHelpTopicRelated(db, id);

            if (rel != null)
            {
                db.tbl_Help_Topic_Relateds.DeleteOnSubmit(rel);
                db.SubmitChanges();
            }
            else
                del = false;

            return del;
        }

        //Delete related topic based on Topic ID
        public bool DeleteHelpTopicRelatedTopic(dbDataContext db, int id)
        {
            List<tbl_Help_Topic_Related> rel;
            bool del = true;
            rel = GetHelpTopicRelatedTopic(db, id);

            if (rel != null)
            {
                db.tbl_Help_Topic_Relateds.DeleteAllOnSubmit(rel);
                db.SubmitChanges();
            }
            else
                del = false;

            return del;
        }
    }
}