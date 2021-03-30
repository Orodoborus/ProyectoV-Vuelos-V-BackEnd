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
    public class FilteredAgencyController : ApiController
    {
        string mensaje_error;
        int numero_error;
        // GET: api/FilteredAgency
        public List<Agencia> Get()
        {
            List<Agencia> agency = new Agencia().getFilteredAgencias(ref mensaje_error, ref numero_error, Agencia.GlobalValueCountry);
            return agency;
        }

        // GET: api/FilteredAgency/5
        public Agencia Get(int id)
        {
            List<Agencia> airlineList = new Agencia().getFilteredAgencias(ref mensaje_error, ref numero_error, Agencia.GlobalValueCountry);
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

        // POST: api/FilteredAgency
        public void Post([FromBody]Agencia value)
        {
            Agencia.GlobalValueCountry = value.Cod_Pais_FK;
        }

    }
}
