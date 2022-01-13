using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeConcosle.Data
{
    public class Employment
    {

        // An instance of this class will hold data about a person's employment
        // Tge code of this class is the definition of that data
        // The characteristics (data) of the class 
        //  Title, SupervisoryLevel, Years of Employment within the company

        // 4 components of a class definition are
        //   data fields
        //   property
        //   contructor
        //   behaviour (mothod)


        // data fields
        //   are storage area in your class
        //   these are treated as variables
        //   these may be public, private, public readonly
        private string _Title;
        private double _Years;


        // properties
        //   these are access technique to retrieve or set data in class
        //   without directly touching the storage data field

        // - fully implemented proprerty
        //   a) a decalred storage area (data field)
        //   b) a declared property signature
        //   c) a code get "method"
        //   d) an optional coded set "method"

        // When
        //   a) if you are storing the associate data in an explicitly decalared data feild
        //   b) if you are during validation access incoming data
        //   c) creating a property that generates ouput from other data sources
        //      within the class (readonly properties);
        //      this property would have only a "get" method
        public string Title
        {
            get
            {
                // accessor
                // the "get" method will return the contents of a data fields as an expression
                return _Title;
            }
            set
            {
                // mutator
                // the "set" method receives an incoming value and places it in the data field
                // during the setting, you might wish to validate the incoming data
                // during the setting, you might wish to do some type of logical processing
                //  using the data to set another field
                // the incoming piece of data is referred to using the keyword "value"

                // ensure that the incoming data is not null or empty or just whitespace
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("Title is a required piece of data.");
                }
                _Title = value;
            }
        }

        // auto-implemetend property
        // these properties differ only in syntax
        // each property is responsible for a single piece of data
        // these properties DO NOT references a declared private data member
        // the system generates an internal storage area of the return data type
        // the system manages the internal storage for the accessor and mutator
        // this is NO additional logic applied to the data value
        public int Level { get; set; }


        // this property could be coded as either a fully-implemented or auto-implemented prop
        public double Years
        {
            get { return _Years; }
            set { _Years = value; }
        }

        // constructor



        // behaviour
    }
}
