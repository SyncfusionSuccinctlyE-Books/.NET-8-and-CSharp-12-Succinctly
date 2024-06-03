namespace PrimaryConstructorsDemo.Services
{
    public class RandomCityService : IRandomCityService
    {
        private static readonly string[] Cities = new[]
        {
            "New York", "Los Angeles", "Chicago", "Houston", "Phoenix", "Philadelphia", "San Antonio", "San Diego", "Dallas", "San Jose",
            "Austin", "Jacksonville", "Fort Worth", "Columbus", "Charlotte", "Indianapolis", "San Francisco", "Seattle", "Denver", "Washington"
        };

        public string GetRandomCity()
        {

            Random.Shared.Shuffle(Cities);
            var city = Random.Shared.GetItems<string>(Cities, 1);
            
            return city[0];
        }
    }

    public interface IRandomCityService
    {
        string GetRandomCity();
    }
}
