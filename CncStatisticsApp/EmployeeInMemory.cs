using static StatisticsApp.EmployeeBase;
using StatisticsApp;

namespace StatisticsApp
{
    public class EmployeeInMemory : EmployeeBase
    {
        public override event StatisticsAddedDelegated StatisticsAdded;
        private List<float> programs = new List<float>();

        public EmployeeInMemory(string name, string surname, string weekNumber)
                : base(name, surname, weekNumber)
        {
        }

        public override void AddProgram(float program)
        {
            if (program >= 3000 && program <= 4000)
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
            var statistics = new Statistics();

            foreach (var program in this.programs)
            {
                statistics.AddProgram(program);
            }
            return statistics;
        }
    }
}
