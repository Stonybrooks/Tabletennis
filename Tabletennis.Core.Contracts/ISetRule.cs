using Tabletennis.Core.Domain;

namespace Tabletennis.Core.Contracts
{
    public interface ISetRule
    {
        bool Execute(Set set);
    }
}