using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeagueWebApp.Models
{
    public class MatchDTO
    {
        public MetadataDTO Metadata { get; set; }
        public InfoDTO Info { get; set; }
    }
}
