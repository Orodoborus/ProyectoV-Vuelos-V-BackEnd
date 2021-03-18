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
    public class PaisController : ApiController
    {
        string mensaje_error;
        int numero_error;
        // GET: api/Pais
        public List<Pais> Get()
        {
            List<Pais> countryList = new Pais().getAllCountries(ref mensaje_error, ref numero_error);
            return countryList;
        }

        // GET: api/Pais/5
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

        // POST: api/Pais
        public void Post([FromBody]Pais country)
        {
            Pais pais = new Pais();
            crypting c = new crypting();
            pais.create_country(ref mensaje_error, ref numero_error, country.Cod_Pais, c.encrypt(country.Nombre_Pais), c.encrypt(country.Imagen));
        }

        // PUT: api/Pais/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Pais/5
        public void Delete(int id)
        {
        }
    }
}
