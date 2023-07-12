using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

        public async Task<List<Ventas>> GetAllVentas()
        {
            return await _dbContext.Ventas.ToListAsync();
        }

        public async Task<Ventas> GetVentaById(int id)
        {
            return await _dbContext.Ventas.FindAsync(id);
        }

        public async Task<Ventas> CreateVenta(Ventas venta)
        {
            _dbContext.Ventas.Add(venta);
            await _dbContext.SaveChangesAsync();
            return venta;
        }

        public async Task<Ventas> UpdateVenta(int id, Ventas venta)
        {
            var existingVenta = await _dbContext.Ventas.FindAsync(id);
            if (existingVenta != null)
            {
                existingVenta.FechaVenta = venta.FechaVenta;
                existingVenta.IdUser = venta.IdUser;
                await _dbContext.SaveChangesAsync();
            }
            return existingVenta;
        }

        public async Task DeleteVenta(int id)
        {
            var venta = await _dbContext.Ventas.FindAsync(id);
            if (venta != null)
            {
                _dbContext.Ventas.Remove(venta);
                await _dbContext.SaveChangesAsync();
            }
        }
    }
}