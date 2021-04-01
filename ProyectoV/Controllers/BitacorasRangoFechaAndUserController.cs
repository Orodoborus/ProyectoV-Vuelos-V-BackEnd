﻿using System;
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
    public class BitacorasRangoFechaAndUserController : ApiController
    {
        string mensaje_error;
        int numero_error;
        // GET: api/BitacorasRangoFechaAndUser
        public List<Bitacora> Get()
        {
            List<Bitacora> bitacoras = new Bitacora().GetBitacorasUserFilteredbyDateRangeAndUser(ref mensaje_error, ref numero_error, Bitacora.GlobalValueFilterUser, Bitacora.GlobalValueFilterDateIni, Bitacora.GlobalValueFilterDateFin);
            return bitacoras;
        }

        // GET: api/BitacorasRangoFechaAndUser/5
        public Bitacora Get(int id)
        {
            List<Bitacora> bitacoras = new Bitacora().GetBitacorasUserFilteredbyDateRangeAndUser(ref mensaje_error, ref numero_error, Bitacora.GlobalValueFilterUser, Bitacora.GlobalValueFilterDateIni, Bitacora.GlobalValueFilterDateFin);
            crypting c = new crypting();
            Bitacora x = bitacoras.ElementAt(id);
            Bitacora spes = new Bitacora();
            spes.Cod_Registro = x.Cod_Registro;
            spes.Cod_User_FK = c.decrypt(x.Cod_User_FK);
            spes.FechaTime = c.decrypt(x.FechaTime);
            spes.Tipo = c.decrypt(x.Tipo);
            spes.Time = c.decrypt(x.Time);
            spes.Cod_Regis = x.Cod_Regis;
            spes.Descripcion = c.decrypt(x.Descripcion);
            spes.RegistroDetalle = c.decrypt(x.RegistroDetalle);
            return spes;
        }

        // POST: api/BitacorasRangoFechaAndUser
        public void Post([FromBody]Bitacora value)
        {
            Bitacora.GlobalValueFilterUser = value.Cod_User_FK;
            Bitacora.GlobalValueFilterDateIni = value.date1;
            Bitacora.GlobalValueFilterDateFin = value.date2;
        }

    }
}
