using System.Collections.Generic;
using Tabletennis.Core.Contracts;
using Tabletennis.Core.Contracts.MatchValidation;

namespace Tabletennis.Core.Domain
{  
    public abstract class Match : IMatch
    {
        public List<ISet> Sets { get; set; }

        #region constructor(s)

        protected Match()
        {
            Sets = new List<ISet>();
        }

        #endregion
    }
}
