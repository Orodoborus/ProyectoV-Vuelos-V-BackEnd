using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BLL;
using Newtonsoft.Json;

namespace ProyectoV.Controllers
{
    public class AgenciaController : ApiController
    {
        // GET: api/Agencia
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Agencia/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Agencia
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Agencia/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Agencia/5
        public void Delete(int id)
        {
        }
    }
}
