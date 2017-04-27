using System.Collections.Generic;
using Tabletennis.Core.Domain;

namespace Tabletennis.Core.Contracts.MatchValidation
{
    public interface IMatchValidationService
    {
        List<ISetRule> SetRules { get; set; }

        MatchValidationOutput ValidateMatch(Match match);
    }
}
