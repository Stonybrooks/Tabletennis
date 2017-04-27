using System.Collections.Generic;
using Tabletennis.Core.Contracts.MatchValidation;

namespace Tabletennis.Core.Contracts
{
    public interface IMatch
    {
        List<ISet> Sets { get; set; }
    }
}
