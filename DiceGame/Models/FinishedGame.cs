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

    public partial class FinishedGame
    {
        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public FinishedGame()
        {
            Current1 = 0;
            Current2 = 0;
            Score1 = 0;
            Score2 = 0;
            Turn = 1;

    }

        public int Id { get; set; }
        public string Player1User { get; set; }
        public string Player2User { get; set; }
        public int Current1 { get; set; }
        public int Current2 { get; set; }
        public int Score1 { get; set; }
        public int Score2 { get; set; }
        public int Turn { get; set; }
        public int DesignedGameId { get; set; }
        public int finished { get; set; }//if finishe =1 else =0
       

    }
}
