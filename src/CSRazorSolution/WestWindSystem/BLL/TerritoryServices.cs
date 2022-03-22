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
    public class TerritoryServices
    {
        #region setup of the context connection variable and class constructor

        //variable to hold an instance of context class
        private readonly WestWindContext _context;

        //constructor to create an instance of the registered context class
        internal TerritoryServices(WestWindContext regcontext)
        {
            _context = regcontext;
        }
        #endregion

        #region Queries

        //query by a string
        // This parital search query has been altered to allow for pagination.
        // If paging is NOT required, the query should have a single parameter: partialdescription.

        public List<Territory> GetByPartialDescription(
            string partialdescription,
            int pageNumber,
            int pageSize,
            out int totalCount)
        {
            IEnumerable<Territory> info = _context.Territories
                            .Where(x => x.TerritoryDescription.Contains(partialdescription))
                            .OrderBy(x => x.TerritoryDescription);

            totalCount = info.Count();

            // The pageNumber is a natural number (1-based, 1,2,3,..)
            // The number of rows to skip is index*pageSize
            int skipRows = (pageNumber - 1) * pageSize;
            // Use LinQ's .Skip(N) to skip over N rows from a collection.
            // Use .Take(N) to take the next n rows from a collection.
            return info.Skip(skipRows).Take(pageSize).ToList();
            

            //return info.ToList();
        }
        //query by a number
        public List<Territory> GetByRegion(int regionid)
        {
            IEnumerable<Territory> info = _context.Territories
                            .Where(x => x.RegionID == regionid)
                            .OrderBy(x => x.TerritoryDescription);
            return info.ToList();
        }
        #endregion

    }
}