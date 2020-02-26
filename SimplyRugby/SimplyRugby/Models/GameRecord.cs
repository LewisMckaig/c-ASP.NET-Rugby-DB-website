using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

/**
* 
* name         :   GameRecord.cs
* author       :   Lewis Mckaig
* version      :   1.0
* date         :   27th March 2019
* description  :   Game Record class representing a record of a match
*
* */

namespace SimplyRugby.Models
{
    public class GameRecord
    {
        [Required]
        public int id { get; set; }

        [Required]
        [Display(Name ="Opposition")]
        public String name { get; set; }

        [Required]
        [Display (Name = "Team")]
        public String team { get; set; }

        [Required]
        [Display(Name = "Location")]
        public String Location { get; set; }

        [Required]
        [Range(0, 1000)]
        [Display(Name = "Points For")]
        public int ptsFor { get; set; }

        [Required]
        [Range(0, 1000)]
        [Display(Name = "Points Against")]
        public int ptsAgainst { get; set; }

        [Required]
        [Display(Name = "First Half")]
        public String firstHalf { get; set; }

        [Required]
        [Display(Name = "Second Half")]
        public String secondHalf { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Date")]
        public DateTime date { get; set; }

        [Required]
        [Display (Name ="Coach")]
        public int coachID { get; set; }

        public nonPlayer Coach { get; set; }

        [NotMapped]
        public String Result { get => getResult(ptsFor, ptsAgainst); }

        public String getResult(int pointsFor, int pointsAgainst)
        {
            String result = "";
            if (pointsFor > pointsAgainst)
            {
                result = "Win";
            }
            else if (pointsFor < pointsAgainst)
            {
                result = "Loss";
            }
            else
            {
                result = "Draw";
            }
            return result;
        }
    }
}