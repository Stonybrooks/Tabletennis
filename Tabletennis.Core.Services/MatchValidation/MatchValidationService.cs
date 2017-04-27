using System;
using System.Collections.Generic;
using System.Linq;
using Tabletennis.Core.Contracts;
using Tabletennis.Core.Domain;
using Tabletennis.Demo.MatchValidation.SetRules;

namespace Tabletennis.Core.Services.MatchValidation
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

            var output = new MatchValidationOutput();

            var matchSetsValidationResults = ValidateSets(match.Sets);

            if (matchSetsValidationResults.Any(s => !s.IsValid))
            {
                output.Result = MatchValidationResult.Invalid;
                output.ValidationInformation = "Match contains invalid set.";
            }
            else
            {
                output.Result = MatchValidationResult.Valid;
            }

            return output;
        }

        #endregion

        #region private methods

        private List<SetValidationResult> ValidateSets(List<Set> sets)
        {
           
            

            if (sets == null) { throw new ArgumentNullException(nameof(sets)); }
            // ReSharper disable once NotResolvedInText
            if (sets.Count == 0) { throw new ArgumentException("Value cannot be an empty collection.", "match.Sets"); }

            List<SetValidationResult> validationResults = new List<SetValidationResult>();

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

            SetValidationResult validationResult = new SetValidationResult{ IsValid = true };

            foreach (var setRule in SetRules)
            {
                var parsedSetRuleValidation = setRule.Execute(set);
                
                if (!parsedSetRuleValidation)
                {
                    validationResult.IsValid = false;

                    break;
                }
            }

            return validationResult;
        }
        
        #endregion
    }
}
