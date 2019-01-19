//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DiceGame.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class User
    {
        // [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public User()
        {
            this.comments = new List<UserComment>();
            this.Friends = new List<string>();
            //this.Games = new HashSet<Game>();
            //this.Users1 = new HashSet<User>();
            //this.Users = new HashSet<User>();
        }
    
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string BirthDay { get; set; }
        public string Gender { get; set; }
        public string Email { get; set; }
        public int age { get; set; }
        public Nullable<int> WinNum { get; set; }
        public Nullable<int> RateTotal { get; set; }
        public Nullable<int> RateNum { get; set; }
        public Nullable<double> RateMean { get; set; }
        public byte[] Picture { get; set; }
        public int Online { get; set; }
        public IList<UserComment> comments { get; set; }
        public IList<string> Friends { get; set; }
    
        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        //public ICollection<Game> Games { get; set; }
        //public Player Player { get; set; }
        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        //public ICollection<User> Users1 { get; set; }
        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        //public ICollection<User> Users { get; set; }
    }
}
