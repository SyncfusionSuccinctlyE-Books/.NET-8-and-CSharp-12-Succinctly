namespace WebApiStuff.Services
{
    public class TaskRunnerService
    {
        private readonly TimeProvider _timeProvider;
        public TaskRunnerService(TimeProvider timeProvider) => _timeProvider = timeProvider;


        public TimeSpan MorningTaskRunner()
        {
            var startTime = _timeProvider.GetTimestamp();

            Task.Delay(5000).Wait();

            var endTime = _timeProvider.GetTimestamp();

            var duration = _timeProvider.GetElapsedTime(startTime, endTime);
                        
            return duration;
        }
    }
}
