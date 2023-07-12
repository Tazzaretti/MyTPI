using Model.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.Models;
namespace Service.Iservices
{
    public interface IUserSerivice
    {
      List<UserDTO> getAll();
        CreateUser getUserById(int id);
      void DeleteUsers (int id);
        
    }
}
