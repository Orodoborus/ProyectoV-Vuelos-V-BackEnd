using BLL;
using ProyectoV.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ProyectoV.Controllers
{
    public class ErrorsFilterByDateRangeController : ApiController
    {

        string mensaje_error;
        int numero_error;
        // GET: api/ErrorsFilterByDateRangeController
        public List<Errors> Get()
        {
            List<Errors> errors = new Errors().GetErrorsUserFilteredbyDateRange(ref mensaje_error, ref numero_error, Errors.GlobalValueFilterDateIni, Errors.GlobalValueFilterDateFin);
            return errors;
        }

        // GET: api/ErrorsFilterByDateRangeController/5
        public Errors Get(int id)
        {
            List<Errors> bitacoras = new Errors().GetErrorsUserFilteredbyDateRange(ref mensaje_error, ref numero_error, Errors.GlobalValueFilterDateIni, Errors.GlobalValueFilterDateFin);
            crypting c = new crypting();
            Errors x = bitacoras.ElementAt(id);
            Errors spes = new Errors();
            spes.Error_ID = x.Error_ID;
            spes.Error_Message = c.decrypt(x.Error_Message);
            spes.Time = c.decrypt(x.Time);
            spes.Date = c.decrypt(x.Date);
            spes.Error_Number = c.decrypt(x.Error_Number);

            return spes;
        }

        public void Post([FromBody] Errors value)
        {
            Errors.GlobalValueFilterDateIni = value.date1;
            Errors.GlobalValueFilterDateFin = value.date2;
        }

        // PUT: api/ErrorsFilterByDateRangeController/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/ErrorsFilterByDateRangeController/5
        public void Delete(int id)
        {
        }
    }
}
