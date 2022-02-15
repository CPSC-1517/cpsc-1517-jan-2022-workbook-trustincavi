using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeConsole.Data
{
    // STRUCT is another of developer of datatype
    // looks like a class definition
    // Struct however is a value type storage whereas class is a reference type storage
    // Struct can hve fields, properties, contrctors and behaviours
    // Structs are best suited for small data structures that contain
    // primarily data that is not intended to be modified after the struct is created.
    // A struct is a value type. If you assign a struct to a new variable,
    // the new variable will contain a copy of the original.
    public struct ResidentAddress
    {
        public int Number;
        public string Address1;
        public string Address2;
        private string _Unit;
        private string _City;
        public string ProvinceState;

        public string Unit
        {
            get { return _Unit; }
            set { _Unit = value; }
        }

        public string City
        {
            get { return _City; }
            set { _City = value; }
        }

        public ResidentAddress (
            int Number,
            string Address1,
            string Address2,
            string Unit,
            string City,
            string ProvinceState)
        {
            // CONCERN:
            // parameter name is exactly the same as the struct/class field/property
            // use the keyword "this." of your instance item
            // "this." references to the instance that you are currently accessing in your program
            this.Number = Number;
            this.Address1 = Address1;
            this.Address2 = Address2;
            this.ProvinceState = ProvinceState;
            _Unit = Unit;
            _City = City;
        }

        // Note that NO "default" constructor was created because I wish the program
        // to assign the address with all neccessary info


        public override string ToString()
        {
            return $"{Number},{Address1},{Address2},{ProvinceState},{_Unit},{_City}"; 
        }
    }
}
