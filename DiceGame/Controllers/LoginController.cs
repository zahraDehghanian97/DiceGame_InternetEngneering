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

        private DiceModel _context = new DiceModel();

        public LoginController()
        {
            
        }
        public ActionResult login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult login(string username , string password)
        {
            User usr = _context.Users.Where(u => u.UserName == username && u.Password == password).FirstOrDefault();
            if (usr != null)
            {
                _context.Users.Remove(usr);
                _context.SaveChanges();
                usr.Online = 1;
                _context.Users.Add(usr);
                _context.SaveChanges();
                Session["username"] = _context.Users.Where(u => u.UserName == usr.UserName).First().UserName;
                Session["designedGame"] = _context.DesignedGames.Where(d => d.DesignerUser == usr.UserName).ToList();
                Session["finishedGame1"] = _context.FinishedGames.Where(d => d.Player1User == usr.UserName ).ToList();
                Session["finishedGame2"] = _context.FinishedGames.Where(d => d.Player2User == usr.UserName).ToList();
                Session["usr"] = usr;
                Session["friends"] = usr.Friends;
              //  Session["playedGame"]= _context.
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
        public ActionResult signup(User userModel)
        {
            Session["username"] = userModel.UserName;
            Session["usr"] = userModel;
            Session["friends"] = userModel.Friends;
            userModel.Online = 1;
            _context.Users.Add(userModel);
            _context.SaveChanges();
            return RedirectToAction("Index", "Home");
        }

        public ActionResult logout ()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Logout()
        {
            var x = (string)Session["username"];
            User usr = _context.Users.Where(u => u.UserName == x).FirstOrDefault();
            if ( usr!= null)
            {
                _context.Users.Remove(usr);
                _context.SaveChanges();
                usr.Online = 0;
                _context.Users.Add(usr);
                _context.SaveChanges();


            }
            Session.Clear();
            return View();
        }




    }
}