using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#region Additional Namespaces
using WestWindSystem.DAL;
using WestWindSystem.Entities;
using Microsoft.EntityFrameworkCore.ChangeTracking;

#endregion

namespace WestWindSystem.BLL
{
    public class ProductServices
    {
        #region setup of the context connection variable and class constructor
        private readonly WestWindContext _context;

        internal ProductServices(WestWindContext regcontext)
        {
            _context = regcontext;
        }
        #endregion

        #region Query
        // Filter search returning all products of the requested category (categoryid)
        public List<Product> Product_CategoryProducts(int categoryid)
        {
            IEnumerable<Product> info = _context.Products
                                        .Where(x => x.CategoryID == categoryid)
                                        .OrderBy(x => x.CategoryID);

            return info.ToList();
        }

        // For the CRUD you are maintaining a single on the database
        // This row will be optain by the PK value of the row.
        public Product Product_GetById(int productid)
        {

            Product product = _context.Products
                .Where(x => x.ProductID == productid)
                .FirstOrDefault();
            return product;
        }
        #endregion

        #region Add, Update, Delete

        // Add: may need to check if the new record is already exists in DB.

        // You must know whether the table has an identity OK or not.
        // If the table PK is NOT an identity then you must ensure that the incoming row has a PK value.
        // If the table PK is an identity then the database will generate that value and make it assessable to you after 
        //   the data has been committed.

        // Product PK is an identity attribute.
        // This method opts to send the new identity value back to the web page (PageModel call statement)

        // Here we try to check (for example) if new record has same name and quantity per unit form the supplier.
        public int Product_AddProduct(Product item)
        {
            if (item == null)
            {
                throw new ArgumentNullException("Product data is missing");
            }
            Product exists = _context.Products
                .Where(x =>
                    x.ProductName.Equals(item.ProductName) &&
                    x.QuantityPerUnit.Equals(item.QuantityPerUnit) &&
                    x.SupplierID == item.SupplierID)
                .FirstOrDefault();

            if (exists != null)
            {
                throw new Exception($"{item.ProductName} with a size of {item.QuantityPerUnit}" +
                    $" from the selected supplier is already on file.");
            }


            // Stage the data.
            // a) what DbSet
            // b) the action
            // c) indicate the data involved.

            // IMPORTANT: the data is in LOCAL memory and has not yet been sent to the DB.
            // THEREFORE, there is NO PK value (except for the system default (numeric 0) ).
            _context.Products.Add(item);

            // Commit the local data to DB

            // If there are validation annotations on the Entities, they will be executed
            // during the SaveChanges().
            _context.SaveChanges();

            // After the commit, PK value is now available
            return item.ProductID;
        }


        // Update: can also have design considerations for validation.
        // Update may reqiest that you check record of interest is still on the DB.
        public int Product_UpdateProduct(Product item)
        {
            // For Updating, MUST have the PK value on your instance.
            // If not, it will not work.



            // ***** WARNING *****

            // This method (the code to update below) can cause problems then being used with EntityEntry<T> processing.

            //Product exists = _context.Products
            //    .Where(x => x.ProductID == item.ProductID)
            //    .FirstOrDefault();
            //if (exists != null)
            //{
            //    throw new Exception($"{item.ProductName} with a size of {item.QuantityPerUnit}" +
            //        $" from the selected supplier is already on file.");
            //}

            // ***** end of WARNING *****



            // ***** BETTER METHOD *****
            // This does NOT actually return an instance and thus has NO CONFLICT
            // with using EntityEntry<T>.

            // This method does the search but return only a boolean of success
            bool exists = _context.Products.Any(x => x.ProductID == item.ProductID);
            if (!exists)
            {
                throw new Exception($"{item.ProductName} with a size of {item.QuantityPerUnit}" +
                    $" from the selected supplier is already on file.");
            }

            // Stage the update
            EntityEntry<Product> updating = _context.Entry(item);

            // Flag the entity to be modified
            updating.State = Microsoft.EntityFrameworkCore.EntityState.Modified;


            // During the commit, SaveChanges() returns the affected rows.
            return _context.SaveChanges();
        }

        public int Product_DeleteProduct(Product item)
        {
            bool exists = _context.Products.Any(x => x.ProductID == item.ProductID);
            if (!exists)
            {
                throw new Exception($"{item.ProductName} with a size of {item.QuantityPerUnit}" +
                    $" from the selected supplier is already on file.");
            }

            // Removing a record from your database maybe a
            // a) Physical act
            //      If you wish the record the be physically removed from the DB,
            //      use the staging of .Deleted
            //      If the record being removed from the DB is a parent record, delation will FAIL
            //      in RDB if there are existing children row.
            //      Decision the automatically remove children is a "system design decision".

            //EntityEntry<Product> deleting = _context.Entry(item);
            //deleting.State = Microsoft.EntityFrameworkCore.EntityState.Deleted;



            // b) Or Logical act
            //      This is where you cannot physically remove a record from the DB.
            //      This decision is based on existing best practice business rules OR set by the government regulations.
            //      This type of delete is done so the "flagged" data is NOT used in daily processing.
            //      
            //      This type of delete will actually be an update the attribute (property) of the record.
            //      Look for attributes such as Active, Discontinued, a special date ReleaseDate.
            // In this case, we do Updating instead.

            // Product is logical delete (Discontinued = true)
            item.Discontinued = true;
            EntityEntry<Product> updating = _context.Entry(item);
            updating.State = Microsoft.EntityFrameworkCore.EntityState.Modified;

            return _context.SaveChanges();
        }
        #endregion
    }
}
