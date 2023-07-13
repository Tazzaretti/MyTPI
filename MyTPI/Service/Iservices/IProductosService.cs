using System.Collections.Generic;
using System.Threading.Tasks;
using Model.DTOs;

namespace Service.Iservices
{
    public interface IProductosService
    {
        Task<List<ProductoDTO>> GetAllProductos();
        Task<ProductoDTO> GetProductoById(int id);
        Task<ProductoDTO> CreateProducto(ProductoDTO producto);
        Task<ProductoDTO> UpdateProducto(int id, ProductoDTO producto);
        Task DeleteProducto(int id);
    }
}