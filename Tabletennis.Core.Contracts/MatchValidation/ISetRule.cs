using Tabletennis.Core.Domain;

namespace Tabletennis.Core.Contracts.MatchValidation
{
    public interface ISetRule
    {
        bool Execute(Set set);
    }
}