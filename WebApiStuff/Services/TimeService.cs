namespace WebApiStuff.Services
{
    public class TimeService
    {
        private readonly TimeProvider _timeProvider;

        public TimeService(TimeProvider timeProvider) => _timeProvider = timeProvider;

        public bool RunMorningTasks()
        {
            var currentTime = _timeProvider.GetLocalNow();
            return currentTime.Hour <= 11;
        }
    }
}















