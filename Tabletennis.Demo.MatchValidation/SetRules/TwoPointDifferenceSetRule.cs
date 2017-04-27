using System;
using Tabletennis.Core.Contracts;
using Tabletennis.Core.Contracts.MatchValidation;
using Tabletennis.Core.Domain;

namespace Tabletennis.Demo.MatchValidation.SetRules
{
    public class TwoPointDifferenceSetRule : ISetRule
    {
        public bool Execute(ISet set)
        {
            if (set == null) { throw new ArgumentNullException(nameof(set)); }

            uint remaings = 0;

            if (set.Score1 > set.Score2)
            {
                remaings = set.Score1 - set.Score2;
                
            }
            else
            {
                remaings = set.Score2 - set.Score1;
            }

            return remaings >= 2;
        }
    }
}