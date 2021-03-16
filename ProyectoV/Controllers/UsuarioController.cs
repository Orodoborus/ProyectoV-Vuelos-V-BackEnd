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
    
    public class UsuarioController : ApiController
    {
        string mensaje_error;
        int numero_error;
        int x = Usuario.GlobalValue;
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

        // POST: api/Usuario
        public void Post([FromBody]Usuario user)
        {
            Usuario create = new Usuario();
            crypting c = new crypting();
            create.crearUser(ref mensaje_error, ref numero_error, Usuario.GlobalValue = Usuario.GlobalValue + 1, c.encrypt(user.Username), c.encrypt(user.Password),c.encrypt("User"), c.encrypt(user.Email), c.encrypt(user.Question),c.encrypt(user.Answer));
        }

        // PUT: api/Usuario/5
        public void Put(int id, [FromBody]Usuario user)
        {
            Usuario update = new Usuario();
            crypting c = new crypting();
            update.updateUser(ref mensaje_error, ref numero_error, c.encrypt(user.Username), c.encrypt(user.Rol));
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
