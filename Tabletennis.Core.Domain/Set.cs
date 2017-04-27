namespace Tabletennis.Core.Domain
{
    public class Set
    {
        private uint _score1;

        public uint Score1
        {
            get { return _score1; }
            set { _score1 = value; }
        }

        private uint _score2;

        public uint Score2
        {
            get { return _score2; }
            set { _score2 = value; }
        }

    }
}
