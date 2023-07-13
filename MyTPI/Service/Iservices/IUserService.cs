using System.Collections.Generic;
using Model.DTOs;

namespace Service.Iservices
{
    public interface IUserService
    {
        List<UserDTO> GetAll();
        UserDTO GetUserById(int id);
        UserDTO UpdateUser(CreateUser user);
        void DeleteUser(int id);
    }
}