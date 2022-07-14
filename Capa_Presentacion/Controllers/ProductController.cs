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
    public class ProductController : Controller
    {

        ProductBusiness Business = new ProductBusiness();
        CategoriesBusiness CategoriesBusiness = new CategoriesBusiness();
        // GET: Product
        public ActionResult Index()
        {
            try
            {               
                return View(Business.show());
            }
            catch (Exception e)
            {

                return View(e.Message);
            }
        }

        // GET: Product/Details/5
        public ActionResult Details(int? id)
        {
            try
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }

                if (Business.Detail(id) == null)
                {
                    return HttpNotFound();
                }
                return View(Business.Detail(id));
            }
            catch (Exception e)
            {

                return View(e.Message);
            }
        }

        // GET: Product/Create
        public ActionResult Create()
        {
            ViewBag.items = CategoriesBusiness.show();
            return View();
        }

        // POST: Product/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "productName,productPrice,categoryId")] Product product)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Business.Insert(product);
                    return RedirectToAction("Index");
                }

                return View(product);
            }
            catch (Exception e)
            {
                return View(e.Message);
            }
        }

        // GET: Product/Edit/5
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

                ViewBag.items = CategoriesBusiness.show();
                return View(Business.Edit(id));
            }
            catch (Exception e)
            {
                return View(e.Message);
            }
        }

        // POST: Product/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "productId,productName,productPrice,categoryId")] Product product)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Business.Update(product);
                    return RedirectToAction("Index");
                }
                return View(product);
            }
            catch (Exception e)
            {
                return View(e.Message);
            }
        }

        // GET: Product/Delete/5
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

        // POST: Product/Delete/5
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
