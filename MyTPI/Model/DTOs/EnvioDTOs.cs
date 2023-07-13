using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.DTOs
{
    public class EnvioDTOs
    {
        public int IdEnvio { get; set; }
        public string Destino { get; set; }
        public string EstadoEnvio { get; set; }
        public int IdProducto { get; set; }
        public int IdVenta { get; set; }
    }
}
