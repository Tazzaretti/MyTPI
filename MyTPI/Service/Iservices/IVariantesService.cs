using System.Collections.Generic;
using System.Threading.Tasks;
using Model.DTOs;
using Model.Models;

namespace Service.Iservices
{
    public interface IVariantesService
    {
        List<Variante> GetAllVariantes();
        Variante GetVarianteById(int id);
        Variante CreateVariante(Variante variante);
        Variante UpdateVariante(int id, Variante variante);
        void DeleteVariante(int id);
    }
}