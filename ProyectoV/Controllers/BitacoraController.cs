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
    public class BitacoraController : ApiController
    {
        string mensaje_error;
        int numero_error;


        // GET: api/Bitacora
        public List<Bitacora> Get()
        {
            List<Bitacora> bitacoras = new Bitacora().GetBitacoras(ref mensaje_error, ref numero_error);
            return bitacoras;
        }

        // GET: api/Bitacora/5
        public Bitacora Get(int id)
        {
            List<Bitacora> bitacoras = new Bitacora().GetBitacoras(ref mensaje_error, ref numero_error);
            crypting c = new crypting();
            Bitacora x = bitacoras.ElementAt(id);
            Bitacora spes = new Bitacora();
            spes.Cod_Registro = x.Cod_Registro;
            spes.Cod_User_FK = x.Cod_User_FK;
            spes.FechaTime = c.decrypt(x.FechaTime);
            spes.Tipo = c.decrypt(x.Tipo);
            spes.Time = c.decrypt(x.Time);
            spes.Cod_Regis = x.Cod_Regis;
            spes.Descripcion = c.decrypt(x.Descripcion);
            spes.RegistroDetalle = c.decrypt(x.RegistroDetalle);
            return spes;
        }
        // POST: api/Bitacora
        public void Post([FromBody] Bitacora bitacora)
        {
            Bitacora bitacora1 = new Bitacora();
            crypting c = new crypting();
            bitacora1.CreateBitacora(ref mensaje_error, ref numero_error, bitacora.Cod_Registro, bitacora.Cod_User_FK, c.encrypt(bitacora.FechaTime), c.encrypt(bitacora.Tipo), c.encrypt(bitacora.Time),
                bitacora.Cod_Regis, c.encrypt(bitacora.Descripcion), c.encrypt(bitacora.RegistroDetalle));
        }

        //// PUT: api/Bitacora/5
        //public void Put(int id, [FromBody] Bitacora bitacora)
        //{
        //    Bitacora bitacora1 = new Bitacora();
        //    crypting c = new crypting();
        // //   bitacora1.updateBitacora(ref mensaje_error, ref numero_error, gate.Cod_Puerta, gate.Cod_Puerta2, c.encrypt(gate.Numero_Puerta), c.encrypt(gate.Detalle));
        //}

        //// DELETE: api/Bitacora/5
        //public void Delete(int id, [FromBody] Bitacora bitacora)
        //{
        //    Bitacora bitacora1 = new Bitacora();
        //    crypting c = new crypting();
        //   // bitacora1.deleteBitacora(ref mensaje_error, ref numero_error, bitacora1.Cod_Registro);
        //}
    }
}
