using System.Collections.Generic;
using System.Threading.Tasks;
using Model.Models;

namespace Service.Iservices
{
    public interface IVariantesService
    {
        Task<List<Variante>> GetAllVariantes();
        Task<Variante> GetVarianteById(int id);
        Task<Variante> CreateVariante(Variante variante);
        Task<Variante> UpdateVariante(int id, Variante variante);
        Task DeleteVariante(int id);
    }
}