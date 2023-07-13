using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Model.Models;
using Service.Iservices;

namespace Service.Service
{
    public class VentasService : IVentasService
    {
        private readonly eccomerceDBContext _dbContext;

        public VentasService(eccomerceDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<Ventas> GetAllVentas()
        {
            return _dbContext.Ventas.ToList();
        }

        public Ventas GetVentaById(int id)
        {
            return _dbContext.Ventas.Find(id);
        }

        public Ventas CreateVenta(Ventas venta)
        {
            _dbContext.Ventas.Add(venta);
            _dbContext.SaveChanges();
            return venta;
        }

        public Ventas UpdateVenta(int id, Ventas venta)
        {
            var existingVenta = _dbContext.Ventas.Find(id);
            if (existingVenta != null)
            {
                existingVenta.FechaVenta = venta.FechaVenta;
                existingVenta.IdUser = venta.IdUser;
                _dbContext.SaveChanges();
            }
            return existingVenta;
        }

        public void DeleteVenta(int id)
        {
            var venta = _dbContext.Ventas.Find(id);
            if (venta != null)
            {
                _dbContext.Ventas.Remove(venta);
                _dbContext.SaveChanges();
            }
        }
    }
}