using Application.Features.Login;
using Application.Features.Register;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileStore.Application.Interfaces
{
    public interface IUserRepository: IAsyncRepository<User>
    {
        Task<string> LoginAsync(UserLogin userLogin);
        Task<string> RegisterAsync(NewUser newUser);

    }
}
