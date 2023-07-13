using System.Collections.Generic;
using System.Threading.Tasks;
using Model.DTOs;

namespace Service.Iservices
{
    public interface IEnviosService
    {
        Task<List<EnvioDTO>> GetAllEnvios();
        Task<EnvioDTO> GetEnvioById(int id);
        Task<EnvioDTO> CreateEnvio(EnvioDTO envio);
        Task<EnvioDTO> UpdateEnvio(int id, EnvioDTO envio);
        Task DeleteEnvio(int id);
    }
}