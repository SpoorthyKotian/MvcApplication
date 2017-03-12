using MvcRandomImage.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace MvcRandomImage.Controllers
{
    /// <summary>
    /// Session Controller provides login and logout functionality to user.
    /// </summary>
    public class SessionController : Controller
    {

        /// <summary>
        /// Displays Login page
        /// </summary>
        /// <returns>Login page</returns>
        public ActionResult Login()
        {
            return View();
        }


        /// <summary>
        /// Performs User Authentication
        /// </summary>
        /// <param name="UserModel">User model</param>
        /// <returns>On success redirects shows image page |
        /// On failure returns to login page with error msg</returns>
        [HttpPost]
        public ActionResult Login(User UserModel)
        {
            using (DatabaseContext db = new DatabaseContext())
            {
                try
                {

                    var usr = db.user.Single(u => u.Username == UserModel.Username && u.Password == UserModel.Password);

                    if (usr != null)
                {
                    Session["UserId"] = usr.UserId.ToString();
                    Session["Username"] = usr.Username.ToString();
                    return RedirectToAction("Show", "Image");
                }
                }
                catch (InvalidOperationException ex)
                {
                    // use logging modules and handler and log errors.
                    var error = ex.Message;
                    ModelState.AddModelError("User_Auth_Failure", "Error! Login details are incorrect.");
                }
            }

            return View();
        }

        /// <summary>
        /// Logout functionality
        /// </summary>
        /// <returns>Redirects to login page</returns>
        public ActionResult Logout()
        {
                Session.Abandon();
                return RedirectToAction("Login");
        }
    }
}