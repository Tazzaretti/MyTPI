using System.Collections.Generic;
using System.Threading.Tasks;
using Model.DTOs;
using Model.Models;

namespace Service.Iservices
{
    public interface IProductosService
    {
        List<ProductoDTOs> GetAllProductos();
        ProductoDTOs GetProductoById(int id);
        ProductoDTOs CreateProducto(Productos producto);
        ProductoDTOs UpdateProducto(int id, Productos producto);
        void DeleteProducto(int id);
    }
}