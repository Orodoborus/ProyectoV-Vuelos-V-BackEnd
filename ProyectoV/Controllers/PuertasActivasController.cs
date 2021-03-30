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
    public class PuertasActivasController : ApiController
    {
        string mensaje_error;
        int numero_error;
        // GET: api/PuertasActivas
        public List<Puerta> Get()
        {
            List<Puerta> gateList = new Puerta().getFilteredGates(ref mensaje_error, ref numero_error, Puerta.GlobalValueDetail);
            return gateList;
        }

        // GET: api/PuertasActivas/5
        public Puerta Get(int id)
        {
            List<Puerta> gateList = new Puerta().getFilteredGates(ref mensaje_error, ref numero_error, Puerta.GlobalValueDetail);
            crypting c = new crypting();
            Puerta x = gateList.ElementAt(id);
            Puerta spes = new Puerta();
            spes.Cod_Puerta = x.Cod_Puerta;
            spes.Numero_Puerta = c.decrypt(x.Numero_Puerta);
            spes.Detalle = c.decrypt(x.Detalle);
            return spes;
        }

        // POST: api/PuertasActivas
        public void Post([FromBody]Puerta value)
        {
            Puerta.GlobalValueDetail = value.Detalle;
        }

    }
}
