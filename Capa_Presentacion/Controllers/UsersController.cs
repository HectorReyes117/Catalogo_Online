using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Capa_Negocio;
using Capa_Enitdad;
using System.Net;

namespace Capa_Presentacion.Controllers
{
    public class UsersController : Controller
    {
        UsersBusiness Business = new UsersBusiness();
        // GET: Users
        
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


        // GET: Users/Create
        public ActionResult Create()
        {
            return View();
        }
        
        // POST: Users/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "email,_password")] Users users)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Business.Insert(users);
                    return RedirectToAction("Index");
                }

                return View(users);
            }
            catch (Exception e)
            {
                return View(e.Message);
            }        
        }

        // GET: Users/Edit/5
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

        // POST: Users/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,email,_password")] Users users)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Business.Update(users);
                    return RedirectToAction("Index");
                }
                return View(users);
            }
            catch (Exception e)
            {
                return View(e.Message);
            }
        }

        // GET: Users/Delete/5
       
    }
}
