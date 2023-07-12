using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Model.DTOs;
using Model.Models;
using Service.Iservices;
using Service.Mappings;
using Model.Enum;

namespace Service.Service
{
    public class UserSerivice:IUserSerivice
    {
        private readonly eccomerceDBContext _context;
        private readonly IMapper _mapper;
        
        public UserSerivice(eccomerceDBContext context)
        {
            _mapper = AutoMapperConfig.Configure();
            _context = context;
        }

        
        public  List<UserDTO> getAll()
        {
            List<UserDTO> users = (from Users in _context.Users
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

        public void DeleteUsers(int id)
        {
            _context.Users.Remove(_context.Users.Single(f => f.IdUser == id));
            _context.SaveChanges();
        }

        public CreateUser getUserById(int id)
        {
            return _mapper.Map<CreateUser>(_context.Users.Where(x => x.IdUser== id).First());

        }
    }
}
