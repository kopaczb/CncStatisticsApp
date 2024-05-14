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
            ChooseStatisticsInMemoryFromMenuText();
            AddPrograms(true);
            break;
        case "F" or "f":
            ChooseStatisticsTxtFile();
            AddPrograms(false);
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

void AddPrograms(bool isInMemory)
{
    string name = GetValueFromUser("\tPlease insert employee's first name: ");
    string surname = GetValueFromUser("\tPlease insert employee's surname: ");
    string weekNumber = GetValueFromUser("\tPlease insert week number:");
    string year = GetValueFromUser("\tPlease insert year:");
    string workingDays = GetValueFromUser("\tPlease insert number of working day's:");

    bool result = canBeFloat(weekNumber, year, workingDays);
    
    if (!string.IsNullOrEmpty(name) && 
        !string.IsNullOrEmpty(surname) && 
        !string.IsNullOrEmpty(weekNumber) &&
        !string.IsNullOrEmpty(year) &&
        !string.IsNullOrEmpty(workingDays) &&
        result == true)
    {
        IEmployee employee = isInMemory ? new EmployeeInMemory(name, surname, weekNumber, year, workingDays)  
                                        : new EmployeeInFile(name, surname, weekNumber, year, workingDays);

        employee.StatisticsAdded += EmployeeStatisticsAdded;
        DescriptionStatisticsInMemoryText(name, surname, weekNumber, year);

        while (true)
        {
            var input = Console.ReadLine();

            if (input == "q" || input == "Q")
            {
                break;
            }
            try
            {
                employee.AddProgram(input);
            }
            catch (Exception e)
            {
                Console.WriteLine($"Exception catched: {e.Message}");
            }
        }
        employee.ShowStatistics();
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
    Console.WriteLine("Press F:   to display statistics, save data and save statistics in files,");
    Console.WriteLine("Press Q:   to close app.\n");
    Console.WriteLine("\t------------------");
    Console.WriteLine("\tPress M, F or Q:");
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
    Console.WriteLine("   You can only enter: M, F or Q key. Try again:");
    Console.WriteLine("--------------------------------------------------");
}
void ChooseStatisticsInMemoryFromMenuText()
{
    Console.WriteLine("-----------------------------------------------");
    Console.WriteLine("Great! You chose display statistics in memory.");
    Console.WriteLine("\tPlease provide personal data:");
    Console.WriteLine("-----------------------------------------------");
}
void ChooseStatisticsTxtFile()
{
    Console.WriteLine("-----------------------------------------------------------");
    Console.WriteLine("Great! You chose display statistics, save data and save statistics in files.");
    Console.WriteLine("\tPlease provide personal data:");
    Console.WriteLine("-----------------------------------------------------------");
}

void BadPersonalDataInMemoryText()
{
    Console.WriteLine("---------------------------------------------------------------------");
    Console.WriteLine("\tThere is a null value in the data:");
    Console.WriteLine("first name / surname / week number / year / working days,");
    Console.WriteLine("   or no number is given in the following data:");
    Console.WriteLine("\tweek number / year / working days.");
    Console.WriteLine("      Program is unable to calculate statistics.");
    Console.WriteLine("---------------------------------------------------------------------\n");
}

void DescriptionStatisticsInMemoryText(string name, string surname, string weekNumber, string year)
{
    Console.WriteLine("-----------------------------------------");
    Console.WriteLine($"Enter program number between 0 - 6000 ");
    Console.Write($"for {name.ToUpper()} {surname.ToUpper()} in {weekNumber} week / {year}:\n");
    Console.WriteLine("\tor insert Q to exit:");
    Console.WriteLine("-----------------------------------------");
}

bool canBeFloat(string weekNumber, string year, string workingDays)
{
    float weekNumberAsFloat;
    float yearAsFloat;
    float workingDaysAsFloat;
    bool result = false;

    var checkWeekNumber = float.TryParse(weekNumber, out weekNumberAsFloat);
    var checkYear = float.TryParse(year, out yearAsFloat);
    var checkWorkingDays = float.TryParse(workingDays, out workingDaysAsFloat);

    if (checkWeekNumber == true & checkYear == true & checkWorkingDays == true)
    {
        result = true;
    }

    return result;
}