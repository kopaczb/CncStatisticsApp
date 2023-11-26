using static StatisticsApp.EmployeeBase;
using StatisticsApp;

namespace StatisticsApp
{
    public class EmployeeInFile : EmployeeBase
    {
        public override event StatisticsAddedDelegated StatisticsAdded;
        private string fileName;
        private List<float> programs = new List<float>();
        public EmployeeInFile(string name, string surname, string weekNumber)
                : base(name, surname, weekNumber)
        {
            this.fileName = fileName = $"{Name}_{surname}_{weekNumber}.txt";
        }

        public override void AddProgram(float program)
        {
            if (program >= 3000 && program <= 4000)
            {
                using (var writer = File.AppendText(fileName))
                {
                    writer.WriteLine(program);

                    if (StatisticsAdded != null)
                    {
                        StatisticsAdded(this, new EventArgs());
                    }
                }
            }
            else
            {
                throw new Exception("Invalid program value.");
            }
        }

        public override void AddProgram(int program)
        {
            float programAsFloat = program;
            this.AddProgram(programAsFloat);
        }
        public override void AddProgram(double program)
        {
            float programAsFloat = (float)program;
            this.AddProgram(programAsFloat);
        }
        public override void AddProgram(string program)
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
        public override Statistics GetStatistics()
        {
            var statisticsFromFile = this.ReadStatisticsFromFile();
            var result = this.CountStatistics(statisticsFromFile);
            return result;
        }
        private List<float> ReadStatisticsFromFile()
        {
            var programs = new List<float>();

            if (File.Exists($"{fileName}"))
            {
                using (var reader = File.OpenText($"{fileName}"))
                {
                    var line = reader.ReadLine();
                    while (line != null)
                    {
                        var program = float.Parse(line);
                        programs.Add(program);
                        line = reader.ReadLine();
                    }
                }
            }
            return programs;
        }
        private Statistics CountStatistics(List<float> programs)
        {
            //float WorkingDaysInFloat = float.Parse(WorkingDays); 

            var statistics = new Statistics();

            foreach (var program in programs)
            {
                statistics.AddProgram(program);
            }
            return statistics;
        }
    }
}