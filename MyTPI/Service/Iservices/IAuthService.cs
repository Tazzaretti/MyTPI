using Model.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.ViewModels;

namespace Service.Iservices
{
    public interface IAuthService
    {
        string CrearUsuario(UserViewModel user);
        string Login(AuthDTO user);

    }
}