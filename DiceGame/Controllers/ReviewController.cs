using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DiceGame.Views.Login
{
    public class ReviewController : Controller
    {
        // GET: Review
        public ActionResult GameReviewAdminIndex()
        {
            return View();
        }
        public ActionResult UserReviewAdminIndex()
        {
            return View();
        }
        public ActionResult GameReviewUserIndex()
        {
            return View();
        }
        public ActionResult UserReviewUserIndex()
        {
            return View();
        }
    }
}