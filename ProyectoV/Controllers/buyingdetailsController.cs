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
    public class buyingdetailsController : ApiController
    {
        // GET: api/buyingdetails
        string mensaje_error;
        int numero_error;
        public List<Compras_details> Get()
        {
            List<Compras_details> item_carlist = new Compras_details().cargar_compra_especifica(ref mensaje_error, ref numero_error, Compras_details.GlobalValueBUYCODE, Compras_details.GlobalValueUSER);
            return item_carlist;
        }

        // GET: api/buyingdetails/5
        public Compras_details Get(int id)
        {
            List<Compras_details> item_carlist = new Compras_details().cargar_compra_especifica(ref mensaje_error, ref numero_error, Compras_details.GlobalValueBUYCODE, Compras_details.GlobalValueUSER);
            crypting c = new crypting();
            Compras_details x = item_carlist.ElementAt(id);
            Compras_details spes = new Compras_details();
            spes.Codigo_Compra = x.Codigo_Compra;
            spes.Codigo_User = c.decrypt(x.Codigo_User);
            spes.Pais = c.decrypt(x.Pais);
            spes.Precio = c.decrypt(x.Precio);
            return spes;
        }

        // POST: api/buyingdetails
        public void Post([FromBody]Compras_details value)
        {
            Compras_details.GlobalValueBUYCODE = value.Codigo_Compra;
            Compras_details.GlobalValueUSER = value.Codigo_User;
        }

    }
}
