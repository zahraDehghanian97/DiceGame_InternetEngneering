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
                usr.Online = 1;
                _context.Users.Add(usr);
                _context.SaveChanges();
                Session["designedGame"] = _context.DesignedGames.Where(d => d.DesignerId == usr.Id).ToList();
                Session["finishedGame1"] = _context.FinishedGames.Where(d => d.Player1Id == usr.Id ).ToList();
                Session["finishedGame2"] = _context.FinishedGames.Where(d => d.Player2Id == usr.Id).ToList();
                Session["usr"] = usr;
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
            Session["usr"] = userModel;
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
            User usr = _context.Users.Where(u =>u.UserName == Session["Username"].ToString()).FirstOrDefault();
            if ( User!= null)
            {
                _context.Users.Remove(usr);
                usr.Online = 0;
                _context.Users.Add(usr);
                _context.SaveChanges();


            }
            return View();
        }




    }
}