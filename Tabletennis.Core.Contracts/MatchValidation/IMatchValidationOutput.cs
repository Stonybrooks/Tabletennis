using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tabletennis.Core.Contracts.MatchValidation
{
    public interface IMatchValidationOutput
    {
        MatchValidationResult Result { get; set; }
        string ValidationInformation { get; set; }
    }

    public enum MatchValidationResult
    {
        Undefined = 0,
        Valid = 1,
        Invalid = 2
    }
}
