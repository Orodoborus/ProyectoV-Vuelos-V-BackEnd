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
    public class newBuyHistoryController : ApiController
    {
        string mensaje_error;
        int numero_error;
        // POST: api/newBuyHistory
        public void Post([FromBody]Compras value)
        {
            Compras newbuy = new Compras();
            Errors b = new Errors();
            newbuy.new_buy(ref mensaje_error, ref numero_error, value.Codigo_Compras, b.encrypt(value.Cod_User_FK), value.Cantidad, value.Total);
        }
    }
}
