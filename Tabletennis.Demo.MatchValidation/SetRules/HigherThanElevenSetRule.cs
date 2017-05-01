using System;
using Tabletennis.Core.Contracts;
using Tabletennis.Core.Contracts.MatchValidation;

namespace Tabletennis.Demo.MatchValidation.SetRules
{
    public class HigherThanElevenOtherScoreMustBeNineOrAboveSetRule : ISetRule
    {
        public bool Execute(ISet set)
        {
            if (set == null) { throw new ArgumentNullException(nameof(set)); }

            uint highestScore;
            uint lowestScore;

            if (set.Score1 > set.Score2)
            {
                highestScore = set.Score1;
                lowestScore = set.Score2;
            }
            else
            {
                highestScore = set.Score2;
                lowestScore = set.Score1;
            }

            if (highestScore > 11 && lowestScore < 9)
            {
                return false;
            }

            return true;
        }

        public override string ToString()
        {
            return "HigherThanElevenOtherScoreMustBeNineOrAboveSetRule";
        }
    }
}
