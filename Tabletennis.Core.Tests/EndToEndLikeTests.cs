using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tabletennis.Demo.Domain;
using Tabletennis.Demo.MatchValidation.Service;

namespace Tabletennis.Core.Tests
{
    [TestClass]
    public class EndToEndLikeTests
    {
        [TestMethod]
        public void CreateSingleMatch()
        {
            var match = new SingleMatch();

            match.TeamOne.Add(new Player { Id = Guid.NewGuid(), CurrentRating = new Random().Next(1200, 1700) });
            match.TeamTwo.Add(new Player { Id = Guid.NewGuid(), CurrentRating = new Random().Next(1210, 1680) });

            match.Sets.Add(new Set{ Score1 = 11, Score2 = 2 });
            match.Sets.Add(new Set { Score1 = 11, Score2 = 2 });
            match.Sets.Add(new Set { Score1 = 11, Score2 = 2 });

            var matchValService = new MatchValidationService();

            var matchValidationOutput = matchValService.ValidateMatch(match);
        }
    }
}
