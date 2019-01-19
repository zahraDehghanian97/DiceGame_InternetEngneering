using DiceGame.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DiceGame.Views.Login
{
    public class ReviewController : Controller
    {
        DiceModel db = new DiceModel();
        // GET: Review
        public ActionResult GameReviewAdminIndex()
        {

            return View(db.CommentGames.AsEnumerable());
        }
        public ActionResult UserReviewAdminIndex()
        {
            return View(db.CommentUsers.AsEnumerable());
        }
        public ActionResult GameReviewUserIndex()
        {
            return View();
        }
        public ActionResult UserReviewUserIndex()
        {
            return View();
        }
        public ActionResult AcceptGameReview(int id)
        {
            return View();
        }
        public ActionResult AcceptUserReview(int id)
        {
            return View();
        }
        public ActionResult DeclineUserReview(int id)
        {
            return View();
        }
        public ActionResult DeclineGameReview(int id)
        {
            return View();
        }
    }
}