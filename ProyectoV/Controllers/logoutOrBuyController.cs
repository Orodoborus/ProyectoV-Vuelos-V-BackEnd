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
    public class logoutOrBuyController : ApiController
    {
        string mensaje_error;
        int numero_error;
        // DELETE: api/logoutOrBuy/5
        public void Delete(int id)
        {
            Carrito myCart = new Carrito();
            myCart.deleteCartItems(ref mensaje_error, ref numero_error);
        }
    }
}
