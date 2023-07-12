using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Service.Iservices;
using Model.DTOs;
using Model.Models;
using Model.Helper;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.Extensions.Options;
using Service.Helper;

namespace Service.Service
{
    public class AuthSerivce : IAuthService
    {
        private readonly eccomerceDBContext _eccomerceDBContext;
        private readonly AppSettings _appSettings;

        public AuthSerivce(eccomerceDBContext eccomerceDBContext, IOptions<AppSettings> appSettings)
        {
            _eccomerceDBContext = eccomerceDBContext;
            _appSettings = appSettings.Value;
        }

        public string CrearUsuario(CreateUser User)
        {

            if (string.IsNullOrEmpty(User.Mail))
            {
                return "Ingrese un usuario";
            }

            Users? user = _eccomerceDBContext.Users.FirstOrDefault(x => x.Mail == User.Mail);

            if (user != null)
            {
                return "Usuario existente";
            }

            _eccomerceDBContext.Add(new Users
            {
                IdRol = User.IdRol,
                Nombre = User.Nombre,
                Apellido = User.Apellido,
                Clave = User.Clave.GetSHA256(),
                Mail = User.Mail,
                IdUser = User.IdUser,
            }) ;
            _eccomerceDBContext.SaveChanges();

            string response = GetToken(_eccomerceDBContext.Users.OrderBy(x => x.IdUser).Last());
            return response;

        }
           

        public string Login(AuthDTO User)
        {
            Users? user = _eccomerceDBContext.Users.FirstOrDefault(x => x.Mail == User.Mail && x.Clave == User.Clave);

            if (user == null)
            {
                return string.Empty;
            }

            return GetToken(user);
        }

        private string GetToken(Users user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Key);
            var tokenDescriptor = new SecurityTokenDescriptor()
            {
                Subject = new ClaimsIdentity(
                    new Claim[]
                    {
                        new Claim(ClaimTypes.NameIdentifier, user.IdUser.ToString()),
                        new Claim(ClaimTypes.Email, user.Mail),
                        new Claim(ClaimTypes.Role, _eccomerceDBContext.Rol.First(x => x.IdRol == user.IdRol).UserType)
                    }),
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            return tokenHandler.WriteToken(tokenHandler.CreateToken(tokenDescriptor));
        }
    }
}


 

