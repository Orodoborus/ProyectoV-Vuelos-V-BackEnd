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
    public class PuertaController : ApiController
    {
        string mensaje_error;
        int numero_error;
        // GET: api/Puerta
        public List<Puerta> Get()
        {
            List<Puerta> gateList = new Puerta().getGates(ref mensaje_error, ref numero_error);
            return gateList;
        }

        // GET: api/Puerta/5
        public Puerta Get(int id)
        {
            List<Puerta> gateList = new Puerta().getGates(ref mensaje_error, ref numero_error);
            crypting c = new crypting();
            Puerta x = gateList.ElementAt(id);
            Puerta spes = new Puerta();
            spes.Cod_Puerta = x.Cod_Puerta;
            spes.Numero_Puerta = c.decrypt(x.Numero_Puerta);
            spes.Detalle = c.decrypt(x.Detalle);
            return spes;
        }

        // POST: api/Puerta
        public void Post([FromBody]Puerta gate)
        {
            Puerta puerta = new Puerta();
            crypting c = new crypting();
            puerta.createGate(ref mensaje_error, ref numero_error, gate.Cod_Puerta, c.encrypt(gate.Numero_Puerta), c.encrypt(gate.Detalle));
        }

        // PUT: api/Puerta/5
        public void Put(int id, [FromBody] Puerta gate)
        {
            Puerta puerta = new Puerta();
            crypting c = new crypting();
            puerta.updateGate(ref mensaje_error, ref numero_error, gate.Cod_Puerta, gate.Cod_Puerta2, c.encrypt(gate.Numero_Puerta), c.encrypt(gate.Detalle));
        }

        // DELETE: api/Puerta/5
        public void Delete(int id,[FromBody] Puerta gate)
        {
            Puerta puerta = new Puerta();
            crypting c = new crypting();
            puerta.delete_gate(ref mensaje_error, ref numero_error, gate.Cod_Puerta);
        }
    }
}
