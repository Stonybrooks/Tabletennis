using System;
using System.Collections.Generic;
using System.Linq;
using Tabletennis.Core.Contracts;
using Tabletennis.Core.Domain;
using Tabletennis.Demo.MatchValidation.SetRules;

namespace Tabletennis.Demo.MatchValidation.Services
{
    public class MatchValidationService: IMatchValidationService
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

        public MatchValidationOutput ValidateMatch(Match match)
        {
            if (match == null) { throw new ArgumentNullException(nameof(match)); }

            var validationOutput = new MatchValidationOutput();

            #region Set validation

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

        private List<SetValidationResult> ValidateSets(List<Set> sets)
        {
            // INFO: Argument parameter name is changed because this is a private method. So this name gives more transparence to the caller of 'ValidateMatch(Match match)'
            // ReSharper disable once NotResolvedInText
            if (sets == null) { throw new ArgumentNullException("match.Sets"); }

            // INFO: Argument parameter name is changed because this is a private method. So this name gives more transparence to the caller of 'ValidateMatch(Match match)'
            // ReSharper disable once NotResolvedInText
            if (sets.Count == 0) { throw new ArgumentException("Value cannot be an empty collection.", "match.Sets"); }

            var validationResults = new List<SetValidationResult>();

            foreach (var set in sets)
            {
                // TODO: simplify this so that only uniq sets is validated

                // Example: 
                // Set1 = 12-10
                // Set2 = 8-11
                // Set3 = 11-7
                // Set4 = 11-7
                // Set5 = 8-11
                //
                // Then only validate set: 1,2 and 3

                validationResults.Add(ValidateSet(set));
            }

            return validationResults;
        }

        private SetValidationResult ValidateSet(Set set)
        {
            if (set == null) { throw new ArgumentNullException(nameof(set)); }

            var validationResult = new SetValidationResult{ IsValid = true };

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
