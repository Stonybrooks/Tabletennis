﻿using System;
using Tabletennis.Core.Contracts;
using Tabletennis.Core.Contracts.MatchValidation;

namespace Tabletennis.Demo.MatchValidation.SetRules
{
    public class OneScoreEqualsElevenOrAboveSetRule : ISetRule
    {
        public bool Execute(ISet set)
        {
            if (set == null) { throw new ArgumentNullException(nameof(set)); }

            return set.Score1 >= 11 || set.Score2 >= 11;
        }

        public override string ToString()
        {
            return "OneScoreEqualsElevenOrAboveSetRule";
        }
    }
}
