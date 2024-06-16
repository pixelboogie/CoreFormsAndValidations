using CoreFormsAndValidations.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace CoreFormsAndValidations.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult WeaklyTypedLogin()
        {
            return View();
        }
        [HttpPost]
        public IActionResult LoginPost(string username, string password)
        {
            ViewBag.Username = username;
            ViewBag.Password = password;
            return View();
        }

        public IActionResult StronglyTypedLogin()
        {
            return View();
        }

        [HttpPost]
        public IActionResult LoginSuccess(LoginViewModel login)
        {
            // *****************************
            // Validate fields are not empty/ null
            // *****************************
            if (login.Username != null && login.Password != null) {
                if (login.Username.Equals("admin") && login.Password.Equals("admin")) {
                    ViewBag.Message = "You are successfully logged in.";
                    return View();
                }
            }
            ViewBag.Message = "Invalid Credentials";
            return View();
        }

        public IActionResult UserDetail()
        {
            var user = new LoginViewModel() { Username = "Guy", Password = "12345" };
            return View(user);
        }

        public IActionResult UserList()
        {
            var user = new List<LoginViewModel>()
            {
                new LoginViewModel() { Username = "Guy", Password = "12345" },
                new LoginViewModel() { Username = "Vato", Password = "54321" },
                new LoginViewModel() { Username = "Dude", Password = "88888" }
            };
            return View(user);
        }

        public IActionResult GetAccount() { return View(); }


        [HttpPost]
        public IActionResult PostAccount(Account account)
        {
            // *****************************
            // Validate the ModelState is valid
            // *****************************
            if (ModelState.IsValid) 
            {
                return View("Success");
            }
            return RedirectToAction("GetAccount");
        }
    }
}
