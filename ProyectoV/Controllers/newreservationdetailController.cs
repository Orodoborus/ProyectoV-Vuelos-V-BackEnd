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
    public class newreservationdetailController : ApiController
    {
        string mensaje_error;
        int numero_error;
        // POST: api/newreservationdetail
        public void Post([FromBody]reservation_details value)
        {
            reservation_details cd = new reservation_details();
            Errors b = new Errors();
            cd.add_new_detail(ref mensaje_error, ref numero_error, value.Booking_ID, b.encrypt(value.Cod_User), b.encrypt(value.Cod_Vuelo), b.encrypt(value.Pais), b.encrypt(value.Precio));
        }
    }
}
