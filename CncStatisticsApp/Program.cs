using StatisticsApp;

GreetingInMenuText();

bool CloseApp = false;
while (!CloseApp)
{
    OptionInMenuText();
    var employeeInput = Console.ReadLine();

    switch (employeeInput)
    {
        case "M" or "m":
            ChoseStatisticsInMemoryFromMenuText();
            AddProgramsToMemory();
            break;
        case "F" or "f":
            ChoseStatisticsTxtFile();
            AddProgramsToTxtFile();
            break;
        case "Q" or "q":
            GoodbyeInMenuText();
            CloseApp = true;
            break;
        default:
            BadChoiceInMenuText();
            continue;
    }
}
void AddProgramsToMemory()
{
    string name = GetValueFromUser("\tPlease insert employee's first name: ");
    string surname = GetValueFromUser("\tPlease insert employee's surname: ");
    string weekNumber = GetValueFromUser("\tPlease insert week number:");

    if (!string.IsNullOrEmpty(name) && !string.IsNullOrEmpty(surname) && !string.IsNullOrEmpty(weekNumber))
    {
        var employeeInMemory = new EmployeeInMemory(name, surname, weekNumber);

        employeeInMemory.StatisticsAdded += EmployeeStatisticsAdded;
        DescriptionStatisticsInMemoryText(name, surname, weekNumber);

        while (true)
        {
            var input = Console.ReadLine();

            if (input == "q" || input == "Q")
            {
                break;
            }
            try
            {
                employeeInMemory.AddProgram(input);
            }
            catch (Exception e)
            {
                Console.WriteLine($"Exception catched: {e.Message}");
            }
        }
        employeeInMemory.ShowStatistics();
    }
    else
    {
        BadPersonalDataInMemoryText();
    }
}

void AddProgramsToTxtFile()
{
    string name = GetValueFromUser("\tPlease insert employee's first name: ");
    string surname = GetValueFromUser("\tPlease insert employee's surname: ");
    string weekNumber = GetValueFromUser("\tPlease insert week number:");

    if (!string.IsNullOrEmpty(name) && !string.IsNullOrEmpty(surname) && !string.IsNullOrEmpty(weekNumber))
    {
        var employeeInFile = new EmployeeInFile(name, surname, weekNumber);

        employeeInFile.StatisticsAdded += EmployeeStatisticsAdded;
        DescriptionStatisticsInMemoryText(name, surname, weekNumber);

        while (true)
        {
            var input = Console.ReadLine();

            if (input == "q" || input == "Q")
            {
                break;
            }
            try
            {
                employeeInFile.AddProgram(input);
            }
            catch (Exception e)
            {
                Console.WriteLine($"Exception catched: {e.Message}");
            }
        }
        employeeInFile.ShowStatistics();
    }
    else
    {
        BadPersonalDataInMemoryText();
    }
}

static string GetValueFromUser(string input)
{
    Console.WriteLine(input);
    string userInput = Console.ReadLine();
    return userInput;
}

static void EmployeeStatisticsAdded(object sender, EventArgs args)
{
    Console.WriteLine("\tProgram number added corretly");
}
void GreetingInMenuText()
{
    Console.WriteLine("\t----------------------------");
    Console.WriteLine("\tWelcome in CncStatisticsApp!");
    Console.WriteLine("\t----------------------------");
}
void OptionInMenuText()
{
    Console.WriteLine("Press M:   to display statistics in memory,");
    Console.WriteLine("Press F:   to display and save statistics in file,");
    Console.WriteLine("Press Q:   to close app.\n");
    Console.WriteLine("\t------------------");
    Console.WriteLine("\tPress M or F or Q:");
    Console.WriteLine("\t------------------\n");
}

void GoodbyeInMenuText()
{
    Console.WriteLine("\n\n   ------------------------------------");
    Console.WriteLine("    Thanks for using CncStatisticsApp!");
    Console.WriteLine("   ------------------------------------\n\n\n\n");
}
void BadChoiceInMenuText()
{
    Console.WriteLine("--------------------------------------------------");
    Console.WriteLine("   You can only enter: M or F or Q key. Try again:");
    Console.WriteLine("--------------------------------------------------");
}
void ChoseStatisticsInMemoryFromMenuText()
{
    Console.WriteLine("-----------------------------------------------");
    Console.WriteLine("Great! You chose display statistics in memory.");
    Console.WriteLine("\tPlease provide personal data:");
    Console.WriteLine("-----------------------------------------------");
}
void ChoseStatisticsTxtFile()
{
    Console.WriteLine("-----------------------------------------------------------");
    Console.WriteLine("Great! You chose display statistics and saving in txt file.");
    Console.WriteLine("\tPlease provide personal data:");
    Console.WriteLine("-----------------------------------------------------------");
}

void BadPersonalDataInMemoryText()
{
    Console.WriteLine("-------------------------------------------------------------------------------------------");
    Console.WriteLine("First name or surname or week number is null, the program is unable to calculate statistics");
    Console.WriteLine("-------------------------------------------------------------------------------------------");
}

static void DescriptionStatisticsInMemoryText(string name, string surname, string weekNumber)
{
    Console.WriteLine("-----------------------------------------");
    Console.WriteLine($"\nEnter program number between 3500 - 4000 ");
    Console.Write($"     ");
    Console.Write($"for {name.ToUpper()} {surname.ToUpper()} in {weekNumber} week:\n");
    Console.WriteLine("\tor insert Q to exit:");
    Console.WriteLine("-----------------------------------------");
}