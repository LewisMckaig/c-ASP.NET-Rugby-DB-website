using SimplyRugby.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SimplyRugby.ViewModels
{
    public class CoachesViewModel
    {
        [Required]
        [Display(Name = "Coach")]
        public int nonplayer_id { get; set; }
        public IEnumerable<nonPlayer> nonPlayers { get; set; }

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
    }
}