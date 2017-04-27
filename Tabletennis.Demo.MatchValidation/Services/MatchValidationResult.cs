using Tabletennis.Core.Contracts.MatchValidation;

namespace Tabletennis.Demo.MatchValidation.Services
{
    public class MatchValidationOutput : IMatchValidationOutput
    {
        public MatchValidationResult Result { get; set; }
        public string ValidationInformation { get; set; }
    }

    //public enum MatchValidationResult
    //{
    //    Undefined = 0,
    //    Valid = 1,
    //    Invalid = 2
    //}
}