using System.Collections.Generic;
using Tabletennis.Core.Contracts;

namespace Tabletennis.Core.Domain
{  
    public abstract class Match : IMatch
    {
        public List<ISet> Sets { get; set; }

        protected Match()
        {
            Sets = new List<ISet>();
        }
    }
}
