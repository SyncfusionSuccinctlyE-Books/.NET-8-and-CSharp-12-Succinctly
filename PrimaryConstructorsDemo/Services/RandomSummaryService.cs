namespace PrimaryConstructorsDemo.Services
{
    public class RandomSummaryService : IRandomSummaryService
    {

        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        public string GetRandomSummary()
        {
            Random.Shared.Shuffle(Summaries);
            var summary = Random.Shared.GetItems<string>(Summaries, 1);

            return summary[0];
        }
    }

    public interface IRandomSummaryService
    {
        string GetRandomSummary();
    }
}
