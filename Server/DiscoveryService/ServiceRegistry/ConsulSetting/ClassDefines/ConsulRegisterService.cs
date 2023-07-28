using Consul;
using ConsulSetting.Configurations;
using ConsulSetting.Interfaces;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace ConsulSetting.ClassDefines
{
    public class ConsulRegisterService : IHostedService/*, IConsulRegisterService*/
    {
        private readonly ConsulConfiguration _consulConfiguration;
        private readonly ILogger<ConsulRegisterService> _logger;
        private IConsulClient _consulClient;
        private readonly MenuConfiguration _menuConfiguration;

        public ConsulRegisterService(IConsulClient consulClient, 
            IOptions<MenuConfiguration> menuConfiguration,
            IOptions<ConsulConfiguration> consulConfiguration,
            ILogger<ConsulRegisterService> logger)
        {
            _consulClient = consulClient;
            _menuConfiguration = menuConfiguration.Value;
            _consulConfiguration = consulConfiguration.Value;
            _logger = logger;
        }
        public async Task StartAsync(CancellationToken cancellationToken)
        {
            var menuUri = new Uri(_menuConfiguration.Url);
            var serviceRegistration = new AgentServiceRegistration()
            {
                Address = menuUri.Host,
                Name = _menuConfiguration.ServiceName,
                Port = menuUri.Port,
                ID = _menuConfiguration.ServiceId,
                Tags = new[] {_menuConfiguration.ServiceName}
            };
            await _consulClient.Agent.ServiceDeregister(_menuConfiguration.ServiceId, cancellationToken);
            await _consulClient.Agent.ServiceRegister(serviceRegistration, cancellationToken);
        }

        public async Task StopAsync(CancellationToken cancellationToken)
        {
            try
            {
                await _consulClient.Agent.ServiceDeregister(_menuConfiguration.ServiceId, cancellationToken);

            }
            catch (Exception ex)
            {
                _logger.LogError("Error when register service " + _menuConfiguration.ServiceName,ex);
                throw;
            }
        }
    }
}
