using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UsingModalLogin.Models;

namespace UsingModalLogin.Controllers
{
    public class ModalLoginController : Controller
    {
        [HttpPost]
        public JsonResult SignIn(string login_username, string login_password, bool login_rememberme)
        {
            ModalLoginJsonResult result = new ModalLoginJsonResult();

            login_username = login_username?.Trim();
            login_password = login_password?.Trim();

            if (string.IsNullOrEmpty(login_username) || string.IsNullOrEmpty(login_password))
            {
                result.HasError = true;
                result.Message = "Kullanıcı adı ya da şifre boş geçilemez.";
            }
            else
            {
                // TODO : SignIn => Check account info into database.
                // Entity Framework or ADO.NET code here..

                if (login_username == "murat" && login_password == "baseren")    // for example..
                {
                    result.HasError = false;
                    result.Message = "Giriş başarılı";

                    // Set login to session
                    Session["login"] =
                        new SysUser()
                        {
                            Id = 1,
                            Name = "K. Murat",
                            Surname = "Baseren",
                            Username = "muratbaseren",
                            Email = "kadirmuratbaseren@gmail.com"
                        };
                }
                else
                {
                    result.HasError = true;
                    result.Message = "Kullanıcı adı ya da şifre yanlış.";
                }
            }

            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult SignUp(string register_username, string register_email, string register_password)
        {
            ModalLoginJsonResult result = new ModalLoginJsonResult();

            register_username = register_username?.Trim();
            register_email = register_email?.Trim();
            register_password = register_password?.Trim();

            if (string.IsNullOrEmpty(register_username) || string.IsNullOrEmpty(register_email) || string.IsNullOrEmpty(register_password))
            {
                result.HasError = true;
                result.Message = "Lutfen tum alanlar doldurulmalidir.";
            }
            else
            {
                // TODO : SignUp => Insert account info to database.
                // Entity Framework or ADO.NET code here..

                if (register_username == "muratbaseren")    // for example..
                {
                    result.HasError = false;
                    result.Message = "Hesap olusturulmustur.";

                    // Set login to session for auto login from register.
                    Session["login"] =
                        new SysUser()
                        {
                            Id = 1,
                            Name = "K. Murat",
                            Surname = "Baseren",
                            Username = "muratbaseren",
                            Email = "kadirmuratbaseren@gmail.com"
                        };
                }
                else
                {
                    result.HasError = true;
                    result.Message = "Hata olustu.";
                }
            }


            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult LostPassword(string lost_email)
        {
            ModalLoginJsonResult result = new ModalLoginJsonResult();

            lost_email = lost_email?.Trim();

            if (string.IsNullOrEmpty(lost_email))
            {
                result.HasError = true;
                result.Message = "E-posta adresi bos gecilemez.";
            }
            else
            {
                // TODO : LostPassword => Check e-posta into database.
                // Entity Framework or ADO.NET code here..

                if (lost_email == "kadirmuratbaseren@gmail.com")    // for example..
                {
                    result.HasError = false;
                    result.Message = "Sifreniz gonderilmistir.";
                }
                else
                {
                    result.HasError = true;
                    result.Message = "E-Posta adresi bulunamamistir.";
                }
            }

            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public ActionResult SignOut()
        {
            Session.Clear();

            // TODO : SignOut => if require to change actionname and controllername..
            return new RedirectResult(Request.UrlReferrer.ToString());
        }

        public ActionResult UserProfile()
        {
            // TODO : UserProfile => create user profile view..
            return View();
        }
    }
}