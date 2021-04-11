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
    public class VuelosYArriboController : ApiController
    {
        // GET: api/VuelosYArribo
        string mensaje_error;
        int numero_error;
        public List<Vuelos> Get()
        {
            List<Vuelos> listaUser = new Vuelos().GetFlightsYArribo(ref mensaje_error, ref numero_error);
            return listaUser;
        }

        // GET: api/VuelosYArribo/5
        public Vuelos Get(int id)
        {
            List<Vuelos> listaUser = new Vuelos().GetFlightsYArribo(ref mensaje_error, ref numero_error);
            crypting c = new crypting();
            Vuelos x = listaUser.ElementAt(id);
            Vuelos spes = new Vuelos();
            spes.Codigo_Vuelo = x.Codigo_Vuelo;
            spes.Aerolinea = c.decrypt(x.Aerolinea);
            spes.Cod_Pais_FK = c.decrypt(x.Cod_Pais_FK);
            spes.Fecha = c.decrypt(x.Fecha);
            spes.Hora = c.decrypt(x.Hora);
            spes.Estado = c.decrypt(x.Estado);
            spes.Cod_Puerta_FK = c.decrypt(x.Cod_Puerta_FK);
            spes.CS = x.CS;
            spes.Price = c.decrypt(x.Price);
            return spes;
        }
    }
}
