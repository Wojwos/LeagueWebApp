using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeagueWebApp.Models
{
    public class SummonerDTO
    {
        public int ProfileIconId { get; set; }
        public string Name { get; set; }
        public string Id { get; set; }
        public long SummonerLevel { get; set; }
        public string Puuid { get; set; }
    }
}
