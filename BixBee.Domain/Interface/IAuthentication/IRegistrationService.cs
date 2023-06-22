using BixBee.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BixBee.Domain.Interface.IAuthentication
{
    public interface IRegistrationService
    {
        Task<Result> Registration(RegistrationModel user);
        Task<Result> Login(LoginModel user);
    }
}
