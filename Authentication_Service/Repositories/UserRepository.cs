using Authentication_Service.DTOs.Reponses;
using Authentication_Service.DTOs.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Authentication_Service.Repositories
{
    public class UserRepository : IUserRepository
    {
        public Task<LoginResponse> Authenticate(string username, string password)
        {
            throw new NotImplementedException();
        }

        public Task<bool> IsLock(string id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Lock(string id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Register(RegisterRequest registerRequest)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Unlock(string id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Update(UpdateRequest updateRequest)
        {
            throw new NotImplementedException();
        }
    }
}
