using static StatisticsApp.EmployeeBase;
using StatisticsApp;
using System.Runtime.CompilerServices;

namespace StatisticsApp
{
    public class EmployeeInMemory : EmployeeBase
    {
        public override event StatisticsAddedDelegated StatisticsAdded;
        private List<float> programs = new List<float>();

        public EmployeeInMemory(string name, string surname, string weekNumber, string year, string workingDays)
                : base(name, surname, weekNumber, year, workingDays)
        {
        }

        public override void AddProgram(float program)
        {
            if (program >= 0 && program <= 6000)
            {
                this.programs.Add(program);

                if (StatisticsAdded != null)
                {
                    StatisticsAdded(this, new EventArgs());
                }
            }
            else
            {
                throw new Exception("Invalid program value.");
            }
        }
        public override Statistics GetStatistics()
        {
            var statistics = new Statistics(this.WorkingDays);

            foreach (var program in this.programs)
            {
                statistics.AddProgram(program);
            }
            return statistics;
        }
    }
}
