using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeConsole.Data
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
        private string _Title = "";
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

        // - auto-implemetend property
        // these properties differ only in syntax
        // each property is responsible for a single piece of data
        // these properties DO NOT references a declared private data member
        // the system generates an internal storage area of the return data type
        // the system manages the internal storage for the accessor and mutator
        // this is NO additional logic applied to the data value

        // Using an enum for this field eill AUTOMATICALLY restrict
        // the values this property can contain
        public SupervisoryLevel Level { get; set; }


        // this property could be coded as either a fully-implemented or auto-implemented prop
        public double Years
        {
            get { return _Years; }
            set 
            {
                if (!Utilities.IsPositive(value))
                {
                    throw new ArgumentNullException("Year can not be a negative value.");
                }
                _Years = value;
            }
        }

        // constructor
        // is to initialize the physical object (instance) during its creation
        // the result of creation is ensure that the coder gets an insurance
        // in a known state
        // 
        // if your class definition has NO constructor, the the data members/auto implemented properties
        // are set to the c# default data type value
        // 
        // There can be 1 or more constructors in your class definition
        // If you code a constructor for the class, you are responsible for all
        // constructors used by the class!!!!!!
        // 
        // 2 types:
        // - Default: this constructor does NOT take in parameters
        // - Greedy: this constructor has list of parameters, on for each property, declare for incoming data
        // 
        // Syntax: accesstype classname([list of parameters]) {}
        // IMPORTANT:
        // - The constructor DOES NOT have a return datatype
        // - You DO NOT call a contructor directly, called using the new operator.

        // default constructor
        public Employment()
        {
            // contrustor body
            // a) aparameter for each property
            // b) you could assign literal values to properties
            // c) validation for public readonly data members
            //    validation for a properties with a private set
            Level = SupervisoryLevel.TeamMember;
            Title = "Unknow";
        }

        // greedy constructor
        public Employment(string title, SupervisoryLevel level, double years)
        {
            Title = title;
            Level = level;
            Years = years;
        }



        // Behaviour (methods)
        // Syntax: accesstype [static] returndatatype BehaviourName([list of params]) {}
        // 
        // There maaybe times you wish to obtain all the data in your instance all at oncefor display
        // generally, to accomplish this, your class overrides the .ToString() method
        public override string ToString()
        {
            // display in csv format
            return $"{Title},{Level},{Years}";
        }

        public void SetEmployeeResponsibilityLevel(SupervisoryLevel level)
        {
            // you could do validation within this method to ensure acceptable value
            if (level < 0)
            {
                throw new Exception("Responsibility level must be positive");
            }

            Level = level;
        }

        // KO hien thi noi dung error bang console writeline trong method
        // exception trong method la internal error cho program
        // hien thi error voi user trong Main




        // This method will receive a csv string of value that represent an instancee of Employment,
        // the method will
        // - validate there are sufficient values for an instance
        // - will use primitive datatype .Parse() to convert the individual values
        // - will return a ;oad instance of the Employment class
        // - will use the FormatException() if insufficient data is supplied
        // As the instance is loaded on the return, the Employment constructor will be used.
        // Thus, any error generated by the constructor shall still be created.
        // This method will NOT retain any data.
        // This method will be a shared method (static)
        public static Employment Parse(string text)
        {
            // text is a string of csv values
            // Step 1: separate the string of values into individual values
            string[] parts = text.Split(',');

            // Step 2: verify that sufficient values exist to create the Employment instance
            if (parts.Length != 3)
            {
                throw new FormatException($"String is not in expected format, missing value. {text}");
            }

            // Step 3: return a new instance of the Employment class
            // as the instance is being created, the Employemnt constructor will be used.
            // Any validation occuring during the constructor execution will still be done,
            // whatever the logic is in the constructor OR in the individual property
            // use the Primitive .Parse() methods already in their class
            return new Employment(
                parts[0],
                (SupervisoryLevel)Enum.Parse(typeof(SupervisoryLevel), parts[1]),
                double.Parse(parts[2])
                );
        }

        // The TryParse() method will receive a string and output an instance of Employment via
        // an output parameter.
        // The method will return a boolean value indicating if the action with the method was successful.
        // The action within the method will be to call the .Parse() method.
        // This is the same concept of Parsing primitive datatypes already in c#
        //    bool int.TryParse(text, output var) --> int int.Parse(string)
        public static bool TryParse(string text, out Employment result)
        {
            result = null;
            bool isValid;
            try
            {
                result = Parse(text);
                isValid = true;
            }
            catch (FormatException ex)
            {
                throw new FormatException(ex.Message);
            }
            catch (ArgumentNullException ex)
            {
                throw new ArgumentNullException(ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception($"TryParse Employment: {ex.Message}");
            }

            return isValid;
        }
    }
}
