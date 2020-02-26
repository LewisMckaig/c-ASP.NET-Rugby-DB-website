using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

/**
* 
* name         :   Guardian.cs
* author       :   Lewis Mckaig
* version      :   1.0
* date         :   27th March 2019
* description  :   Guardian class representing a guardian record
*
* */

namespace SimplyRugby.Models
{
    public class Guardian
    {
        [Required]
        public int id { get; set; }

        [Required]
        [Display (Name = "Forename")]
        public String fName { get; set; }

        [Required]
        [Display(Name = "Surname")]
        public String lName { get; set; }

        [Required]
        [Display(Name = "Address")]
        public String address { get; set; }

        [Required]
        [Display(Name = "Mobile Number")]
        public String phone { get; set; }

        [Required]
        [Display(Name = "Relation")]
        public String relation { get; set; }

        [Required]
        public int playerID { get; set; }

        [Required]
        public Player player { get; set; }

    }
}