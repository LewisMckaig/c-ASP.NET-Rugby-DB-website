using SimplyRugby.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SimplyRugby.ViewModels
{
    public class CoachList
    {
        public List<nonPlayer> coachList { get; set; } = new List<nonPlayer>();

        public CoachList(List<nonPlayer> coaches)
        {
            foreach (var coach in coaches)
            {
                coachList.Add(coach);
            }
        }
    }
}