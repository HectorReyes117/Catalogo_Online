using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Capa_Enitdad;
using Capa_Negocio;

namespace Capa_Presentacion.Controllers
{
    public class LoginController : Controller
    {

        UsersBusiness Business = new UsersBusiness();
        // GET: Login
        public ActionResult Index(string message)
        {
            try
            {
                ViewBag.Message = message;
                return View();
            }
            catch (Exception e)
            {
                return View(e.Message);
            }
          
        }

        [HttpPost]
        public ActionResult Index(string email, string _password)
        {
          
            try
            {
                if (!string.IsNullOrEmpty(email) && !string.IsNullOrEmpty(_password))
                {

                    var user = Business.Compare(email, _password);
                    if (user != null)
                    {
                        FormsAuthentication.SetAuthCookie(user.email, true);
                        return RedirectToAction("Index", "Product");
                    }
                    else
                    {
                        return RedirectToAction("Index", new { message = "No encontramos tus datos" });
                    }
                }
                else
                {
                    return RedirectToAction("Index", new { message = "Llena los campos vacios para poder iniciar sesion" });
                }
            }
            catch (Exception e)
            {
                return View(e.Message);
            }
        }

        public ActionResult Register(string message)
        {
            
            try
            {
                ViewBag.Message = message;
                return View();
            }
            catch (Exception e)
            {
                return View(e.Message);
            }
        }

       

        // POST: Poster/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register([Bind(Include = "email,_password")] string email, string _password,string repeat)
        {  
            try
            {
                var dato = Business.show();
                Users users = new Users();


                foreach (var item in dato)
                {
                    if (item.email == email)
                    {
                        return RedirectToAction("Register", new { message = "Ya hay una cuenta vinculada a este correo, por favor inicie sesion" });
                    }
                }

                if (_password == repeat && ModelState.IsValid)
                {
                    users.email = email;
                    users._password = _password;
                    Business.Insert(users);
                    return RedirectToAction("Index");
                }

                else
                {
                    return RedirectToAction("Register", new { message = "Las Contraseñas deben coincidir" });
                }
            }
            catch (Exception e)
            {
                return View(e.Message);
            }
        }


        [Authorize]
        public ActionResult Logout()
        {        
            try
            {
                FormsAuthentication.SignOut();
                return RedirectToAction("Index", "Product");
            }
            catch (Exception e)
            {
                return View(e.Message);
            }
        }
    }
}               