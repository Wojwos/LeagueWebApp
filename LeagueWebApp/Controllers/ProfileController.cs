using LeagueWebApp.API;
using LeagueWebApp.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeagueWebApp.Controllers
{
    public class ProfileController : Controller
    {
        public SummonerDTO Summoner { get; set; }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(string searchName)
        {
            if (searchName == null)
            {
                return NotFound();
            }

            //get summoner from api
            Summoner_V4 summoner_v4 = new Summoner_V4("EUW1");
            Summoner = summoner_v4.GetSummonerByName(searchName);

            if (Summoner == null)
            {
                //summoner doesnt exist
                return NotFound();
            }

            return View(Summoner);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Json(new { data = GetMatchList() });
        }

        private List<ParticipantDTO> GetMatchList()
        {
            Summoner_V4 summoner_v4 = new Summoner_V4("EUW1");
            SummonerDTO user = summoner_v4.GetSummonerByName("wojwos");
            string region = "EUW1";

            //get region name
            if (region == "EUW1" || region == "EUN1")
            {
                region = "EUROPE";
            }
            
            //get matches ids
            Match_V5 match_v5 = new Match_V5(region);
            List<string> matchesId = match_v5.GetMatchesIdByPuuid(user.Puuid);

            //get matches
            List<ParticipantDTO> participantMatchList = new List<ParticipantDTO>();
            foreach (var matchId in matchesId)
            {
                var match = match_v5.GetMatchById(matchId);
                participantMatchList.Add(match.Info.Participants.Where(p => p.SummonerName.Equals(user.Name)).FirstOrDefault());
            }
            return participantMatchList;
        }
    }
}
