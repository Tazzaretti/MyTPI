using System.Collections.Generic;
using System.Threading.Tasks;
using Model.Models;

namespace Service.Iservices
{
    public interface IEnviosService
    {
        Task<List<Envios>> GetAllEnvios();
        Task<Envios> GetEnvioById(int id);
        Task<Envios> CreateEnvio(Envios envio);
        Task<Envios> UpdateEnvio(int id, Envios envio);
        Task DeleteEnvio(int id);
    }
}