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
    public class ArticlesController : ApiController
    {
        private Super_zapatosEntities dbContext = new Super_zapatosEntities();


        [Route("services/articles")]
        [HttpGet]
        public IEnumerable<article> Get()
        {
            Respuesta oRespuesta = new Respuesta();
            oRespuesta.Exito = 0;

            try
            {
                using (Super_zapatosEntities articleEntities = new Super_zapatosEntities())
            {
                    var lst = articleEntities.articles.ToList();
                    oRespuesta.Exito = 1;
                    oRespuesta.Data = lst;

                }
            }
            catch (Exception ex)
            {
                oRespuesta.mensaje = ex.Message;
            }

            return (IEnumerable<article>)Ok(oRespuesta);
        }

        
        [Route("services/articles/stores/{id}")]
        [HttpGet]
        public IEnumerable<article> Get(int id)
        {
            Respuesta oRespuesta = new Respuesta();
            oRespuesta.Exito = 0;
            try
            {
                using (Super_zapatosEntities db = new Super_zapatosEntities())
                {
                    var lst = db.articles.FirstOrDefault(e => e.id == id);
                    oRespuesta.Exito = 1;
                    oRespuesta.Data = lst;
                }
            }
            catch (Exception ex)
            {
                oRespuesta.mensaje = ex.Message;
            }
            return (IEnumerable<article>)Ok(oRespuesta);
        }

    }
}
