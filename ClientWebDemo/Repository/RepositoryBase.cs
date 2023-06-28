using Flurl.Http;
using Flurl.Http.Configuration;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;

namespace ClienWebDemo.Repository
{
    public class RepositoryBase
    {
        protected readonly IFlurlClient _flurlClient;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public RepositoryBase(IFlurlClientFactory flurlClientFactory,
                              IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
            _flurlClient = flurlClientFactory.Get("https://localhost:9000");
            _flurlClient.BeforeCall( async flurlCall =>
            {
                var token = _httpContextAccessor.HttpContext.Request.Cookies[NameToken.NameOfAuthenticateToken];
                if(!string.IsNullOrEmpty(token) )
                {
                    flurlCall.HttpRequestMessage.SetHeader("Authorization", $"bearer {token}");
                }
                else
                {
                    flurlCall.HttpRequestMessage.SetHeader("Authorization", string.Empty);
                }
            }).AfterCall(flurlCall =>
            {
                if (flurlCall.HttpResponseMessage.StatusCode == System.Net.HttpStatusCode.Unauthorized)
                {
                    
                }
            });
        }
    }
}