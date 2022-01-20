using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeConcosle.Data
{
    public class Person
    {
        // example of a composite class
        // each instance of this class will represent an individual
        // This class will define the following characteristics of a person

        private string _FirstName;
        private string _LastName;

        public string FirstName
        {
            get { return _FirstName; }
            set 
            {
                if (Utilities.IsEmpty(value))
                {
                    throw new ArgumentNullException("First name is required.");
                }
                _FirstName = value; 
            }
        }

        public string LastName
        {
            get { return LastName; }
            set
            {
                if (Utilities.IsEmpty(value))
                {
                    throw new ArgumentNullException("Last name is required.");
                }
                _LastName = value;
            }
        }

        public ResidentAddress Address;

        public List<Employment> EmploymentPositions { get; set; }

        public Person()
        {
            // If an instance of List<T> is not created and assigned then
            // the property will have an imitial value of null
            EmploymentPositions = new List<Employment>();
        }
    }
}
