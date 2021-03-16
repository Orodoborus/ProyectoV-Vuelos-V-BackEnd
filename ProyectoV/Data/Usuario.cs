using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProyectoV.Data
{
    public class Usuario
    {

        public Usuario()
        {
                
        }

        public int Cod_User { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Rol { get; set; }
        public string Email { get; set; }
        public string Question { get; set; }
        public string Answer { get; set; }
    }
}