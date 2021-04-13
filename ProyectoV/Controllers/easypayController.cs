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
    public class easypayController : ApiController
    {
        // GET: api/easypay
        string mensaje_error;
        int numero_error;
        public List<easy_pay> Get()
        {
            List<easy_pay> item_carlist = new easy_pay().cargar_easypay(ref mensaje_error, ref numero_error);
            return item_carlist;
        }

        // GET: api/easypay/5
        public easy_pay Get(int id)
        {
            List<easy_pay> item_carlist = new easy_pay().cargar_easypay(ref mensaje_error, ref numero_error);
            crypting c = new crypting();
            easy_pay x = item_carlist.ElementAt(id);
            easy_pay spes = new easy_pay();
            spes.Num_Cuenta = x.Num_Cuenta;
            spes.Codigo_Seguridad = c.decrypt(x.Codigo_Seguridad);
            spes.Constrasena = c.decrypt(x.Constrasena);
            spes.Fondos = x.Fondos;
            return spes;
        }

        // POST: api/easypay
        public void Post([FromBody]easy_pay value)
        {
            easy_pay account = new easy_pay();
            crypting c = new crypting();
            account.add_account(ref mensaje_error, ref numero_error, value.Num_Cuenta, c.encrypt(value.Codigo_Seguridad), c.encrypt(value.Constrasena), value.Fondos);
        }

        // PUT: api/easypay/5
        public void Put(int id, [FromBody]easy_pay value)
        {
            easy_pay account = new easy_pay();
            crypting c = new crypting();
            account.updatePayment(ref mensaje_error, ref numero_error, value.Num_Cuenta, c.encrypt(value.Codigo_Seguridad), c.encrypt(value.Constrasena), value.Fondos);
        }
    }
}
