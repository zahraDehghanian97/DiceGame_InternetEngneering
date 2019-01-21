using DiceGame.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DiceGame.Controllers
{
    public class HomeController : Controller
    {
        DiceModel db = new DiceModel();
        public ActionResult Index()
        {
            //ViewBag.BestOnlineGame = from s in db.OnlineGames group s by s.DesignedGameId into g select new { DesignedGameId = g.Key, Max = g.Max(s => s.DesignedGameId) };
            ViewBag.BestDesigner = db.DesignedGames.OrderByDescending(x => x.TotalScore).First().DesignerUser;
            ViewBag.NewBestDesigner = db.DesignedGames.OrderByDescending(x => x.TotalScore).OrderByDescending(z => z.DateBuild).First().DesignerUser;
            var all = db.Users.AsEnumerable().ToList();
            foreach (var l in all)
            {
                db.Users.Where(u => u.UserName == l.UserName).First().Friend = 0;

            }
            if (Session["username"] != null)
            {
                var a = Session["username"].ToString();

                var r = db.Friends.Where(u => u.Username == a).AsEnumerable().ToList();
                foreach (var z in r)
                {
                    db.Users.Where(u => u.UserName == z.UsernameFriend).First().Friend = 1;
                }
            }
                return View(db.Users.Where(u => u.Online == 1).AsEnumerable());
            
        }
        public ActionResult AllUsers()
        {
            return View(db.Users.AsEnumerable());
        }
        

        public ActionResult AdminIndex()
        {
           ViewBag.BestOnlineGame = from s in db.OnlineGames group s by s.DesignedGameId into g select new { DesignedGameId = g.Key, Max = g.Max(s => s.DesignedGameId) };
           ViewBag.BestDesigner = db.DesignedGames.OrderByDescending(x => x.TotalScore).First();
           ViewBag.NewBestDesigner = db.DesignedGames.OrderByDescending(x => x.TotalScore).OrderByDescending(z => z.DateBuild).First();

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }
        public ActionResult AddFriend1(string friend)
        {
            Friend f = new Friend();
            f.Username = Session["username"].ToString();
            f.UsernameFriend = friend;
            db.Friends.Add(f);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult AddFriend2(string friend)
        {
            Friend f = new Friend();
            f.Username = Session["username"].ToString();
            f.UsernameFriend = friend;
            db.Friends.Add(f);
            db.SaveChanges();
            return RedirectToAction("AllUsers");
        }
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult DesignGame()
        {
            return View();
        }
        [HttpPost]
        public ActionResult DesignGameSave(DesignedGame d)
        {
            if (Session["username"] != null)
            {
                d.DesignerUser = (string)Session["username"];
                db.DesignedGames.Add(d);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            else {
                Session["message"] = "To design game you must login first ! ";
                return RedirectToAction("login","login");
            }
        }

        public ActionResult Slider()
        {
            return View();
        }

        public ActionResult GuestIndex()
        {

            ViewBag.BestOnlineGame = from s in db.OnlineGames group s by s.DesignedGameId into g select new { DesignedGameId = g.Key, Max = g.Max(s => s.DesignedGameId) };
            ViewBag.BestDesigner = db.DesignedGames.OrderByDescending(x => x.TotalScore).First();
            ViewBag.NewBestDesigner = db.DesignedGames.OrderByDescending(x => x.TotalScore).OrderByDescending(z => z.DateBuild).First();

            return View();
        }

        public ActionResult EditProfile()
        {
            var z = Session["username"].ToString();
            return View(db.Users.Where(u=>u.UserName==z).FirstOrDefault());
        }

        public ActionResult UploadFile()
        {
            return View();
        }
        public ActionResult ChooseGame()
        {
            return View(db.DesignedGames.AsEnumerable());

        }
    }
}