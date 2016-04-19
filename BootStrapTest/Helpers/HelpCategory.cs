using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BootStrapTest.Helpers
{
    public class HelpCategory
    {
        //Get help category based on category ID
        public tbl_Help_Category GetHelpCategory(dbDataContext db, int id)
        {
            try
            {
                return db.tbl_Help_Categories.Single(t => t.Help_Category_ID == id);
            }
            catch (InvalidOperationException)
            {
                return null;
            }
        }

        public IEnumerable<tbl_Help_Category> GetHelpCategories(dbDataContext db)
        {
            return db.tbl_Help_Categories;
        }

        //Add or edit help category
        public int AddUpdateHelpCategory(dbDataContext db, int id, string name, int order, int parent, bool loggedOut)
        {
            // Validate 
            if (name.Length == 0 || name.Length > 50)
                return -1;

            tbl_Help_Category cat;
            if (id > 0)
                cat = GetHelpCategory(db, id);
            else
            {   // Add new category
                cat = new tbl_Help_Category();
                db.tbl_Help_Categories.InsertOnSubmit(cat);
            }

            cat.Help_Category_Name = name;
            if (order > -1)
                cat.Help_Category_Order = order;
            if (parent > -1)
                cat.Help_Category_Parent_ID = parent;
            cat.Help_Category_Logged_Out_Available = loggedOut;

            db.SubmitChanges();

            return cat.Help_Category_ID;
        }

        //Delete help Category based on category ID
        public bool DeleteHelpCategory(dbDataContext db, int id)
        {
            tbl_Help_Category cat;
            bool del = true;
            cat = GetHelpCategory(db, id);

            if (cat != null)
            {
                db.tbl_Help_Categories.DeleteOnSubmit(cat);
                db.SubmitChanges();
            }
            else
                del = false;

            return del;
        }
    }
}