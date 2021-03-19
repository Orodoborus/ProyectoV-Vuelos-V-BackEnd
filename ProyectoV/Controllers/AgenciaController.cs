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
    public class AgenciaController : ApiController
    {
        string mensaje_error;
        int numero_error;
        // GET: api/Agencia
        public List<Agencia> Get()
        {
            List<Agencia> airlineList = new Agencia().getAgencias(ref mensaje_error, ref numero_error);
            return airlineList;
        }

        // GET: api/Agencia/5
        public Agencia Get(int id)
        {
            List<Agencia> airlineList = new Agencia().getAgencias(ref mensaje_error, ref numero_error);
            crypting c = new crypting();
            Agencia x = airlineList.ElementAt(id);
            Agencia spes = new Agencia();
            spes.Cod_Agencia = x.Cod_Agencia;
            spes.Nombre_Agencia = c.decrypt(x.Nombre_Agencia);
            spes.Imagen = c.decrypt(x.Imagen);
            spes.Cod_Pais_FK = x.Cod_Pais_FK;
            spes.Cod_Aerolinea = c.decrypt(x.Cod_Aerolinea);
            return spes;
        }

        // POST: api/Agencia
        public void Post([FromBody]Agencia airline)
        {
            Agencia agency = new Agencia();
            crypting c = new crypting();

            agency.createAirline(ref mensaje_error, ref numero_error, Agencia.GlobalValue = Agencia.GlobalValue + 1, c.encrypt(airline.Nombre_Agencia), c.encrypt(airline.Imagen), airline.Cod_Pais_FK, c.encrypt(airline.Cod_Aerolinea));
        }

        // PUT: api/Agencia/5
        public void Put(int id, [FromBody] Agencia airline)
        {
            Agencia agency = new Agencia();
            crypting c = new crypting();
            agency.update_airline(ref mensaje_error, ref numero_error, airline.Cod_Agencia, c.encrypt(airline.Nombre_Agencia), c.encrypt(airline.Imagen), airline.Cod_Pais_FK, c.encrypt(airline.Cod_Aerolinea));
        }

        // DELETE: api/Agencia/5
        public void Delete(int id)
        {
        }
    }
}
