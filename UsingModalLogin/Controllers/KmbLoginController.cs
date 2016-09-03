using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UsingModalLogin.Models;

namespace UsingModalLogin.Controllers
{
    public class KmbLoginController : Controller
    {
        // TODO : EF DatabaseContext Sample
        private KmbContext db = new KmbContext();

        // TODO : Sample Index Page - You can remove this.
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult SignIn(string login_username, string login_password, bool login_rememberme)
        {
            KmbLoginJsonResult result = new KmbLoginJsonResult();

            login_username = login_username?.Trim();
            login_password = login_password?.Trim();

            if (string.IsNullOrEmpty(login_username) || string.IsNullOrEmpty(login_password))
            {
                result.HasError = true;
                result.Message = "Username and password can not be empty.";
            }
            else
            {
                // AsNoTracking : This should be used for example if you want to load entity only to read data and you don't plan to modify them.

                // TODO : KMB Modal Login - SignIn
                KmbUser user = db.KmbUsers.AsNoTracking().FirstOrDefault(x => x.Username == login_username && x.Password == login_password);

                if (user != null)
                {
                    result.HasError = false;
                    result.Message = "Login successfully.";

                    user.Password = string.Empty;

                    // Set login to session
                    Session["login"] = user;
                }
                else
                {
                    result.HasError = true;
                    result.Message = "Username or password is wrong.";
                }
            }

            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult SignUp(string register_username, string register_email, string register_password)
        {
            KmbLoginJsonResult result = new KmbLoginJsonResult();

            register_username = register_username?.Trim();
            register_email = register_email?.Trim();
            register_password = register_password?.Trim();

            if (string.IsNullOrEmpty(register_username) || string.IsNullOrEmpty(register_email) || string.IsNullOrEmpty(register_password))
            {
                result.HasError = true;
                result.Message = "Please, fill all blank fields.";
            }
            else
            {
                // TODO : KMB Modal Login - SignUp
                KmbUser user = db.KmbUsers.FirstOrDefault(x => x.Username == register_username || x.Email == register_email);

                if(user != null)
                {
                    result.HasError = true;
                    result.Message = "Username or e-mail address to be used.";
                }
                else
                {
                    user = db.KmbUsers.Add(new KmbUser()
                    {
                        Name = string.Empty,
                        Surname = string.Empty,
                        Email = register_email,
                        Username = register_username,
                        Password = register_password
                    });

                    if (db.SaveChanges() > 0)
                    {
                        result.HasError = false;
                        result.Message = "Account created.";

                        // Detached : This should be used for example if you want to load entity only to read data and you don't plan to modify them.
                        db.Entry(user).State = System.Data.Entity.EntityState.Detached;

                        user.Password = string.Empty;

                        // Set login to session for auto login from register.
                        Session["login"] = user;
                    }
                    else
                    {
                        result.HasError = true;
                        result.Message = "Error occured.";
                    }
                }
            }


            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult LostPassword(string lost_email)
        {
            KmbLoginJsonResult result = new KmbLoginJsonResult();

            lost_email = lost_email?.Trim();

            if (string.IsNullOrEmpty(lost_email))
            {
                result.HasError = true;
                result.Message = "E-Mail address can not be empty.";
            }
            else
            {
                // TODO : KMB Modal Login - Lost Password
                KmbUser user = db.KmbUsers.AsNoTracking().FirstOrDefault(x => x.Email == lost_email);

                if (user != null)   
                {
                    //
                    // TODO : Send password with e-mail.
                    //

                    result.HasError = false;
                    result.Message = "Password has been sent.";
                }
                else
                {
                    result.HasError = true;
                    result.Message = "E-Mail address not found.";
                }
            }

            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public ActionResult SignOut()
        {
            Session.Clear();

            // TODO : Regdirect Url after SignOut
            return RedirectToAction("Index", "KmbLogin");
        }

        public ActionResult UserProfile()
        {
            // TODO : KMB Modal Login - UserProfile
            KmbUser user = Session["login"] as KmbUser;

            return View(user);
        }
    }
}