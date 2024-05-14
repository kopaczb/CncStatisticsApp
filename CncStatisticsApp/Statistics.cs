namespace StatisticsApp
{
    public class Statistics
    {
        public string WorkingDays { get; private set; }
        public float MinProgram { get; private set; }
        public float MaxProgram { get; private set; }
        public float CountPrograms { get; private set; }
        public float SumPrograms { get; private set; }
        public float AveragePrograms
        {
            get
            {
                float workingDaysAsFloat = float.Parse(WorkingDays);
                return this.CountPrograms / workingDaysAsFloat;
            }
        }
        public Statistics(string workingDays)
        {
            this.WorkingDays = workingDays;
            this.CountPrograms = 0;
            this.MinProgram = float.MaxValue;
            this.MaxProgram = float.MinValue;
        }
        public void AddProgram(float program)
        {
            this.CountPrograms++;
            this.MinProgram = Math.Min(program, this.MinProgram);
            this.MaxProgram = Math.Max(program, this.MaxProgram);
        }
    }
}
