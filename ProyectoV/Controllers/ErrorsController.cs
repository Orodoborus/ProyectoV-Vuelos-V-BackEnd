using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BLL;
using ProyectoV.Models;
using Newtonsoft.Json;

/*
 4.6.2. Errores
Consiste en mostrar una lista con los errores que se han registrado en la aplicación. La 
consulta tendrá la opción de filtrar por rango de fecha. Se presenta la fecha y hora, numero 
de error y el mensaje de error correspondiente.

 */

namespace ProyectoV.Controllers
{
    public class ErrorsController : ApiController
    {
        string mensaje_error;
        int numero_error;
        
        // GET: api/Errors
        public List<Errors> Get()
        {
            List<Errors> listaError = new Errors().cargar_lista_errores(ref mensaje_error, ref numero_error);
            return listaError;
        }

        // GET: api/Errors/5
        public Errors Get(int id) //ID de Error o ID de de error de SQL? Ojete
        {
            List<Errors> listaError = new Errors().cargar_lista_errores(ref mensaje_error, ref numero_error);
            crypting c = new crypting();
            Errors x = listaError.ElementAt(id); //ojete con la x, es necesaria en errors?
            Errors spes = new Errors();
            spes.Error_ID = x.Error_ID;    //x.Error_ID;
            spes.Error_Message = c.decrypt(x.Error_Message);
            spes.Time = c.decrypt(x.Time);
            spes.Date = c.decrypt(x.Date);
            spes.Error_Number = c.decrypt(x.Error_Number);
            return spes;
        }

        // POST: api/Errors
        public void Post([FromBody]Errors error)
        {
            Errors create = new Errors();
            crypting c = new crypting();
            create.crearError(ref mensaje_error, ref numero_error, Errors.GlobalValue = Errors.GlobalValue+1,c.encrypt(error.Error_Message), c.encrypt(error.Time), c.encrypt(error.Date), c.encrypt(error.Error_Number));
        }

        // PUT: api/Errors/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Errors/5
        public void Delete(int id)
        {
        }
    }
}
