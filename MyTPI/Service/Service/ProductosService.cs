using System.Collections.Generic;
using System.Linq;
using Model.DTOs;
using Model.Models;
using Microsoft.EntityFrameworkCore;
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

        public List<ProductoDTOs> GetAllProductos()
        {
            return _dbContext.Productos
                .Select(p => new ProductoDTOs
                {
                    IdProducto = p.IdProducto,
                    Producto = p.Producto,
                    Descripcion = p.Descripcion,
                    Precio = p.Precio
                })
                .ToList();
        }

        public ProductoDTOs GetProductoById(int id)
        {
            return _dbContext.Productos
                .Where(p => p.IdProducto == id)
                .Select(p => new ProductoDTOs
                {
                    IdProducto = p.IdProducto,
                    Producto = p.Producto,
                    Descripcion = p.Descripcion,
                    Precio = p.Precio
                })
                .FirstOrDefault();
        }

        public ProductoDTOs CreateProducto(Productos producto)
        {
            _dbContext.Productos.Add(producto);
            _dbContext.SaveChanges();

            return new ProductoDTOs
            {
                IdProducto = producto.IdProducto,
                Producto = producto.Producto,
                Descripcion = producto.Descripcion,
                Precio = producto.Precio
            };
        }

        public ProductoDTOs UpdateProducto(int id, Productos producto)
        {
            var existingProducto = _dbContext.Productos.Find(id);
            if (existingProducto != null)
            {
                existingProducto.Producto = producto.Producto;
                existingProducto.Descripcion = producto.Descripcion;
                existingProducto.Precio = producto.Precio;
                _dbContext.SaveChanges();
            }
            return new ProductoDTOs
            {
                IdProducto = existingProducto.IdProducto,
                Producto = existingProducto.Producto,
                Descripcion = existingProducto.Descripcion,
                Precio = existingProducto.Precio
            };
        }

        public void DeleteProducto(int id)
        {
            var producto = _dbContext.Productos.Find(id);
            if (producto != null)
            {
                _dbContext.Productos.Remove(producto);
                _dbContext.SaveChanges();
            }
        }
    }
}