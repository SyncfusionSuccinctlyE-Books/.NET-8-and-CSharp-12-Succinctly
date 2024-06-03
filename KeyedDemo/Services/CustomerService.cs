using KeyedDemo.Interfaces;

namespace KeyedDemo.Services
{
    public class CustomerService
    {
        private readonly IGreeter _greeter;
        public CustomerService([FromKeyedServices("customers")] IGreeter greeter)
        {
            _greeter = greeter;
        }

        public string Greet()
        {
            return _greeter.Greeting("Good day, can I be of service?");
        }
    }
}
