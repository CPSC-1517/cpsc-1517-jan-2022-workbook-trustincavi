// See https://aka.ms/new-console-template for more information

using PracticeConcosle.Data;

DisplayString("Hello, World!");

// Fully qualified name(space)
Employment job = CreateJob();
ResidentAddress Address = CreateAddress();

static void DisplayString(string text)
{
    Console.WriteLine(text);
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