using Authentication_Service.DTOs.Reponses;
using Authentication_Service.DTOs.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Authentication_Service.Repositories
{
    internal interface IUserRepository
    {
        Task<bool> Register(RegisterRequest registerRequest);
        Task<LoginResponse> Authenticate(string username, string password);
        Task<bool> Update(UpdateRequest updateRequest);
        Task<bool> Lock(string id);
        Task<bool> Unlock(string id);
        Task<bool> IsLock(string id);
    }
}
