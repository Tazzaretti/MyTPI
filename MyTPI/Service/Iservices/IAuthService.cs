using Model.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Iservices
{
    public interface IAuthService
    {
        string CrearUsuario(CreateUserDTO user);
        string Login(AuthDTO user);
    }
}