using StatisticsApp;

namespace StatisticsApp
{
    public abstract class EmployeeBase : IEmployee
    {
        public delegate void StatisticsAddedDelegated(object sender, EventArgs args);
        public abstract event StatisticsAddedDelegated StatisticsAdded;
        public EmployeeBase(string name, string surname, string weekNumber, string year, string workingDays)
        {
            this.Name = name;
            this.Surname = surname;
            this.WeekNumber = weekNumber;
            this.Year = year;
            this.WorkingDays = workingDays;

        }
        public string Name { get; private set; }
        public string Surname { get; private set; }
        public string WeekNumber { get; private set; }
        public string Year { get; private set; }
        public string WorkingDays { get; private set; }
        public abstract void AddProgram(float program);
        public abstract Statistics GetStatistics();
        public void AddProgram(int program)
        {
            float programAsFloat = program;
            this.AddProgram(programAsFloat);
        }
        public void AddProgram(double program)
        {
            float programAsFloat = (float)program;
            this.AddProgram(programAsFloat);
        }
        public void AddProgram(string program)
        {
            if (float.TryParse(program, out float programAsFloat))
            {
                this.AddProgram(programAsFloat);
            }
            else
            {
                throw new Exception("String is not float");
            }
        }
        public void ShowStatistics()
        {
            var stat = GetStatistics();
            if (stat.CountPrograms != 0)
            {
                Console.WriteLine("\n\n-----------------------------------------------");
                Console.WriteLine($"\tStatistics from the week: {WeekNumber} / {Year}");
                Console.WriteLine($"\t\tfor {Name.ToUpper()} {Surname.ToUpper()}");
                Console.WriteLine("-----------------------------------------------");
                Console.WriteLine($"{WorkingDays}    - \tworking day's");
                Console.WriteLine($"{stat.MinProgram} - \tthe smallest value of program number");
                Console.WriteLine($"{stat.MaxProgram} - \tthe highest value of program number");
                Console.WriteLine($"{stat.CountPrograms}    - \tprogram count");
                Console.WriteLine($"{stat.AveragePrograms:N1}  - \taverage nr of programs [program / day]");
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
