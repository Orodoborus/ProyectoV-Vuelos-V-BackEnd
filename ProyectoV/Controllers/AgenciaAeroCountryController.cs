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
    public class AgenciaAeroCountryController : ApiController
    {
        string mensaje_error;
        int numero_error;
        // GET: api/AgenciaAeroCountry
        public List<Pais> Get()
        {
            List<Pais> countryList = new Pais().getAllCountries(ref mensaje_error, ref numero_error);
            return countryList;
        }

        //GET: api/AgenciaAeroCountry/5
        public Pais Get(int id)
        {
            List<Pais> countryList = new Pais().getAllCountries(ref mensaje_error, ref numero_error);
            crypting c = new crypting();
            Pais x = countryList.ElementAt(id);
            Pais spes = new Pais();
            spes.Cod_Pais = x.Cod_Pais;
            spes.Nombre_Pais = c.decrypt(x.Nombre_Pais);
            spes.Imagen = c.decrypt(x.Imagen);
            return spes;
        }

        // POST: api/AgenciaAeroCountry
        public void Post([FromBody]Pais value)
        {
            Pais.GlobalValue = value.Cod_Pais;
        }

    }
}
