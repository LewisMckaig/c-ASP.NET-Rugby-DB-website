using SimplyRugby.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/**
   * 
   * name         :   GetCoachName.cs
   * author       :   Lewis Mckaig
   * version      :   1.0
   * date         :   1st May 2019
   * description  :   GetCoachName View Model: For uise in the game record details page to display the fullname of the coach
   *
   */
namespace SimplyRugby.ViewModels
{
    public class getCoachName
    {
        public GameRecord gr;

        public String coachName;

        public getCoachName(GameRecord gameRecord, nonPlayer coach)
        {
            gr = gameRecord;
            coachName = coach.FullName; 
        }
    }
}