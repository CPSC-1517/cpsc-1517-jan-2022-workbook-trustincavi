#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#region Additional namespaces
using WestWindSystem.DAL;
using WestWindSystem.Entities;
#endregion

namespace WestWindSystem.BLL
{
    public class RegionServices
    {
        #region Setup of the context connection variable and class constructor
        // Variable to hold an instance of context class
        private readonly WestWindContext _context;

        // Constructor to create an instance of the registered context class
        internal RegionServices(WestWindContext regcontext)
        {
            _context = regcontext;
        }
        #endregion


        #region Services: Query
        // This query will have a parameter which will receive an argument value
        // from the web page.
        // This query will return a single instance of the entity Region,
        // which matches the incoming argument value.
        public Region Region_GetById (int regionId)
        {
            Region info = _context.Regions
                            .Where(aCollectionRow => aCollectionRow.RegionID == regionId)
                            .FirstOrDefault();

            return info;
        }


        // Get all records of the SQL Region table and return as a List<T>
        public List<Region> Region_List()
        {
            // LinQ queries use 2 generic collection types
            // IQueryable: data collection returned from SQL
            // IEnumerable: data collection in local memory.
            // Both can be converted to List<T> using .ToList()
            IEnumerable<Region> info = _context.Regions.
                                        OrderBy(x => x.RegionDescription);

            return info.ToList();
        }
        #endregion
    }
}
