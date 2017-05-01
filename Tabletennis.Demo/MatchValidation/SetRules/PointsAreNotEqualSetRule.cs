using System;
using Tabletennis.Core.Contracts;
using Tabletennis.Core.Contracts.MatchValidation;
using Tabletennis.Core.Domain;

namespace Tabletennis.Demo.MatchValidation.SetRules
{
    public class PointsAreNotEqualSetRule : ISetRule
    {
        public bool Execute(ISet set)
        {
            if (set == null) { throw new ArgumentNullException(nameof(set)); }

            return set.Score1 != set.Score2;
        }

        public override string ToString()
        {
            return "PointsAreNotEqualSetRule";
        }
    }
}
