using KeyedDemo.Interfaces;

namespace KeyedDemo.Services
{
    public class FriendsService
    {
        private readonly IServiceProvider _serviceProvider;
        public FriendsService(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public string Greet()
        {
            return _serviceProvider.GetRequiredKeyedService<IGreeter>("friends").Greeting("Hello buddy!");
        }
    }
}
