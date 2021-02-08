using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Web_application.Models.ViewModels
{
    public class DatoArticlesViewModel
    {
        public int Id { get; set; }
        [DisplayName("Nombre")]
        public string name { get; set; }
        [DisplayName("Descripción")]
        public string descripcion { get; set; }
        [DisplayName("Precio")]
        public int preci { get; set; }
        [DisplayName("Total")]
        public int total { get; set; }
        [DisplayName("Total V")]
        public int total_v { get; set; }
        [DisplayName("Store")]
        public int store_id { get; set; }
        
    }
}