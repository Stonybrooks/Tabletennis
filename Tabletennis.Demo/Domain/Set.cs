using Tabletennis.Core.Contracts;

namespace Tabletennis.Demo.Domain
{
    public class Set : ISet
    {
        public uint Score1 { get; set; }

        public uint Score2 { get; set; }
    }
}
