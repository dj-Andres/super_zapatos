using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web_application.Models.ViewModels
{
    public class ArticlesViewModel
    {
        public int Id { get; set; }
        public string name { get; set; }
        public string descripcion { get; set; }
        public int preci { get; set; }
        public int total { get; set; }
        public int total_v { get; set; }
        public int store_id { get; set; }
    }
}