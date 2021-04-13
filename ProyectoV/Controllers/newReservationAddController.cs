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
    public class newReservationAddController : ApiController
    {
        // GET: api/newReservationAdd
        string mensaje_error;
        int numero_error;

        // POST: api/newReservationAdd
        public void Post([FromBody]Reservas value)
        {
            Reservas newReservation = new Reservas();
            Errors b = new Errors();
            newReservation.new_reservation(ref mensaje_error, ref numero_error, value.Cod_Reserva, value.Numero_Reservacion,value.Booking_ID,b.encrypt(value.Cod_User_FK),
                b.encrypt(value.Cantidad),value.Total,b.encrypt(value.Payment_Method));
        }

    }
}
