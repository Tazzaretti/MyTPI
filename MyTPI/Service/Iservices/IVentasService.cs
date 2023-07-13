using System.Collections.Generic;
using System.Threading.Tasks;
using Model.Models;

namespace Service.Iservices
{
    public interface IVentasService
    {
        List<Ventas> GetAllVentas();
       Ventas GetVentaById(int id);
        Ventas CreateVenta(Ventas venta);
        Ventas UpdateVenta(int id, Ventas venta);
        void DeleteVenta(int id);
    }
}