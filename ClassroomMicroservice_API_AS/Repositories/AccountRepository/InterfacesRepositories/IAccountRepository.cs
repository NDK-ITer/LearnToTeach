using Microsoft.AspNetCore.Identity;
using MyDemoAPIAsp.NETCore.Models;

namespace MyDemoAPIAsp.NETCore.Repositories.AccountRepository.InterfaceRepositories
{
    public interface IAccountRepository
    {
        public Task<IdentityResult> Register(RegisterModel registerModel);
        public Task<string> Login(LoginModel loginModel);
        //public Task<IdentityResult> Logout();
    }
}
