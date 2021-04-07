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
    public class VuelosController : ApiController
    {
        string mensaje_error;
        int numero_error;
        // GET: api/Vuelos
        public List<Vuelos> Get()
        {
            List<Vuelos> listaUser = new Vuelos().GetFlights(ref mensaje_error, ref numero_error);
            return listaUser;
        }

        // GET: api/Vuelos/5
        public Vuelos Get(int id)
        {
            List<Vuelos> listaUser = new Vuelos().GetFlights(ref mensaje_error, ref numero_error);
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

        // POST: api/Vuelos
        public void Post([FromBody]Vuelos value)
        {
            Vuelos flight = new Vuelos();
            crypting c = new crypting();
            flight.createFlight(ref mensaje_error, ref numero_error, value.Codigo_Vuelo, c.encrypt(value.Aerolinea), c.encrypt(value.Cod_Pais_FK), c.encrypt(value.Fecha), c.encrypt(value.Hora), c.encrypt(value.Estado), c.encrypt(value.Cod_Puerta_FK), value.CS,c.encrypt(value.Price), value.UsernameC);
        }

        // PUT: api/Vuelos/5
        public void Put(int id, [FromBody]Vuelos value)
        {
            Vuelos flight = new Vuelos();
            crypting c = new crypting();
            flight.UpdateFlight(ref mensaje_error, ref numero_error, value.Codigo_Vuelo, value.Codigo_Vuelo2, c.encrypt(value.Aerolinea), c.encrypt(value.Cod_Pais_FK), c.encrypt(value.Fecha), c.encrypt(value.Hora), c.encrypt(value.Estado), c.encrypt(value.Cod_Puerta_FK), value.CS, c.encrypt(value.Price), value.UsernameC);
        }

        // DELETE: api/Vuelos/5
        public void Delete(int id)
        {
        }
    }
}
