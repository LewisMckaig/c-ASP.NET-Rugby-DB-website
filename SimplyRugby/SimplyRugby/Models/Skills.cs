using System;
using System.Collections.Generic;
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
* description  :   Skills class representing a player skill sheet
*
* */

namespace SimplyRugby.Models
{
    public class Skills
    {
        [Required]
        public int id { get; set; }

        [Required]
        [Range(0, 5)]
        [Display(Name = "Standard Pass")]
        public int standard { get; set; }

        [Required]
        [Range(0, 5)]
        [Display(Name = "Spin Pass")]
        public int spin { get; set; }

        [Required]
        [Range(0, 5)]
        [Display(Name = "Pop Pass")]
        public int pop { get; set; }

        [Required]
        [Range(0, 5)]
        [Display(Name = "Front Tackle")]
        public int front { get; set; }

        [Required]
        [Range(0, 5)]
        [Display(Name = "Rear tackle")]
        public int rear { get; set; }

        [Required]
        [Range(0, 5)]
        [Display(Name = "Side Tackle")]
        public int side { get; set; }

        [Required]
        [Range(0, 5)]
        [Display(Name = "Scrabble Tackle")]
        public int scrabble { get; set; }

        [Required]
        [Range(0, 5)]
        [Display(Name = "Drop Kick")]
        public int Drop { get; set; }

        [Required]
        [Range(0, 5)]
        [Display(Name = "Punt Kick")]
        public int punt { get; set; }

        [Required]
        [Range(0, 5)]
        [Display(Name = "Grubber Kick")]
        public int grubber { get; set; }

        [Required]
        [Range(0, 5)]
        [Display(Name = "Goal Kick")]
        public int Goal { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Date")]
        public DateTime Date { get; set; }

        [Required]
        public int playerId { get; set; }

        public Player player { get; set; }

    }
    }