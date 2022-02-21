using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeagueWebApp.Models
{
    public class MetadataDTO
    {
        public string MatchId { get; set; }
        public List<string> Participants { get; set; }
    }
}
