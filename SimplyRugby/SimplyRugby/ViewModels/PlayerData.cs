using SimplyRugby.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/**
* 
* name         :   Player.cs
* author       :   Lewis Mckaig
* version      :   1.0
* date         :   27th March 2019
* description  :   player data class, gets all the skills sheets for a particular player to be shown in the players details page
*
* */

namespace SimplyRugby.ViewModels
{
    public class PlayerData
    {
        public Player player;
        public List<Skills> playerSkills;
        public List<Guardian> guardians;
        public PlayerData(Player selectedPlayer, List<Skills> skills, List<Guardian> allGuardians)
        {
            player = selectedPlayer;
            if (player.team == "Junior")
            {
                guardians = getGuardians(allGuardians.ToArray());
            }
            playerSkills = getPlayerSkills(skills.ToArray(), player); 
            playerSkills = playerSkills.OrderByDescending(x => x.Date).ToList();
        }

        /**
         * Searches the List of skill sheets and adds any with the players id to the list.
         */
        public List<Skills> getPlayerSkills(Skills[] skills, Player player)
        {
            List<Skills> allSkillSheets = new List<Skills>();
            for (int i = 0; i<skills.Length; i++)
            {
                if (skills[i].playerId == player.id)
                {
                    allSkillSheets.Add(skills[i]);
                }
            }
            return allSkillSheets.ToList();
        }

        /**
         * Searches the List of Guardians and adds any with the players id to the list.
         */
        public List<Guardian> getGuardians(Guardian[] guardians)
        {
            List<Guardian> allGuardians = new List<Guardian>();
            for (int i = 0; i < guardians.Length; i++)
            {
                if (guardians[i].playerID == player.id)
                {
                    allGuardians.Add(guardians[i]);
                }
            }
            return allGuardians.ToList();
        }
    }
}