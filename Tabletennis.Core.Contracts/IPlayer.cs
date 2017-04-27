using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tabletennis.Core.Contracts
{
    public interface IPlayer
    {
        Guid Id { get; set; }
        double CurrentRating { get; set; }
    }
}
