using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.DTOs
{
    public class ProductoDTOs
    {
        public int IdProducto { get; set; }
        public string Producto { get; set; }
        public string Descripcion { get; set; }
        public decimal Precio { get; set; }
    }
}
