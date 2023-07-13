using System.Collections.Generic;
using System.Threading.Tasks;
using Model.DTOs;

namespace Service.Iservices
{
    public interface IEnviosService
    {
        List<EnvioDTOs> GetAllEnvios();
        EnvioDTOs GetEnvioById(int id);
        EnvioDTOs CreateEnvio(EnvioDTOs envio);
        EnvioDTOs UpdateEnvio(int id, EnvioDTOs envio);
        public void DeleteEnvio(int id);
    }
}