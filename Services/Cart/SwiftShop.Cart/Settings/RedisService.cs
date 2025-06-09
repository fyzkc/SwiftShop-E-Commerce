using StackExchange.Redis;

namespace SwiftShop.Cart.Settings
{
    public class RedisService
    {
        private readonly string _host;
        private readonly int _port;
        private ConnectionMultiplexer _connectionMultiplexer;
        public RedisService(string host, int port)
        {
            _host = host;
            _port = port;
        }

        public void Connect() => _connectionMultiplexer = ConnectionMultiplexer.Connect($"{_host}:{_port}");
        public IDatabase GetDb(int db = 1)
        {
            if (_connectionMultiplexer == null)
                throw new InvalidOperationException("Redis connection failed.");
            return _connectionMultiplexer.GetDatabase(db);
        }
    }
}
