using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web_application.Models;
using Web_application.Models.ViewModels;

namespace Web_application.Controllers
{
    public class StoreController : Controller
    {
        // GET: Store
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult List()
        {
            List<StoreViewModel> lst = new List<StoreViewModel>();

            using (Super_zapatosEntities db= new Super_zapatosEntities())
            {
                lst =
                    (from d in db.stores
                     orderby d.id descending
                     select new StoreViewModel
                     {
                         Id = d.id,
                         name = d.name,
                         address = d.address
                     }).ToList();
                    
            }

            return View(lst);
        }

        public ActionResult New()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Save(DatoStoreViewModel modelStore)
        {
            //return View();
            try
            {
                using(Super_zapatosEntities db= new Super_zapatosEntities())
                {
                    var oStore = new stores();
                    oStore.name = modelStore.name;
                    oStore.address = modelStore.address;
                    db.stores.Add(oStore);
                    db.SaveChanges();
                }

                return Content("1");
            }
            catch(Exception ex)
            {
                return Content(ex.Message);
            }
        }

        public ActionResult Edit(int Id)
        {
            DatoStoreViewModel model = new DatoStoreViewModel();
            using (Super_zapatosEntities bd= new Super_zapatosEntities())
            {
                var oStore = bd.stores.Find();
                model.name = oStore.name;
                model.address = oStore.address;
                model.Id = oStore.id;
            }

            return View(model);
        }
        [HttpPost]
        public ActionResult Update(DatoStoreViewModel model)
        {
            try
            {
                using (Super_zapatosEntities db = new Super_zapatosEntities())
                {
                    var oStore = db.stores.Find(model.Id);
                    oStore.name = model.name;
                    oStore.address = model.address;
                    db.Entry(oStore).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                }

                return Content("1");
            }
            catch (Exception ex)
            {
                return Content(ex.Message);
            }
        }
    }
}