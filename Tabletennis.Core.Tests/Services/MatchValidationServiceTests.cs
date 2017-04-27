using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tabletennis.Core.Contracts.MatchValidation;
using Tabletennis.Core.Domain;
using Tabletennis.Demo.MatchValidation.Services;
using Tabletennis.Demo.MatchValidation.SetRules;

namespace Tabletennis.Core.Tests.Services
{
    [TestClass]
    public class MatchValidationServiceTests
    {
        [ExpectedException(typeof(ArgumentNullException))]
        [TestMethod]
        public void ValidateMatchWithNullInput__throws_exception()
        {
            Match match = null;
            var sut = new MatchValidationService();

            // ReSharper disable once ExpressionIsAlwaysNull
            sut.ValidateMatch(match);
        }

        [ExpectedException(typeof(ArgumentException))]
        [TestMethod]
        public void ValidateMatchWithEmptyListOfSets__throws_exception()
        {
            var sut = new MatchValidationService();

            var matchValidationOutput = sut.ValidateMatch(new SingleMatch());

            Assert.IsNotNull(matchValidationOutput);
        }

        [TestMethod]
        public void ValidateMatchWithOneSetOfZeroScores__is_invalid()
        {
            var sut = new MatchValidationService
            {
                SetRules = new List<ISetRule>
                {
                    new PointsAreNotEqualSetRule()
                }
            };

            var match = new SingleMatch();
            match.Sets.Add(new Set());


            var matchValidationOutput = sut.ValidateMatch(match);

            Assert.AreEqual(MatchValidationResult.Invalid, matchValidationOutput.Result);
        }

        [TestMethod]
        public void ValidateMatchWithOneSetWithScoreDifferenceOfOne__is_invalid()
        {
            var sut = new MatchValidationService
            {
                SetRules = new List<ISetRule>
                {
                    new TwoPointDifferenceSetRule()
                }
            };

            var match = new SingleMatch();
            match.Sets.Add(new Set{Score1 = 8, Score2 = 7});


            var matchValidationOutput = sut.ValidateMatch(match);

            Assert.AreEqual(MatchValidationResult.Invalid, matchValidationOutput.Result);
        }

        [TestMethod]
        public void ValidateMatchWithOneSetWithScoreDifferenceOfTwo__is_valid()
        {
            var sut = new MatchValidationService
            {
                SetRules = new List<ISetRule>
                {
                    new TwoPointDifferenceSetRule()
                }
            };

            var match = new SingleMatch();
            match.Sets.Add(new Set { Score1 = 9, Score2 = 7 });


            var matchValidationOutput = sut.ValidateMatch(match);

            Assert.AreEqual(MatchValidationResult.Valid, matchValidationOutput.Result);
        }

        [TestMethod]
        public void ValidateMatchWithOneSetWithScoresLowerThanEleven__is_invalid()
        {
            var sut = new MatchValidationService
            {
                SetRules = new List<ISetRule>
                {
                    new OneScoreEqualsElevenOrAboveSetRule()
                }
            };

            var match = new SingleMatch();
            match.Sets.Add(new Set { Score1 = 9, Score2 = 7 });


            var matchValidationOutput = sut.ValidateMatch(match);

            Assert.AreEqual(MatchValidationResult.Invalid, matchValidationOutput.Result);
        }

        [TestMethod]
        public void ValidateMatchWithOneSetWithOneScoreHigherThanEleven__is_valid()
        {
            var sut = new MatchValidationService
            {
                SetRules = new List<ISetRule>
                {
                    new OneScoreEqualsElevenOrAboveSetRule()
                }
            };

            var match = new SingleMatch();
            match.Sets.Add(new Set { Score1 = 12, Score2 = 10 });


            var matchValidationOutput = sut.ValidateMatch(match);

            Assert.AreEqual(MatchValidationResult.Valid, matchValidationOutput.Result);
        }
    }
}
