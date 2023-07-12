using System.Collections.Generic;
using System.Threading.Tasks;
using Model.Models;

namespace Service.Iservices
{
    public interface IVentasService
    {
        Task<List<Ventas>> GetAllVentas();
        Task<Ventas> GetVentaById(int id);
        Task<Ventas> CreateVenta(Ventas venta);
        Task<Ventas> UpdateVenta(int id, Ventas venta);
        Task DeleteVenta(int id);
    }
}