namespace Tabletennis.Core.Domain
{
    public class MatchValidationOutput
    {
        public MatchValidationResult Result { get; set; }
        public string ValidationInformation { get; set; }
    }

    public enum MatchValidationResult
    {
        Undefined = 0,
        Valid = 1,
        Invalid = 2
    }
}