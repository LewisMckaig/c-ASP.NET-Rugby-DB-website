using SimplyRugby.CustomExceptions;
using SimplyRugby.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SimplyRugby.ViewModels
{
    /**
    * 
    * name         :   GameRecord.cs
    * author       :   Lewis Mckaig
    * version      :   1.0
    * date         :   1st May 2019
    * description  :   Junior View Model: gathers all the Junior players for use in junior team page and the guardian create page to ensure that they can only select junior players.
    *
    */
    public class Junior
    {
        public List<Player> juniorTeam { get; set; } = new List<Player>();
        public Junior(List<Player> players)
        {

            foreach (var item in players)
            {
                if (item.team == "Junior")
                {
                    juniorTeam.Add(item);
                }
                else if (item.team != "Senior")
                {
                    throw new InvalidTeamException("Team Type " + item.team + " is not valid");
                }
            } 
        }
    }
}