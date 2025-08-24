namespace ReqnrollProject1.Utils
{
    [Binding]
    public class ArgumentConversion
    {
        [StepArgumentTransformation(@"(\d+) days ago")]
        public DateTime DaysAgo(int daysAgo)
        {
            return DateTime.Today.AddDays(-daysAgo);
        }

        [StepArgumentTransformation(@"(\d+) days time")]
        public DateTime InDaysTime(int daysTime)
        {
            return DateTime.Today.AddDays(daysTime);
        }
    }
}
