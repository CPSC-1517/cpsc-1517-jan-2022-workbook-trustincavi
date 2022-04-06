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
    public class SupplierServices
    {
        #region setup of the context connection variable and class constructor
        private readonly WestWindContext _context;


        internal SupplierServices(WestWindContext regcontext)
        {
            _context = regcontext;
        }
        #endregion

        #region Query
        public List<Supplier> Supplier_List()
        {
            IEnumerable<Supplier> info = _context.Suppliers.
                                        OrderBy(x => x.CompanyName);

            return info.ToList();
        }
        #endregion
    }
}
