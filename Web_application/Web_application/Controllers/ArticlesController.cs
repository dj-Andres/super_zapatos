using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web_application.Models;
using Web_application.Models.ViewModels;
namespace Web_application.Controllers
{
    public class ArticlesController : Controller
    {
        // GET: Articles
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult List()
        {
            List<ArticlesViewModel> lst = new List<ArticlesViewModel>();
            using (Super_zapatosEntities bd= new Super_zapatosEntities())
            {
                lst =
                    (from d in bd.articles
                     orderby d.id descending
                     select new ArticlesViewModel
                {
                         Id = d.id,
                         name = d.name,
                         descripcion = d.description,
                         preci = Convert.ToInt32(d.price),
                         total = Convert.ToInt32(d.total_in_shelf),
                         total_v = Convert.ToInt32(d.total_in_vault),
                         store_id = Convert.ToInt32(d.store_id)
                     }).ToList();
            }

            return View(lst);
        }

        public ActionResult New()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Save(DatoArticlesViewModel modelArticle)
        {
            try
            {
                using (Super_zapatosEntities  bd= new Super_zapatosEntities())
                {
                    var oArticle = new articles();
                    oArticle.name = modelArticle.name;
                    oArticle.description = modelArticle.descripcion;
                    oArticle.price = modelArticle.preci;
                    oArticle.total_in_shelf = modelArticle.total;
                    oArticle.total_in_vault = modelArticle.total_v;
                    oArticle.store_id = modelArticle.store_id;
                    bd.articles.Add(oArticle);
                    bd.SaveChanges();
                }
                return Content("1");
            }
            catch (Exception ex)
            {
                return Content(ex.Message);
            }
        }

        public ActionResult Edit(int Id)
        {
            DatoArticlesViewModel model = new DatoArticlesViewModel();
            using (Super_zapatosEntities bd = new Super_zapatosEntities())
            {
                var oArticles = bd.articles.Find();
                model.name = oArticles.name;
                model.descripcion = oArticles.description;
                model.preci = Convert.ToInt32(oArticles.price);
                model.total = Convert.ToInt32(oArticles.total_in_shelf);
                model.total_v = Convert.ToInt32(oArticles.total_in_vault);
                model.store_id = Convert.ToInt32(oArticles.store_id);
            }
            return View(model);
        }
        [HttpPost]
        public ActionResult Update(DatoArticlesViewModel model)
        {
            try
            {
                using (Super_zapatosEntities bd= new Super_zapatosEntities())
                {
                    var oArticles = bd.articles.Find(model.Id);
                    oArticles.name = model.name;
                    oArticles.description = model.descripcion;
                    oArticles.price = model.preci;
                    oArticles.total_in_shelf = model.total;
                    oArticles.total_in_vault = model.total_v;
                    oArticles.store_id = model.store_id;
                    bd.Entry(oArticles).State= System.Data.Entity.EntityState.Modified;
                    bd.SaveChanges();

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