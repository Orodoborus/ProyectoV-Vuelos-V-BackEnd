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
    public class ReservasController : ApiController
    {
        // GET: api/Reservas
        string mensaje_error;
        int numero_error;
        public List<Reservas> Get()
        {
            Reservas x = new Reservas();
            List<Reservas> item_carlist = new Reservas().cargar_reserva_especifica(ref mensaje_error, ref numero_error, Reservas.GlobalValueUSER);
            return item_carlist;
        }

        // GET: api/Reservas/5
        public Reservas Get(int id)
        {
            Reservas y = new Reservas();
            List<Reservas> item_carlist = new Reservas().cargar_reserva_especifica(ref mensaje_error, ref numero_error, Reservas.GlobalValueUSER);
            crypting c = new crypting();
            Reservas x = item_carlist.ElementAt(id);
            Reservas spes = new Reservas();
            spes.Cod_Reserva = x.Cod_Reserva;
            spes.Numero_Reservacion = x.Numero_Reservacion;
            spes.Booking_ID = x.Booking_ID;
            spes.Cod_User_FK = c.decrypt(x.Cod_User_FK);
            spes.Cantidad = c.decrypt(x.Cantidad);
            spes.Total = x.Total;
            spes.Payment_Method = c.decrypt(x.Payment_Method);
            spes.FechaReservation = x.FechaReservation;
            return spes;
        }

        // POST: api/Reservas
        public void Post([FromBody] Reservas value)
        {
            Errors b = new Errors();
            Reservas.GlobalValueUSER = b.encrypt(value.Cod_User_FK);
        }

    }
}
