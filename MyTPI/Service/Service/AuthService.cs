﻿using System;
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
using Model.ViewModels;

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

      

        public string CrearUsuario(UserViewModel user)
        {
             if (string.IsNullOrEmpty(user.Mail))
            {
                return "Ingrese un usuario";
            }

            Users? existingUser = _eccomerceDBContext.Users.FirstOrDefault(x => x.Mail == user.Mail);

            if (existingUser != null)
            {
                return "Usuario existente";
            }

            Users newUser = new Users()
            {
                IdRol = user.IdRol,
                Nombre = user.Nombre,
                Apellido = user.Apellido,
                Clave = user.Clave.GetSHA256(),
                Mail = user.Mail

            };

            _eccomerceDBContext.Users.Add(newUser);
            _eccomerceDBContext.SaveChanges();

            string response = GetToken(_eccomerceDBContext.Users.OrderBy(x => x.IdUser).Last());
            return response;
        }

        public string Login(AuthDTO user)
        {
            Users? existingUser = _eccomerceDBContext.Users.FirstOrDefault(x => x.Mail == user.Mail && x.Clave == user.Clave.GetSHA256());

            if (existingUser == null)
            {
                return string.Empty;
            }

            return GetToken(existingUser);
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
                        new Claim("AdminType", user.IdRol.ToString())
                    }),
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            return tokenHandler.WriteToken(tokenHandler.CreateToken(tokenDescriptor));
        }
    }
}