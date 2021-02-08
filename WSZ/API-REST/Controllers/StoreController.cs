using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using API_REST.Models;
using API_REST.Controllers.Response;
namespace API_REST.Controllers
{
    public class StoreController : ApiController
    {
        private Super_zapatosEntities  dbContext = new Super_zapatosEntities();

        [Route("services/stores")]
        [HttpGet]
        public IEnumerable<store> Get()
        {
            Respuesta oRespuesta = new Respuesta();
            oRespuesta.Exito = 0;
            try
            {
                using (Super_zapatosEntities storeEntities = new Super_zapatosEntities())
                {
                    var lst = storeEntities.stores.ToList();
                    oRespuesta.Exito = 1;
                    oRespuesta.Data = lst;
                }
            }
            catch (Exception ex)
            {
                oRespuesta.mensaje = ex.Message;
            }

            return (IEnumerable<store>)Ok(oRespuesta);
        }

        [Route("services/stores{id}")]
        [HttpGet]
        public IEnumerable<store> Get(int id)
        {
            Respuesta oRespuesta = new Respuesta();
            oRespuesta.Exito = 0;
            try
            {
                using (Super_zapatosEntities storeEntities = new Super_zapatosEntities())
                {
                    var lst = storeEntities.stores.FirstOrDefault(e => e.id == id);
                    oRespuesta.Exito = 1;
                    oRespuesta.Data = lst;
                }
            }
            catch (Exception ex)
            {
                oRespuesta.mensaje = ex.Message;
            }
            return (IEnumerable<store>)Ok(oRespuesta);
        }
    }
}
