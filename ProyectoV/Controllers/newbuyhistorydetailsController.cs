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
    public class newbuyhistorydetailsController : ApiController
    {
        string mensaje_error;
        int numero_error;


        // POST: api/newbuyhistorydetails
        public void Post([FromBody]Compras_details value)
        {
            Compras_details cd = new Compras_details();
            cd.add_new_detail(ref mensaje_error, ref numero_error, value.Codigo_Compra, value.Codigo_User, value.Codigo_Vuelo, value.Pais, value.Precio);
        }

    }
}
