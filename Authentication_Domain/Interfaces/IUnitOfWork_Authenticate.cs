using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Authentication_Domain.Interfaces
{
    public interface IUnitOfWork_Authenticate : IDisposable
    {
        IUserRepository User { get; }
        IRoleRepository Role { get; }
        int SaveChange();
    }
}
