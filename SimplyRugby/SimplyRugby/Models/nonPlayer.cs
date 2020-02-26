using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

/**
* 
* name         :   nonPlayer.cs
* author       :   Lewis Mckaig
* version      :   1.0
* date         :   27th March 2019
* description  :   non player class representing a non Player Record
*
* */

namespace SimplyRugby.Models
{
    public class nonPlayer
    {
        [Required]
        public int id { get; set; }

        [Required(ErrorMessage = "SRU number is required")]
        [Display(Name = "SRU Number")]
        [MaxLength(10)]
        public String SRUnum { get; set; }

        [Required]
        [Display(Name = "Forename")]
        public String fName { get; set; }

        [Required]
        [Display(Name = "Surname")]
        public String lName { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Date Of Birth")]
        public DateTime dob { get; set; }

        [Required]
        [Display(Name = "Address")]
        public String address { get; set; }

        /**
         * postCode will need to be validated in later versions to ensure the postcode is real
         */
        [Required]
        [StringLength(8, MinimumLength = 6, ErrorMessage = "Post Code must be 6 to 8 characters in length")]
        [Display(Name = "Post Code")]
        public String postCode { get; set; }

        [Required]
        [Display(Name ="Mobile Number")]
        public String phone { get; set; }

        [Required]
        [Display(Name = "Email Address")]
        [DataType(DataType.EmailAddress, ErrorMessage = "E-mail is not valid")]
        public String email { get; set; }

        [NotMapped]
        [Display(Name = "Full Name")]
        public string FullName { get => fName + " " + lName; }
    }
}