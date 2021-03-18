using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ProyectoV.Models;
using BLL;
using Newtonsoft.Json;

namespace ProyectoV.Controllers
{
    public class ConsecutivosUpdateController : ApiController
    {
        string mensaje_error;
        int numero_error;
        // GET: api/ConsecutivosUpdate
        public List<Consecutivos> Get()
        {
            List<Consecutivos> listaConsecutivos = new Consecutivos().getAllCons(ref mensaje_error, ref numero_error);
            return listaConsecutivos;
        }

        // GET: api/ConsecutivosUpdate/5
        public Consecutivos Get(int id)
        {
            List<Consecutivos> listaConsecutivos = new Consecutivos().getAllCons(ref mensaje_error, ref numero_error);
            crypting c = new crypting();
            Consecutivos x = listaConsecutivos.ElementAt(id);
            Consecutivos spes = new Consecutivos();
            spes.Codigo_Consecutivo = x.Codigo_Consecutivo;
            spes.Descripcion = c.decrypt(x.Descripcion);
            spes.Valor = c.decrypt(x.Valor);
            spes.Prefijo = c.decrypt(x.Prefijo);
            spes.Rango_Ini = c.decrypt(x.Rango_Ini);
            spes.Rango_Fin = c.decrypt(x.Rango_Fin);
            return spes;
        }

        // PUT: api/ConsecutivosUpdate/5
        public void Put(int id, [FromBody] Consecutivos cons)
        {
            Consecutivos x = new Consecutivos();
            crypting c = new crypting();
            int valor = Convert.ToInt32(cons.Valor) + 1;
            x.updateSpecificCons(ref mensaje_error, ref numero_error, c.encrypt(cons.Descripcion), c.encrypt(valor.ToString()));
        }

    }
}
