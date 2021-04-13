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
    public class reservationdetailsController : ApiController
    {
        // GET: api/reservationdetails
        string mensaje_error;
        int numero_error;
        public List<reservation_details> Get()
        {
            List<reservation_details> item_carlist = new reservation_details().cargar_reserva_especifica(ref mensaje_error, ref numero_error, reservation_details.GlobalValueBUYCODE, reservation_details.GlobalValueUSER);
            return item_carlist;
        }

        // GET: api/reservationdetails/5
        public reservation_details Get(int id)
        {
            List<reservation_details> item_carlist = new reservation_details().cargar_reserva_especifica(ref mensaje_error, ref numero_error, reservation_details.GlobalValueBUYCODE, reservation_details.GlobalValueUSER);
            crypting c = new crypting();
            reservation_details x = item_carlist.ElementAt(id);
            reservation_details spes = new reservation_details();
            spes.Booking_ID = x.Booking_ID;
            spes.Cod_User = c.decrypt(x.Cod_User);
            spes.Cod_Vuelo = c.decrypt(x.Cod_Vuelo);
            spes.Pais = c.decrypt(x.Pais);
            spes.Precio = c.decrypt(x.Precio);
            return spes;
        }

        // POST: api/reservationdetails
        public void Post([FromBody] reservation_details value)
        {
            Errors b = new Errors();
            reservation_details.GlobalValueBUYCODE = value.Booking_ID;
            reservation_details.GlobalValueUSER = b.encrypt(value.Cod_User);
        }
    }
}
