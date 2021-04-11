using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BLL;
using Newtonsoft.Json;
using ProyectoV.Models;

namespace ProyectoV.Controllers
{
    public class CarritoController : ApiController
    {
        // GET: api/Carrito
        string mensaje_error;
        int numero_error;
        public List<Carrito> Get()
        {
            List<Carrito> item_carlist = new Carrito().cargar_carrito(ref mensaje_error, ref numero_error);
            return item_carlist;
        }

        // GET: api/Carrito/5
        public Carrito Get(int id)
        {
            List<Carrito> item_carlist = new Carrito().cargar_carrito(ref mensaje_error, ref numero_error);
            crypting c = new crypting();
            Carrito x = item_carlist.ElementAt(id);
            Carrito spes = new Carrito();
            spes.Cod_Item = x.Cod_Item;
            spes.Codigo_Vuelo = x.Codigo_Vuelo;
            spes.Pais = c.decrypt(x.Pais);
            spes.Precio = c.decrypt(x.Precio);
            return spes;
        }

        // POST: api/Carrito
        public void Post([FromBody]Carrito value)
        {
            Carrito cart = new Carrito();
            crypting c = new crypting();
            cart.add_cartItem(ref mensaje_error, ref numero_error, Carrito.GlobalValueIDCART = Carrito.GlobalValueIDCART + 1, value.Codigo_Vuelo, c.encrypt(value.Pais), c.encrypt(value.Precio));
        }

        // DELETE: api/Carrito/5
        public void Delete(int id)
        {
            List<Carrito> listaUser = new Carrito().cargar_carrito(ref mensaje_error, ref numero_error);
            Carrito x = listaUser.ElementAt(id);
            Carrito delete = new Carrito();
            delete.deleteCartItem(ref mensaje_error, ref numero_error, Convert.ToInt32(x.Cod_Item));
        }
    }
}
