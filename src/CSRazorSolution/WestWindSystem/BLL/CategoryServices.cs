using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#region Additional Namespaces
using WestWindSystem.DAL;
using WestWindSystem.Entities;
#endregion

namespace WestWindSystem.BLL
{
    public class CategoryServices
    {
        #region setup of the context connection variable and class constructor
        private readonly WestWindContext _context;


        internal CategoryServices(WestWindContext regcontext)
        {
            _context = regcontext;
        }
        #endregion

        #region Query
        public List<Category> Category_List()
        {
            IEnumerable<Category> info = _context.Categories.
                                        OrderBy(x => x.CategoryName);

            return info.ToList();
        }
        #endregion
    }
}
