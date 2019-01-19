﻿using DiceGame.Models;
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

            ViewBag.BestDesigner = db.DesignedGames.OrderByDescending(x => x.TotalScore).First();
            ViewBag.NewBestDesigner = db.DesignedGames.OrderByDescending(x => x.TotalScore).OrderByDescending(z => z.DateBuild).First();
            // return View(FindOnlines());
            return View();
        }
        public List<User> FindOnlines()
        {
            using (DiceModel db = new DiceModel())
            {
                var onlines = db.Users.Where(u => u.Online == 1).ToList();
                return onlines;
            }
          
        }

        public ActionResult AdminIndex()
        {
           ViewBag.BestDesigner = db.DesignedGames.OrderByDescending(x => x.TotalScore).First();
           ViewBag.NewBestDesigner = db.DesignedGames.OrderByDescending(x => x.TotalScore).OrderByDescending(z => z.DateBuild).First();

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
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

        public ActionResult Slider()
        {
            return View();
        }

        public ActionResult GuestIndex()
        {

            ViewBag.BestDesigner = db.DesignedGames.OrderByDescending(x => x.TotalScore).First();
            ViewBag.NewBestDesigner = db.DesignedGames.OrderByDescending(x => x.TotalScore).OrderByDescending(z => z.DateBuild).First();

            return View();
        }

        public ActionResult EditProfile()
        {
            return View();
        }

        public ActionResult UploadFile()
        {
            return View();
        }
    }
}