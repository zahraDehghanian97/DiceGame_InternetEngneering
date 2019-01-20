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

        [HttpPost]
        public void SaveGame(int t , int c1 ,int c2  , int s1 , int s2)
        {
           // if (ModelState.IsValid)
           // {
               
                    db.OnlineGames.Find(1).Current1 = c1;// game.Current1;
                    db.OnlineGames.Find(1).Current2 = c2;// game.Current2;
                    db.OnlineGames.Find(1).Turn = t;// game.Turn;
                    db.OnlineGames.Find(1).Score1 = s1;// game.Score1;
                    db.OnlineGames.Find(1).Score2 = s2;// game.Score2;
                    db.SaveChanges();
                  //  return Json(new { Message = "insert succesfully", JsonRequestBehavior.AllowGet });
                


          //  }
          //  return Json(new { Message = "there is no game with this ID", JsonRequestBehavior.AllowGet });

        }
    }
}