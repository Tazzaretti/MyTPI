using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.ViewModels
{
    public class UserViewModel
    {
        public int IdRol { get; set; }
        public string? Nombre { get; set; }
        public string ?Apellido { get; set; }
        public string ?Mail { get; set; }
        public string ?Clave { get; set; }
        
    }
}
