using System.Collections.Generic;

namespace Tabletennis.Core.Contracts
{
    public interface IMatch
    {
        List<ISet> Sets { get; set; }
    }
}
