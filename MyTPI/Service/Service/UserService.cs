﻿using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Model.DTOs;
using Model.Models;
using Service.Iservices;
using Service.Mappings;
using Model.Enum;

namespace Service.Service
{
    public class UserSerivice : IUserService
    {
        private readonly eccomerceDBContext _context;
        private readonly IMapper _mapper;

        public UserSerivice(eccomerceDBContext context)
        {
            _mapper = AutoMapperConfig.Configure();
            _context = context;
        }

        public void DeleteUser(int id)
        {
            var user = _context.Users.Find(id);
            if (user != null)
            {
                _context.Users.Remove(user);
                _context.SaveChanges();
            }
        }

        public List<UserDTO> GetAll()
        {
            var users = (from Users in _context.Users
                         join Rol in _context.Rol
                         on Users.IdRol equals Rol.IdRol
                         select new UserDTO()
                         {
                             Nombre = Users.Nombre,
                             IdUser = Users.IdUser,
                             UserType = Rol.UserType

                         }).ToList();
            return users;
        }

        public UserDTO GetUserById(int id)
        {
            var user = _context.Users.FirstOrDefault(x => x.IdUser == id);
            return _mapper.Map<UserDTO>(user);
        }

        public CreateUser UpdateUser(CreateUser user)
        {
            var existingUser = _context.Users.FirstOrDefault(x => x.IdUser == user.IdUser);
            if (existingUser != null)
            {
                existingUser.Nombre = user.Nombre;
                existingUser.IdRol = _context.Users.First(x => x.IdRol == user.IdRol).IdRol;
                _context.SaveChanges();
            }

            var lastUser = _context.Users.OrderBy(x => x.IdUser).Last();
            return _mapper.Map<CreateUser>(lastUser);
        }
    }
}