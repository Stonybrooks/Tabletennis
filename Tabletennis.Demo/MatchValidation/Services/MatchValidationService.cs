using System;
using System.Collections.Generic;
using System.Linq;
using Tabletennis.Core.Contracts;
using Tabletennis.Core.Contracts.MatchValidation;
using Tabletennis.Demo.MatchValidation.SetRules;

namespace Tabletennis.Demo.MatchValidation.Services
{
    public class MatchValidationService : IMatchValidationService
    {
        public List<ISetRule> SetRules { get; set; }

        #region constructor(s)

        public MatchValidationService()
        {
            SetRules = new List<ISetRule>
            {
                new PointsAreNotEqualSetRule(),
                new TwoPointDifferenceSetRule(),
                new OneScoreEqualsElevenOrAboveSetRule()
            };
        }

        public MatchValidationService(List<ISetRule> setRules)
        {
            if (setRules == null) { throw new ArgumentNullException(nameof(setRules)); }

            SetRules = setRules;
        }

        #endregion

        #region IMatchValidationService

        public IMatchValidationOutput ValidateMatch(IMatch match)
        {
            if (match == null) { throw new ArgumentNullException(nameof(match)); }

            var validationOutput = new MatchValidationOutput();

            #region Execute match set validation

            var matchSetsValidationResults = ValidateSets(match.Sets);

            if (matchSetsValidationResults.Any(s => !s.IsValid))
            {
                validationOutput.Result = MatchValidationResult.Invalid;
                validationOutput.ValidationInformation = "Match contains invalid set.";
            }
            else
            {
                validationOutput.Result = MatchValidationResult.Valid;
            }

            #endregion

            return validationOutput;
        }

        #endregion

        #region private methods

        private List<SetValidationResult> ValidateSets(List<ISet> sets)
        {
            // INFO: Argument parameter name is changed because this is a private method. So this name gives more transparence to the caller of 'ValidateMatch(Match match)'
            // ReSharper disable once NotResolvedInText
            if (sets == null) throw new ArgumentNullException("match.Sets");

            // INFO: Argument parameter name is changed because this is a private method. So this name gives more transparence to the caller of 'ValidateMatch(Match match)'
            // ReSharper disable once NotResolvedInText
            if (sets.Count == 0) throw new ArgumentException("Value cannot be an empty collection.", "match.Sets");

            var validationResults = new List<SetValidationResult>();

            foreach (var set in sets)
                validationResults.Add(ValidateSet(set));

            return validationResults;
        }

        private SetValidationResult ValidateSet(ISet set)
        {
            if (set == null) { throw new ArgumentNullException(nameof(set)); }

            var validationResult = new SetValidationResult { IsValid = true };

            foreach (var setRule in SetRules)
            {
                var parsedSetRuleValidation = setRule.Execute(set);

                if (!parsedSetRuleValidation)
                {
                    // if the set failes to parse one rule, we set IsValid to 'false', and break out of the foreach loop 
                    validationResult.IsValid = false;

                    break;
                }
            }

            return validationResult;
        }

        #endregion
    }
}