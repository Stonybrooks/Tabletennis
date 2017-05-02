using System;
using Tabletennis.Core.Contracts;

namespace Tabletennis.Demo.Domain
{
    public class Player : IPlayer
    {
        public Guid Id { get; set; }
        public double CurrentRating { get; set; }
    }
}
