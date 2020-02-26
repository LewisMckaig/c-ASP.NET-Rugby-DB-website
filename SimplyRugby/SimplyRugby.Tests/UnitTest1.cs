using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SimplyRugby.CustomExceptions;
using SimplyRugby.Models;
using SimplyRugby.ViewModels;

namespace SimplyRugby.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestJuniorListCorrect()
        {
            Player a = new Player { id = 1, fName = "Joe", lName = "Rogan", team = "Junior" };
            Player b = new Player { id = 2, fName = "Sarah", lName = "Lewis", team = "Junior" };
            Player c = new Player { id = 3, fName = "fred", lName = "Flintstone", team = "Senior" };
            Player d = new Player { id = 4, fName = "Dylan", lName = "Mckaig", team = "Senior" };
            Player e = new Player { id = 5, fName = "Joseph", lName = "Stalin", team = "Senior" };
            Player f = new Player { id = 6, fName = "Karen", lName = "Robinson", team = "Junior" };
            Player g = new Player { id = 7, fName = "Harry", lName = "Corry", team = "Junior" };

            List<Player> players = new List<Player>();
            players.Add(a);
            players.Add(b);
            players.Add(c);
            players.Add(d);
            players.Add(e);
            players.Add(f);
            players.Add(g);

            Junior junior = new Junior(players);

            int expected = 4;

            int actual = junior.juniorTeam.Count();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidTeamException),
        "Team Type AAA is not valid")]
        public void TestJunior_ExceptionThrown()
        {
            Player a = new Player { id = 1, fName = "Joe", lName = "Rogan", team = "AAA" };

            List<Player> players = new List<Player>();
            players.Add(a);

            Junior junior = new Junior(players);

        }

        [TestMethod]
        public void TestSeniorListCorrect()
        {
            Player a = new Player { id = 1, fName = "Joe", lName = "Rogan", team = "Junior" };
            Player b = new Player { id = 2, fName = "Sarah", lName = "Lewis", team = "Junior" };
            Player c = new Player { id = 3, fName = "fred", lName = "Flintstone", team = "Senior" };
            Player d = new Player { id = 4, fName = "Dylan", lName = "Mckaig", team = "Senior" };
            Player e = new Player { id = 5, fName = "Joseph", lName = "Stalin", team = "Senior" };
            Player f = new Player { id = 6, fName = "Karen", lName = "Robinson", team = "Junior" };
            Player g = new Player { id = 7, fName = "Harry", lName = "Corry", team = "Junior" };

            List<Player> players = new List<Player>();
            players.Add(a);
            players.Add(b);
            players.Add(c);
            players.Add(d);
            players.Add(e);
            players.Add(f);
            players.Add(g);

            Senior senior = new Senior(players);

            int expected = 3;

            int actual = senior.seniorTeam.Count();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidTeamException),
        "Team Type AAA is not valid")]
        public void TestSenior_ExceptionThrown()
        {
            Player a = new Player { id = 1, fName = "Joe", lName = "Rogan", team = "AAA" };

            List<Player> players = new List<Player>();
            players.Add(a);

            Senior senior = new Senior(players);

        }
        [TestMethod]
        public void TestPlayerData_Correctskillsheet()
        {
            Player a = new Player { id = 1, fName = "Joe", lName = "Rogan", team = "Junior" };

            Skills b = new Skills { id = 1, playerId = 1 };
            Skills c = new Skills { id = 2, playerId = 2 };
            Skills d = new Skills { id = 3, playerId = 1 };

            List<Skills> skills = new List<Skills>();
            skills.Add(b);
            skills.Add(c);
            skills.Add(d);

            Guardian e = new Guardian { id = 1, playerID = 1 };
            Guardian f = new Guardian { id = 1, playerID = 2 };
            List<Guardian> guardians = new List<Guardian>();

            PlayerData pd = new PlayerData(a, skills, guardians);

            int expected = 2;

            int actual = pd.playerSkills.Count();

            Assert.AreEqual(expected, actual);

        }
        [TestMethod]
        public void TestPlayerData_Correctguradians()
        {
            Player a = new Player { id = 1, fName = "Joe", lName = "Rogan", team = "Junior" };

            Skills b = new Skills { id = 1, playerId = 1 };
            Skills c = new Skills { id = 2, playerId = 2 };
            Skills d = new Skills { id = 3, playerId = 1 };

            List<Skills> skills = new List<Skills>();
            skills.Add(b);
            skills.Add(c);
            skills.Add(d);

            Guardian e = new Guardian { id = 1, playerID = 1 };
            Guardian f = new Guardian { id = 1, playerID = 2 };
            List<Guardian> guardians = new List<Guardian>();
            guardians.Add(e);
            guardians.Add(f);

            PlayerData pd = new PlayerData(a, skills, guardians);

            int expected = 1;

            int actual = pd.guardians.Count();

            Assert.AreEqual(expected, actual);

        }


    }
}
