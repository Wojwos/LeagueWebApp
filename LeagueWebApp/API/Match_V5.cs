using LeagueWebApp.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeagueWebApp.API
{
    class Match_V5 : Api
    {
        public Match_V5(string region) : base(region)
        {
        }
        public MatchDTO GetMatchById(string matchId)
        {
            string path = "match/v5/matches/" + matchId;

            var response = GET(GetURL(path));
            string content = response.Content.ReadAsStringAsync().Result;
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                return JsonConvert.DeserializeObject<MatchDTO>(content);
            }
            else
            {
                return null;
            }
        }
        public List<string> GetMatchesIdByPuuid(string summonerPuuid)
        {
            string path = "match/v5/matches/by-puuid/" + summonerPuuid + "/ids";

            var response = GET(GetURL(path));
            string content = response.Content.ReadAsStringAsync().Result;
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                return JsonConvert.DeserializeObject<List<string>>(content);
            }
            else
            {
                return null;
            }
        }
    }
}
