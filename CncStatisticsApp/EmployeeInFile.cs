using static StatisticsApp.EmployeeBase;
using StatisticsApp;

namespace StatisticsApp
{
    public class EmployeeInFile : EmployeeBase
    {
        public override event StatisticsAddedDelegated StatisticsAdded;
        private string fileName;
        private string fileNameWithResult;
        private List<float> programs = new List<float>();
        public EmployeeInFile(string name, string surname, string weekNumber, string year, string workingDays)
                : base(name, surname, weekNumber, year, workingDays)
        {
            this.fileName = fileName = $"{Name}_{surname}_{weekNumber}_{year}.txt";
            this.fileNameWithResult = fileNameWithResult = $"{Name}_{surname}_{weekNumber}_{year}_result.txt";
        }

        public override void AddProgram(float program)
        {
            if (program >= 0 && program <= 6000)
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
        public override Statistics GetStatistics()
        {
            var statisticsFromFile = this.ReadStatisticsFromFile();
            var result = this.CountStatistics(statisticsFromFile);
            AddResultToTxtFile(result);
            return result;
        }

        private void AddResultToTxtFile(Statistics result)
        {
                using (var writer = File.CreateText(fileNameWithResult))
                {
                    writer.WriteLine("-----------------------------------------------");
                    writer.WriteLine($"\tStatistics from the week: {WeekNumber} / {Year}");
                    writer.WriteLine($"\t\tfor {Name.ToUpper()} {Surname.ToUpper()}");
                    writer.WriteLine("-----------------------------------------------");
                    writer.WriteLine($"{WorkingDays}    - \tworking day's");
                    writer.WriteLine($"{result.MinProgram} - \tthe smallest value of program number");
                    writer.WriteLine($"{result.MaxProgram} - \tthe highest value of program number");
                    writer.WriteLine($"{result.CountPrograms}    - \tprogram count");
                    writer.WriteLine($"{result.AveragePrograms:N1}  - \taverage nr of programs [program / day]");
                    writer.WriteLine("-----------------------------------------------");
                }
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
            var statistics = new Statistics(this.WorkingDays);

            foreach (var program in programs)
            {
                statistics.AddProgram(program);
            }
            return statistics;
        }
    }
}