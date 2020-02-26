using SimplyRugby.CustomExceptions;
using SimplyRugby.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/**
    * 
    * name         :   GameRecord.cs
    * author       :   Lewis Mckaig
    * version      :   1.0
    * date         :   1st May 2019
    * description  :   Senior View Model: gathers all the Senior players for use in senior page.
    *
    */
namespace SimplyRugby.ViewModels
{
    public class Senior
    {
        public List<Player> seniorTeam { get; set; } = new List<Player>();
        public Senior(List<Player> players)
        {
            foreach (var item in players)
            {
                if (item.team == "Senior")
                {
                    seniorTeam.Add(item);
                }
                else if (item.team != "Junior")
                {
                    throw new InvalidTeamException("Team Type" + item.team + "is not valid");
                }
            }
        }
    }
}