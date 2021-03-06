using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BLL;
using Newtonsoft.Json;

namespace ProyectoV.Controllers
{
    public class UsuarioController : ApiController
    {
        string mensaje_error;
        int numero_error;
        // GET: api/Usuario
        public List<Usuario> Get()
        {
            List<Usuario> listaUser =  new Usuario().cargar_lista_usuarios(ref mensaje_error, ref numero_error);
            return listaUser;
        }

        // GET: api/Usuario/5
        public Usuario Get(int id)
        {
            List<Usuario> listaUser = new Usuario().cargar_lista_usuarios(ref mensaje_error, ref numero_error);
            Usuario x = listaUser.ElementAt(id);
            return x;
        }

        // POST: api/Usuario
        public void Post([FromBody]Usuario user)
        {
            Usuario create = new Usuario();
            create.crearUser(ref mensaje_error, ref numero_error, user.Cod_User, user.Username,user.Password,user.Rol);
        }

        // PUT: api/Usuario/5
        public void Put(int id, [FromBody]Usuario value)
        {
        }

        // DELETE: api/Usuario/5
        public void Delete(int id)
        {

            List<Usuario> listaUser = new Usuario().cargar_lista_usuarios(ref mensaje_error, ref numero_error);
            Usuario x = listaUser.ElementAt(id);
            Usuario delete = new Usuario();
            delete.deleteUser(ref mensaje_error, ref numero_error, x.Cod_User);
        }
    }
}
