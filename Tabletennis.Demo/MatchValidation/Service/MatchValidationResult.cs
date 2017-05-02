using Tabletennis.Core.Contracts.MatchValidation;

namespace Tabletennis.Demo.MatchValidation.Service
{
    public class MatchValidationOutput : IMatchValidationOutput
    {
        public MatchValidationResult Result { get; set; }
        public string ValidationInformation { get; set; }
    }
}