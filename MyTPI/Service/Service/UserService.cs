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
            _context.Users.Remove(_context.Users.Single(f => f.IdUser == id));
            _context.SaveChanges();
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
            return _mapper.Map<UserDTO>(_context.Users.Where(x => x.IdUser == id).First());
        }

        public CreateUser UpdateUser(CreateUser user)
        {
            Users userDataBase = _context.Users.Single(x => x.IdUser == user.IdUser);
            userDataBase.Nombre = user.Nombre;
            userDataBase.IdRol = _context.Users.First(x => x.IdRol == user.IdRol).IdRol;
            _context.SaveChanges();

            var lastempleado = _context.Users.OrderBy(x => x.IdUser).Last();

            return _mapper.Map<CreateUser>(lastempleado);

        }
    }
}
