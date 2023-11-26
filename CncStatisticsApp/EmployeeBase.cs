using StatisticsApp;

namespace StatisticsApp
{
    public abstract class EmployeeBase : IEmployee
    {
        public delegate void StatisticsAddedDelegated(object sender, EventArgs args);
        public abstract event StatisticsAddedDelegated StatisticsAdded;
        public EmployeeBase(string name, string surname, string weekNumber)
        {
            this.Name = name;
            this.Surname = surname;
            this.WeekNumber = weekNumber;
        }
        public string Name { get; private set; }
        public string Surname { get; private set; }
        public string WeekNumber { get; private set; }
        public abstract void AddProgram(float program);
        public abstract void AddProgram(int program);
        public abstract void AddProgram(double program);
        public abstract void AddProgram(string program);
        public abstract Statistics GetStatistics();
        public void ShowStatistics()
        {
            var stat = GetStatistics();
            if (stat.countPrograms != 0)
            {
                Console.WriteLine("\n\n-----------------------------------------------");
                Console.WriteLine($"\tStatistics from the week: {WeekNumber} / 2023");
                Console.WriteLine($"\t\tfor {Name.ToUpper()} {Surname.ToUpper()}");
                Console.WriteLine("-----------------------------------------------");
                Console.WriteLine($"{stat.minProgram} - \tthe smallest value of program number");
                Console.WriteLine($"{stat.maxProgram} - \tthe highest value of program number");
                Console.WriteLine($"{stat.countPrograms}    - \tprogram count");
                Console.WriteLine($"{stat.averagePrograms:N1}  - \taverage nr of programs [program / day]");
                Console.WriteLine("-----------------------------------------------");
            }
            else
            {
                Console.WriteLine("\n---------------------------------");
                Console.WriteLine($"There is no data for calculations");
                Console.WriteLine("---------------------------------");
            }
        }

    }
}
