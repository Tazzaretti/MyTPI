﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace MyTest.Models
{
    public partial class Users
    {
        public Users()
        {
            Ventas = new HashSet<Ventas>();
        }

        public int IdUser { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Mail { get; set; }
        public string Clave { get; set; }
        public int IdRol { get; set; }

        public virtual Rol IdRolNavigation { get; set; }
        public virtual ICollection<Ventas> Ventas { get; set; }
    }
}