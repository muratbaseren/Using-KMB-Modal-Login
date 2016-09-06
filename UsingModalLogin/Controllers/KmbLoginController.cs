using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Configuration;
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

                KmbUser user = db.KmbUsers.AsNoTracking().FirstOrDefault(x => x.Username == login_username && x.Password == login_password);

                if (user != null)
                {
                    result.HasError = false;
                    result.Message = "Login successfully.";

                    user.Password = string.Empty;   // Session is not include pass for security.

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
                KmbUser user = db.KmbUsers.FirstOrDefault(x => x.Username == register_username || x.Email == register_email);

                if (user != null)
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

                        user.Password = string.Empty;   // Session is not include pass for security.

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
            if (Session["login"] == null)
                return RedirectToAction("Index");

            KmbUser user = Session["login"] as KmbUser;

            return View(user);
        }


        public ActionResult EditProfile()
        {
            if (Session["login"] == null)
                return RedirectToAction("Index");

            KmbUser user = Session["login"] as KmbUser;

            return View(user);
        }

        [HttpPost]
        public ActionResult EditProfile(KmbUser user, HttpPostedFileBase ProfileImage)
        {
            KmbUser usr = db.KmbUsers.Find(user.Id);

            if (user.Username != usr.Username)
            {
                // if username is using then not acceptable.
                KmbUser chk = db.KmbUsers.AsNoTracking().FirstOrDefault(x => x.Username == user.Username);

                if (chk != null)
                {
                    ModelState.AddModelError("Username", "User name is not valid.");
                    ModelState.Remove("Password");

                    return View(user);
                }
            }

            if (user.Email != usr.Email)
            {
                // if email is using then not acceptable.
                KmbUser chk = db.KmbUsers.AsNoTracking().FirstOrDefault(x => x.Email == user.Email);

                if (chk != null)
                {
                    ModelState.AddModelError("Email", "E-Mail address is not valid.");
                    ModelState.Remove("Password");

                    return View(user);
                }
            }

            if (usr != null)
            {
                if (ProfileImage != null &&
                    (ProfileImage.ContentType == "image/jpeg" ||
                    ProfileImage.ContentType == "image/jpg"))
                {
                    ProfileImage.SaveAs(Server.MapPath("~/images/user_" + user.Id + ".jpeg"));
                    usr.ProfileImageFileName = "user_" + user.Id + ".jpeg";
                }

                usr.Username = user.Username;
                usr.Name = user.Name;
                usr.Surname = user.Surname;
                usr.Password = user.Password ?? usr.Password;
                usr.Email = user.Email;

                if (db.SaveChanges() > 0)
                {
                    usr.Password = string.Empty;    // Session is not include pass for security.
                    Session["login"] = usr;

                    return RedirectToAction("UserProfile");
                }
            }

            ModelState.Remove("Password");

            return View(user);
        }


        public ActionResult DeleteProfile()
        {
            if (Session["login"] == null)
                return RedirectToAction("Index");

            KmbUser user = Session["login"] as KmbUser;

            db.KmbUsers.Remove(db.KmbUsers.Find(user.Id));

            if (db.SaveChanges() > 0)
            {
                Session.Clear();
                return RedirectToAction("Index");
            }

            return RedirectToAction("UserProfile");
        }


#if DEBUG
        [HttpPost]
        public ActionResult Index(string servername, string databasename, string userid, string password, string iswinauthentication)
        {
            if (string.IsNullOrEmpty(servername) || string.IsNullOrEmpty(databasename) ||
                string.IsNullOrWhiteSpace(servername) || string.IsNullOrWhiteSpace(databasename))
            {
                ViewBag.ResultStyle = "danger";
                ViewBag.Result = "Error : Server name or database name must not be empty.";

                return View();
            }

            string connStr = "Server=" + servername + ";Database=" + databasename + "; ";

            if (iswinauthentication != null && iswinauthentication == "on")
            {
                connStr += "Integrated Security=true;";
            }
            else
            {
                connStr += "User Id=" + userid + ";Password=" + password + ";";
            }

            try
            {
                Configuration conf = WebConfigurationManager.OpenWebConfiguration("~");
                conf.ConnectionStrings.ConnectionStrings["KmbContext"].ConnectionString = connStr;
                conf.Save();

                ViewBag.ResultStyle = "success";
                ViewBag.Result = "ConnectionString(KmbContext) saved to web.config with successfully..<br><b>First request can be a few slowly. Becase CodeFirst create database in your SQL Server. After Log-in you :) if you can write correct username and pass.(sample username is below)</b>";
            }
            catch (Exception ex)
            {
                ViewBag.ResultStyle = "danger";
                ViewBag.Result = "Error : <b>" + ex.Message + "</b>";
            }

            return View();
        }
#endif

    }
}