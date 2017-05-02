using System.Collections.Generic;

namespace Tabletennis.Core.Contracts
{
    public interface IMatch
    {
        List<ISet> Sets { get; set; }

        List<IPlayer> TeamOne { get; set; }

        List<IPlayer> TeamTwo { get; set; }
    }
}
