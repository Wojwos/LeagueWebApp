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
    }
}
