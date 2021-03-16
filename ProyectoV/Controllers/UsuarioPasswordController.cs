using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BLL;
using ProyectoV.Models;
using Newtonsoft.Json;


namespace ProyectoV.Controllers
{
    public class UsuarioPasswordController : ApiController
    {
        string mensaje_error;
        int numero_error;
        // GET: api/UsuarioPassword
        public List<Usuario> Get()
        {
            List<Usuario> listaUser = new Usuario().cargar_lista_usuarios(ref mensaje_error, ref numero_error);
            return listaUser;
        }

        // GET: api/UsuarioPassword/5
        public Usuario Get(int id)
        {
            List<Usuario> listaUser = new Usuario().cargar_lista_usuarios(ref mensaje_error, ref numero_error);
            crypting c = new crypting();
            Usuario x = listaUser.ElementAt(id);
            Usuario spes = new Usuario();
            spes.Cod_User = x.Cod_User;
            spes.Username = c.decrypt(x.Username);
            spes.Password = c.decrypt(x.Password);
            spes.Rol = c.decrypt(x.Rol);
            spes.Email = c.decrypt(x.Email);
            spes.Question = c.decrypt(x.Question);
            spes.Answer = c.decrypt(x.Answer);
            return spes;
        }

        // PUT: api/UsuarioPassword/5
        public void Put(int id, [FromBody]Usuario user)
        {
            Usuario update = new Usuario();
            crypting c = new crypting();
            update.updateUserPassword(ref mensaje_error, ref numero_error, c.encrypt(user.Username), c.encrypt(user.Password));
        }

    }
}
