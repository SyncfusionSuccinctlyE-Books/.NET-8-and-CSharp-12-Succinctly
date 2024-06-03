using KeyedDemo.Interfaces;

namespace KeyedDemo.Services
{
    public class FormalGreeterService : IGreeter
    {
        public string Greeting(string message) => $"Formal greeting: {message}";
    }
}
