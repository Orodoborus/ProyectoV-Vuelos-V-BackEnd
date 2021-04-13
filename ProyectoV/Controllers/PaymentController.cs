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
    public class PaymentController : ApiController
    {
        // GET: api/Payment
        string mensaje_error;
        int numero_error;
        public List<cards> Get()
        {
            List<cards> item_carlist = new cards().cargar_tarjeta(ref mensaje_error, ref numero_error);
            return item_carlist;
        }

        // GET: api/Payment/5
        public cards Get(int id)
        {
            List<cards> item_carlist = new cards().cargar_tarjeta(ref mensaje_error, ref numero_error);
            crypting c = new crypting();
            cards x = item_carlist.ElementAt(id);
            cards spes = new cards();
            spes.Num_Tarjeta = x.Num_Tarjeta;
            spes.Mes_Exp = c.decrypt(x.Mes_Exp);
            spes.Ano_Exp = c.decrypt(x.Ano_Exp);
            spes.CVV = c.decrypt(x.CVV);
            spes.Monto = x.Monto;
            spes.Tipo = c.decrypt(x.Tipo);
            spes.Card_Type = c.decrypt(x.Card_Type);
            return spes;
        }

        // POST: api/Payment
        public void Post([FromBody]cards value)
        {
            cards cart = new cards();
            crypting c = new crypting();
            cart.add_card(ref mensaje_error, ref numero_error, value.Num_Tarjeta, c.encrypt(value.Mes_Exp), c.encrypt(value.Ano_Exp), c.encrypt(value.CVV), value.Monto, c.encrypt(value.Tipo), c.encrypt(value.Card_Type));
        }

        // PUT: api/Payment/5
        public void Put(int id, [FromBody]cards value)
        {
            cards cart = new cards();
            crypting c = new crypting();
            cart.updatePayment(ref mensaje_error, ref numero_error, value.Num_Tarjeta, c.encrypt(value.Mes_Exp), c.encrypt(value.Ano_Exp), c.encrypt(value.CVV), value.Monto, c.encrypt(value.Tipo), c.encrypt(value.Card_Type),
                value.Codigo_Compras, c.encrypt(value.Cod_User_FK), c.encrypt(value.Codigo_Vuelo_FK), c.encrypt(value.Cantidad), c.encrypt(value.Total));
        }

    }
}
