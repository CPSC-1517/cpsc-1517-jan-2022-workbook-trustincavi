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
    public class BuildVersionServices
    {
        #region Setup of the context connection variable and class constructor
        // Variable to hold an instance of context class
        private readonly WestWindContext _context;

        // Constructor to create an instance of the registered context class
        internal BuildVersionServices(WestWindContext regcontext)
        {
            _context = regcontext;
        }
        #endregion


        #region Services: Query
        // Create a method (services) that will retrieve the BuildVersion record.
        // This will be called from the webapp (PageModel file), thus is needs to be public.
        // This becomes part of the class library's (application library) public interface.
        public BuildVersion GetBuildVersion()
        {
            // Going to context instance (class), use the property (DbSet)
            // for BuildVersion data.
            // Using this property will retrieve data from the database.
            // The query will get the first record and return it.
            // If no data, the return value will be null.
            BuildVersion result = _context.BuildVersions.FirstOrDefault();
            return result;
        }
        #endregion
    }
}
