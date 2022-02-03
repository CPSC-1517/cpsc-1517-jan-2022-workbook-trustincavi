using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace PracticeConcosle.Data
{
    public class Person
    {
        // example of a COMPOSITE class
        // a COMPOSITE class uses other classes in its definition
        // a composite class is recognized with the phrase "has a" class
        // this class of Person "has a" resident address

        // an INHERITED class extends another class in its definition
        // an INHERITED class recognized with the phrase "is a" class
        // assume a general class called Transportation
        //   then we can "extend" thid class to more specific classes
        //     public class Vehicle : Transportation
        //     public class Bike : Transportation
        //     public class Boat : Transportation


        // each instance of this class will represent an individual
        // This class will define the following characteristics of a person

        private string _FirstName = "";
        private string _LastName = "";

        public string FirstName
        {
            get { return _FirstName; }
            private set 
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
            get { return _LastName; }
            private set
            {
                if (Utilities.IsEmpty(value))
                {
                    throw new ArgumentNullException("Last name is required.");
                }
                _LastName = value;
            }
        }


        // Composition actually uses the other class as a property/field with
        // the definition of the class being defined
        // in this example Address is a field (data member)

        [JsonInclude]
        public ResidentAddress Address;


        // Composition
        public List<Employment> EmploymentPositions { get; private set; }


        // CONSTRUCTOR

        // Option 1: assign some default value to the strings
        // since FirstName and LastName need to have values
        // you can assign default literals to the properties
        //public Person()
        //{
        // If an instance of List<T> is not created and assigned then
        // the property will have an imitial value of null
        //EmploymentPositions = new List<Employment>();
        //FirstName = "unknown";
        //LastName = "unknown";
        //}

        // Option 2:
        // DO NOT code a "default" constructor.
        // Code only the "greedy" constructor.
        // If ONLY a greedy constructor exists for the class, the ONLY way
        // to possibly create an instance for the class within the program
        // is to use the constructor when the class instance is create
        public Person(
            string firstName,
            string lastName,
            ResidentAddress address,
            List<Employment> employmentPositions)
        {
            FirstName = firstName;
            LastName = lastName;
            Address = address;
            if (employmentPositions != null)
            {
                EmploymentPositions = employmentPositions;
            }
            else
            {
                // allows a null value and the class to have an empty List<T>
                EmploymentPositions = new List<Employment>();

            }
        }

        public void ChangeName(string firstname, string lastname)
        {
            FirstName = firstname.Trim();
            LastName = lastname.Trim();
        }

        public void AddEmployment(Employment employment)
        {
            EmploymentPositions.Add(employment);
        }
    }
}
