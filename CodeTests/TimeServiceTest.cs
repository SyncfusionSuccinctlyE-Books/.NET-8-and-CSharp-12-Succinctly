using WebApiStuff.Services;

namespace CodeTests
{
    [TestClass]
    public class TimeServiceTest
    {
        public class TimeProviderMorning : TimeProvider
        {
            private readonly DateTimeOffset _utc;

            public TimeProviderMorning() => _utc = DateTimeOffset.UtcNow; 

            public override DateTimeOffset GetUtcNow() => new(_utc.Year, _utc.Month, _utc.Day, _utc.Hour, _utc.Minute, _utc.Second, TimeSpan.Zero);

            public override TimeZoneInfo LocalTimeZone => TimeZoneInfo.FindSystemTimeZoneById("Pacific Standard Time"); // China Standard Time    Pacific Standard Time
        }

        [TestMethod]
        public void CanMorningServiceRun()
        {
            var timeProviderMorning = new TimeProviderMorning();
            var timeService = new TimeService(timeProviderMorning);
            var canRunMorningTasks = timeService.RunMorningTasks();

            Assert.IsTrue(canRunMorningTasks);
        }
    }
}