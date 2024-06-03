using KeyedDemo.Interfaces;

namespace KeyedDemo.Services
{
    public class InformalGreeterService : IGreeter
    {
        public string Greeting(string message) => $"Informal greeting: {message}";
    }
}
