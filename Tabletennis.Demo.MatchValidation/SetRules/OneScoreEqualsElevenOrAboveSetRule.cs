using System;
using Tabletennis.Core.Contracts;
using Tabletennis.Core.Domain;

namespace Tabletennis.Demo.MatchValidation.SetRules
{
    public class OneScoreEqualsElevenOrAboveSetRule : ISetRule
    {
        public bool Execute(Set set)
        {
            if (set == null) { throw new ArgumentNullException(nameof(set)); }

            return set.Score1 >= 11 || set.Score2 >= 11;
        }
    }
}
