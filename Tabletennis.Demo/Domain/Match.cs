using System;
using System.Collections.Generic;
using Tabletennis.Core.Contracts;

namespace Tabletennis.Demo.Domain
{  
    public abstract class Match : IMatch
    {
        public DateTime Created { get; private set; }

        public List<ISet> Sets { get; set; }

        public List<IPlayer> TeamOne { get; set; }

        public List<IPlayer> TeamTwo { get; set; }

        protected Match()
        {
            Created = DateTime.Now;
            Sets = new List<ISet>();
            TeamOne = new List<IPlayer>();
            TeamTwo = new List<IPlayer>();
        }

        public virtual void Addset(Set set)
        {
            Sets.Add(set);
        }
    }
}
