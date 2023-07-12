using System.Collections.Generic;
using System.Threading.Tasks;
using Model.Models;

namespace Service.Iservices
{
    public interface IProductosService
    {
        Task<List<Productos>> GetAllProductos();
        Task<Productos> GetProductoById(int id);
        Task<Productos> CreateProducto(Productos producto);
        Task<Productos> UpdateProducto(int id, Productos producto);
        Task DeleteProducto(int id);
    }
}