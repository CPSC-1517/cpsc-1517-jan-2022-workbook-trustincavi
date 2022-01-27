// See https://aka.ms/new-console-template for more information

using PracticeConcosle.Data;

DisplayString("Hello, World!");

// Fully qualified name(space)
Employment Job = CreateJob();
ResidentAddress Address = CreateAddress();

//create a Person
Person Me = CreatePerson(Job, Address);

// Review: Class & Object
//if (Me != null)
//    DisplayPerson(Me);


// Review: Array
ArrayReview(Me);




static void DisplayString(string text)
{
    Console.WriteLine(text);
}

static void DisplayPerson(Person person)
{
    DisplayString($"{person.FirstName} {person.LastName}");
    DisplayString($"{person.Address.ToString()}");

    // In our example, the constructor always ensures that the EmploymentPositions is declared and not null
    // but in other cases, you want to make sure that it's not null
    if (person.EmploymentPositions != null)
    {
        //foreach (var emp in person.EmploymentPositions)
        //{
        //    DisplayString($"{emp.ToString()}");
        //}

        // We can use index for List<T>
        // it can be manipulated as an array
        for (int i = 0; i < person.EmploymentPositions.Count; i++)
        {
            DisplayString(person.EmploymentPositions[i].ToString());
        }
    }
    
}

Employment CreateJob()
{
    Employment Job = null;
    // a reference to a variable capable of holding an instance of Employment
    // its initial value will be null

    try
    {
        Job = new Employment();
        DisplayString($"Default good job {Job.ToString()}");

        // checking expections
        Job = new Employment("Boss", SupervisoryLevel.Supervisor, 5.5);
        DisplayString($"Greedy good job {Job.ToString()}");

        // bad data: title
        //Job = new Employment("", SupervisoryLevel.Supervisor, 5.5);

        // bad data: negative year
        Job = new Employment("Boss", SupervisoryLevel.Supervisor, -5.5);
    }
    catch (ArgumentException ex) // specific exception message
    {
        DisplayString(ex.Message);
    }
    catch (Exception ex) // general catch all
    {
        DisplayString($"Run time error: {ex.Message}.");
    }

    return Job;
}

ResidentAddress CreateAddress()
{
    ResidentAddress Address = new ResidentAddress();
    DisplayString($"Default Address {Address.ToString()}");

    Address = new ResidentAddress(10767, "106 St NW", null, null, "Edmonton", "AB");
    DisplayString($"Greedy Address {Address}"); // default is ToString()

    return Address;
}

Person CreatePerson(Employment job, ResidentAddress address)
{
    List<Employment> Jobs = new List<Employment>();
    Person thePerson = null;
    try
    {
        //create a good person using greedy constructor no job list
        //thePerson = new Person("DonNoJob", "Welch", null, address);

        //create a good person using greedy constructor with an empty job list
        //thePerson = new Person("DonEmptyJob", "Welch", Jobs, address);

        //create a good person using greedy constructor with a job list

        Jobs.Add(new Employment("worker", SupervisoryLevel.TeamMember, 2.1));
        Jobs.Add(new Employment("leader", SupervisoryLevel.TeamLeader, 7.8));
        Jobs.Add(job);
        thePerson = new Person("DonWithJobs", "Welch", address, Jobs);

        //esception testing
        // no first name
        //thePerson = new Person(null, "Welch", Jobs, address);
        // no second name
        //thePerson = new Person("DonWithJobs", null, Jobs, address);


        //can i change the firstname using an assignment statement
        //the FirstName is a private set.
        //you are NOT allowed to use a private set on the receiving side
        //  of an assignment statement.
        //THIS WILL NOT COMPILE
        //thePerson.FirstName = "NewName";

        //can i use a behaviour (method) to change the contents of a private
        //  set property?
        thePerson.ChangeName("Lowand", "Behold");

        //can I add another job after the person instance was created
        thePerson.AddEmployment(new("DP IT", SupervisoryLevel.DepartmentHead, 0.8));
        //thePerson.AddEmployment(new Employment("DP IT", SupervisoryLevel.DepartmentHead, 0.8));

        //change I change the public field Address directly
        ResidentAddress oldAddress = thePerson.Address;
        oldAddress.City = "Vancover";
        thePerson.Address = oldAddress;
    }
    catch (ArgumentException ex)  //specific exception message
    {
        DisplayString(ex.Message);
    }
    catch (Exception ex)  //general catch all 
    {
        DisplayString("Run time error: " + ex.Message);
    }
    return thePerson;
}

void ArrayReview(Person person)
{
    int[] array1 = new int[5];
    PrintArray(array1, 5, "declare int array size 5");

    int[] array2 = new int[] { 1, 2, 4, 8, 16};
    PrintArray(array2, 5, "declare array using a list of supplied values");

    // alternate syntax
    // .count() is a method inherited from IEnumerable
    // .Length is a read-only property (just has a get{}) of Array class 
    int[] array3 = { 2, 4, 6, 8, 10 };
    PrintArray(array3, array3.Count(), "declare array using a list of supplied values");

    // logical counter for your array size to indicate the "valid meaningful" values for processing
    int lsarray1 = 0;
    int lsarray2 = array2.Count(); // IEnumerable method
    int lsarray3 = array3.Length; // Array's read-only property

    Random random = new Random();
    int randomvalue = 0;
    while (lsarray1 < array1.Length)
    {
        randomvalue = random.Next(0, 100);
        array1[lsarray1] = randomvalue;
        lsarray1++;
    }
    PrintArray(array1, lsarray1, "array load with random value");

    // Alter an element randomly selected to a new value
    int arrayPosition = random.Next(0, array1.Length);
    randomvalue = random.Next(0, 100);
    array1[arrayPosition] = randomvalue;
    PrintArray(array1, lsarray1, "randomly replace an array value");

    // Remove an element value from an array
    // move all array element in position greater than the removed element position, "up one"
    // assume we are removing element 3 (index 2)
    int logicalElementNumber = 3;
    for (int index = --logicalElementNumber; index < array1.Length-1; index++)
    {
        array1[index] = array1[index + 1];
    }
    array1[array1.Length - 1] = 0;
    PrintArray(array1, array1.Length, "randomly remove an array value");
}

void PrintArray(int[] array, int size, string text)
{
    Console.WriteLine($"\n{text}\n");

    foreach (var item in array)
    {
        Console.Write($"{item},");
    }
    Console.WriteLine("\n");
}