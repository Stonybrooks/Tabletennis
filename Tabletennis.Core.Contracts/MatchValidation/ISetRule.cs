
namespace Tabletennis.Core.Contracts.MatchValidation
{
    public interface ISetRule
    {
        bool Execute(ISet set);
    }
}