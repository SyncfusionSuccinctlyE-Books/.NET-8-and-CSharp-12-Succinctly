namespace KeyedDemo.Common
{
    public static partial class Log
    {
        [LoggerMessage(Level = LogLevel.Information, Message = "Message: {message}")]
        public static partial void Write(ILogger logger, string message);
        
    }
}
