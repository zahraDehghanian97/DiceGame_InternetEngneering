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
        public DiceModel() : base("name = DiceModel") {
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<OnlineGame> OnlineGames { get; set; }
        public DbSet<FinishedGame> FinishedGames { get; set; }
        public DbSet<UserComment> CommentUsers { get; set; }
        public DbSet<GameComment> CommentGames { get; set; }
       public DbSet<DesignedGame> DesignedGames { get; set; }
    }
}