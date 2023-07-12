using System.Collections.Generic;
using System.Threading.Tasks;
using Model.Models;

namespace Service.Iservices
{
    public interface IUserService
    {
        Task<List<Users>> GetAllUsers();
        Task<Users> GetUserById(int id);
        Task<Users> CreateUser(Users user);
        Task<Users> UpdateUser(int id, Users user);
        Task DeleteUser(int id);
    }
}