using DiceGame.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DiceGame.Controllers
{

    public class GameController : Controller
    {
        DiceModel db = new DiceModel();
        // GET: Game
        public ActionResult Index()
        {
            ViewBag.IdGame = 1;
            return View();
        }
        public ActionResult play(int id)
        {
           var g = db.DesignedGames.Where(z=> z.Id == id).First();

            if (g.WaitedGame.Count() != 0)
            { var s = Session["username"].ToString();
                OnlineGame o = new OnlineGame(id, g.WaitedGame.First(),s );
                db.DesignedGames.Where(z => z.Id == id).First().WaitedGame.Remove(g.WaitedGame.First());
                db.SaveChanges();
                Session["gameid"] = id;
                return RedirectToAction("Index", "Game");
            }
            else {
                var s = Session["username"].ToString();
                db.DesignedGames.Where(z => z.Id == id).First().WaitedGame.Add(s);
                db.SaveChanges();
                Session["message"] = "you added succesfully to game " + id;
                return RedirectToAction("ChooseGame","Home");
            }
            

        }
        [HttpPost]
        public void SaveGame(int t , int c1 ,int c2  , int s1 , int s2)
        {
            // if (ModelState.IsValid)
            // {
            var s = (int)Session["gameid"];
               
                    db.OnlineGames.Find(s).Current1 = c1;// game.Current1;
                    db.OnlineGames.Find(s).Current2 = c2;// game.Current2;
                    db.OnlineGames.Find(s).Turn = t;// game.Turn;
                    db.OnlineGames.Find(s).Score1 = s1;// game.Score1;
                    db.OnlineGames.Find(s).Score2 = s2;// game.Score2;
                    db.SaveChanges();
                  //  return Json(new { Message = "insert succesfully", JsonRequestBehavior.AllowGet });
                


          //  }
          //  return Json(new { Message = "there is no game with this ID", JsonRequestBehavior.AllowGet });

        }
    }
}