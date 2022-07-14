using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Capa_Enitdad;
using Capa_Negocio;

namespace Capa_Presentacion.Controllers
{
    public class CategoriesController : Controller
    {
        CategoriesBusiness Business = new CategoriesBusiness();
        // GET: Categories
        public ActionResult Index()
        {      
            return View(Business.show());
        }

        // GET: Categories/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Categories/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "categoryName,categoryDescription")] Categories categories)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Business.Insert(categories);
                    return RedirectToAction("Index");
                }

                return View(categories);
            }
            catch (Exception e)
            {
                return View(e.Message);
            }
           
        }

        // GET: Categories/Edit/5
        public ActionResult Edit(int? id)
        {
            try
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }

                if (Business.Edit(id) == null)
                {
                    return HttpNotFound();
                }
                return View(Business.Edit(id));
            }
            catch (Exception e)
            {
                return View(e.Message);
            }
        }

        // POST: Categories/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "categoryId,categoryName,categoryDescription")] Categories categories)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Business.Update(categories);
                    return RedirectToAction("Index");
                }
                return View(categories);
            }
            catch (Exception e)
            {
                return View(e.Message);
            }
        }

        // GET: Categories/Delete/5
        public ActionResult delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            if (Business.deleteId(id) == null)
            {
                return HttpNotFound();
            }
            return View(Business.deleteId(id));
        }

        // POST: Categories/Delete/5
        [HttpPost, ActionName("delete")]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            try
            {
                Business.Delete(id);
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {

                return View(e.Message);
            }
        }
    }
}
