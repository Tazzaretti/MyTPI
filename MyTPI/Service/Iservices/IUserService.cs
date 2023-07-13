using System.Collections.Generic;
using System.Threading.Tasks;
using Model.DTOs;
using Model.Models;

namespace Service.Iservices
{
    public interface IUserService
    {
        List<UserDTO> GetAll();
        UserDTO GetUserById(int id);
        CreateUser UpdateUser(CreateUser user);
        void DeleteUser(int id);
    }
}