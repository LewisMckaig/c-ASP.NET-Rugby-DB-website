using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

/**
* 
* name         :   TrainingRecord.cs
* author       :   Lewis Mckaig
* version      :   1.0
* date         :   27th March 2019
* description  :   Training Record class representing a Training Record
* */

namespace SimplyRugby.Models
{
    public class TrainingRecord
    {
        [Required]
        public int id { get; set; }

        [Required]
        [Display(Name = "Coach Name")]
        public int nonPlayer_id { get; set; }

        [Required]
        public nonPlayer nonPlayer { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Date")]
        public DateTime date { get; set; }

        [Required]
        [Display(Name = "Location")]
        public String location { get; set; }

        [Required]
        [Display(Name = "Skills/Activities Undertaken")]
        public String description { get; set; }

        [Display(Name = "Accidents/Injuries")]
        public String accidents { get; set; }

        [NotMapped]
        public String FullName { get; set; }

    }

    
}