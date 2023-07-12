using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Model.Models;
using Service.Iservices;

namespace Service.Service
{
    public class ProductosService : IProductosService
    {
        private readonly eccomerceDBContext _dbContext;

        public ProductosService(eccomerceDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Productos>> GetAllProductos()
        {
            return await _dbContext.Productos.ToListAsync();
        }

        public async Task<Productos> GetProductoById(int id)
        {
            return await _dbContext.Productos.FindAsync(id);
        }

        public async Task<Productos> CreateProducto(Productos producto)
        {
            _dbContext.Productos.Add(producto);
            await _dbContext.SaveChangesAsync();
            return producto;
        }

        public async Task<Productos> UpdateProducto(int id, Productos producto)
        {
            var existingProducto = await _dbContext.Productos.FindAsync(id);
            if (existingProducto != null)
            {
                existingProducto.Producto = producto.Producto;
                existingProducto.Descripcion = producto.Descripcion;
                existingProducto.Precio = producto.Precio;
                await _dbContext.SaveChangesAsync();
            }
            return existingProducto;
        }

        public async Task DeleteProducto(int id)
        {
            var producto = await _dbContext.Productos.FindAsync(id);
            if (producto != null)
            {
                _dbContext.Productos.Remove(producto);
                await _dbContext.SaveChangesAsync();
            }
        }
    }
}