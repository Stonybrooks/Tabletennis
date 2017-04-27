using System.Collections.Generic;

namespace Tabletennis.Core.Domain
{
    public class Match
    {
        public List<Set> Sets { get; set; }

        public Match()
        {
            Sets = new List<Set>();
        }
    }
}
