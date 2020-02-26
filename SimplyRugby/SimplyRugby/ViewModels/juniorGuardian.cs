using SimplyRugby.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SimplyRugby.ViewModels
{
    public class juniorGuardian
    {

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

        [Required(ErrorMessage = "Post Code Is Required")]
        [StringLength(8, MinimumLength = 6, ErrorMessage = "Post Code must be 6 to 8 characters in length")]
        [Display(Name = "Post Code")]
        public String postCode { get; set; }

        [Required(ErrorMessage = "Phone Number is Required")]
        [Display(Name = "Phone Number")]
        public String phoneNum { get; set; }

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

        [Required]
        [Display(Name = "Team")]
        public String team { get; set; }

        [Required]
        [Display(Name = "Forename")]
        public String gfName { get; set; }

        [Required]
        [Display(Name = "Surname")]
        public String glName { get; set; }

        [Required]
        [Display(Name = "Address")]
        public String gaddress { get; set; }

        [Required]
        [Display(Name = "Mobile Number")]
        public String gphone { get; set; }

        [Required]
        [Display(Name = "Relation")]
        public String grelation { get; set; }

        public Player setPlayer()
        {
            Player player = new Player();
            player.SRUnum = SRUnum;
            player.fName = fName;
            player.lName = lName;
            player.dob = dob;
            player.address = address;
            player.postCode = postCode;
            player.phoneNum = phoneNum;
            player.position = position;
            player.email = email;
            player.doctor = doctor;
            player.doctorAddress = doctorAddress;
            player.doctorPhone = doctorPhone;
            player.healthissues = healthissues;
            player.team = "Junior";
            return player;
        }

        public Guardian setGuardian()
        {
            Guardian guardian = new Guardian();
            guardian.fName = gfName;
            guardian.lName = glName;
            guardian.phone = gphone;
            guardian.address = gaddress;
            guardian.relation = grelation;

            return guardian;
        }

    }
}