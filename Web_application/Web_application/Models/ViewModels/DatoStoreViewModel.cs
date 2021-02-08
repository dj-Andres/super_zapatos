using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace Web_application.Models.ViewModels
{
    public class DatoStoreViewModel
    {
        public int Id { get; set; }
        [DisplayName("Nombre")]
        public string name { get; set; }
        [DisplayName("Información")]
        public string address { get; set; }
    }
}