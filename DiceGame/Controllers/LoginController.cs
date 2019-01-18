using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DiceGame.Models;

namespace DiceGame.Controllers
{
    public class LoginController : Controller
    {

        private DiceModel _context;

        public LoginController()
        {
            _context = new DiceModel();
        }
        [HttpPost]
        public ActionResult Index(string username , string password)
        {
            if(_context.Users.Where(u => u.UserName == username && u.Password == password).Any())
            {
                Session["Username"] = username;
                return RedirectToAction("Index", "Home");
            }
            else if (_context.Admins.Where(u => u.Username == username && u.Password == password).Any())
            {
                return RedirectToAction("AdminIndex", "Home");
            }
            else
            {
                return RedirectToAction("login", "Login");
            }

            
        }

        
        public ActionResult signUp()
        {
            return View();
        }

        [HttpPost]
        public ActionResult submit(User userModel)
        {
            userModel.Id = 1;
            _context.Users.Add(userModel);
            _context.SaveChanges();
            return RedirectToAction("Index", "Home");
        }

        
        public ActionResult login()
        {

            return View();
        }




    }
}