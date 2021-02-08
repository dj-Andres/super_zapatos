using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API_REST.Controllers.Response
{
    public class Respuesta
    {
        public int Exito { get; set; }
        public string mensaje { get; set; }
        public object Data { get; set; }
    }
}