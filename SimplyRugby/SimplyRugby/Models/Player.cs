using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

/**
* 
* name         :   Player.cs
* author       :   Lewis Mckaig
* version      :   1.0
* date         :   27th March 2019
* description  :   player model class representing a player Record
*
* */
namespace SimplyRugby.Models
{
    public class Player
    {
        [Required]
        public int id { get; set; }

        [Required(ErrorMessage = "SRU number is required")]
        [Display(Name = "SRU Number")]
        [MaxLength(10)]
        public String SRUnum { get; set; }

        [Required(ErrorMessage = "Forename is required")]
        [Display(Name = "Forename")]
        public String fName { get; set; }

        [Required(ErrorMessage = "Surname is required")]
        [Display(Name = "Surname")]
        public String lName { get; set; }

        [Required(ErrorMessage = "Date of Birth is required")]
        [DataType(DataType.Date)]
        [Display(Name = "Date Of Birth")]
        public DateTime dob { get; set; }

        [Required(ErrorMessage = "Address is required")]
        public String address { get; set; }

        /**
         * postCode will need to be validated in later versions to ensure the postcode is real
         */
        [Required(ErrorMessage = "Post Code Is Required")]
        [StringLength(8, MinimumLength = 6, ErrorMessage = "Post Code must be 6 to 8 characters in length")]
        [Display(Name = "Post Code")]
        public String postCode { get; set; }

        [Required(ErrorMessage = "Phone Number is Required")]
        [Display(Name = "Phone Number")]
        public String phoneNum { get; set; }

        /**
         * Later versions will need to check if emails are valid, currently only checks if it is in email format.
         */
        [Required(ErrorMessage = "Email Address is required")]
        [Display(Name = "Email Address")]
        [DataType(DataType.EmailAddress, ErrorMessage = "E-mail is not valid")]
        public String email { get; set; }

        [Required(ErrorMessage = "Doctor is Required")]
        [Display(Name = "Doctor Name")]
        public String doctor { get; set; }

        [Required(ErrorMessage = "Doctor Address is Required")]
        [Display(Name = "Doctor Address")]
        public String doctorAddress { get; set; }

        [Required(ErrorMessage = "Doctor Phone Number is required")]
        [Display(Name = "Doctor Phone")]
        public String doctorPhone { get; set; }

        [Required(ErrorMessage = "A position is Required")]
        [Display(Name = "Primary Position")]
        public Position position { get; set; }

        [Display(Name = "Health Issues")]
        public String healthissues { get; set; }

        /**
         * can be either junior or senior
         */
        [Required]
        [Display(Name = "Team")]
        public String team { get; set; }

        [Display(Name = "Next Of Kin")]
        public String nok { get; set; }


        [Display(Name = "Next of Kin Telephone")]
        public String nokTele { get; set; }

        [NotMapped]
        [Display(Name = "Full Name")]
        public string FullName { get => fName + " " + lName; }


    }

    /**
     * Contains all possible player positions.
     */
    public enum Position
    {
        TightHeadprop,
        Hooker,
        LooseHeadprop,
        SecondRow,
        BlindSideFlanker,
        OpenSideFlanker,
        Number8,
        Scrumhalf,
        Flyhalf,
        LeftWing,
        InsideCentre,
        OustideCenter,
        RightWing,
        FullBack
    }
}