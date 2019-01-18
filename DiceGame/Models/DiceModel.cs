using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity.Infrastructure;

namespace DiceGame.Models
{
    public class DiceModel : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<OnlineGame> OnlineGame { get; set; }
        public DbSet<FinishedGame> FinisheGame { get; set; }
        public DbSet<UserComment> NewCommentGame { get; set; }
        public DbSet<GameComment> NewCommentUser { get; set; }
       
    }
}