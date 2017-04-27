using System.Collections.Generic;

namespace Tabletennis.Core.Contracts.MatchValidation
{
    public interface IMatchValidationService
    {
        List<ISetRule> SetRules { get; set; }

        IMatchValidationOutput ValidateMatch(IMatch match);
    }
}
