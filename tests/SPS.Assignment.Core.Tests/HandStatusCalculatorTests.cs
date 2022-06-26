namespace SPS.Assignment.Core.Tests
{
    [TestFixture]
    public class HandStatusCalculator_CreateHandStatus
    {
        private static IHandCalculator _handCalculator;

        [SetUp]
        public void SetUp()
        {
            _handCalculator = new HandStatusCalculator();
        }

        static IEnumerable<Hand> GetTestHand(HandStatus status)
        {
            if (status == HandStatus.Flush)
            {
                yield return new Hand(new Card[]
                {
                    new Card(Suit.Club, Rank.Two),
                    new Card(Suit.Club, Rank.Jack),
                    new Card(Suit.Club, Rank.Ten),
                    new Card(Suit.Club, Rank.Three),
                    new Card(Suit.Club, Rank.Nine)
                }, _handCalculator);
            }

            if (status == HandStatus.Straight)
            {
                yield return new Hand(new Card[]
                {
                    new Card(Suit.Club, Rank.Two),
                    new Card(Suit.Diamond, Rank.Three),
                    new Card(Suit.Spade, Rank.Four),
                    new Card(Suit.Heart, Rank.Five),
                    new Card(Suit.Club, Rank.Six)
                }, _handCalculator);
            }

            if (status == HandStatus.StraightFlush)
            {
                yield return new Hand(new Card[]
                {
                    new Card(Suit.Club, Rank.Two),
                    new Card(Suit.Club, Rank.Three),
                    new Card(Suit.Club, Rank.Four),
                    new Card(Suit.Club, Rank.Five),
                    new Card(Suit.Club, Rank.Six)
                }, _handCalculator);
            }

            if (status == HandStatus.RoyalFlush)
            {
                yield return new Hand(new Card[]
                {
                    new Card(Suit.Club, Rank.Ten),
                    new Card(Suit.Club, Rank.Jack),
                    new Card(Suit.Club, Rank.Queen),
                    new Card(Suit.Club, Rank.King),
                    new Card(Suit.Club, Rank.Ace)
                }, _handCalculator);
            }

            if (status == HandStatus.FullHouse)
            {
                yield return new Hand(new Card[]
                {
                    new Card(Suit.Club, Rank.King),
                    new Card(Suit.Spade, Rank.King),
                    new Card(Suit.Diamond, Rank.King),
                    new Card(Suit.Heart, Rank.Three),
                    new Card(Suit.Club, Rank.Three)
                }, _handCalculator);
            }

            if (status == HandStatus.FourOfAKind)
            {
                yield return new Hand(new Card[]
                {
                    new Card(Suit.Club, Rank.Ace),
                    new Card(Suit.Spade, Rank.Ace),
                    new Card(Suit.Diamond, Rank.Ace),
                    new Card(Suit.Heart, Rank.Ace),
                    new Card(Suit.Club, Rank.Three)
                }, _handCalculator);
            }

            if (status == HandStatus.ThreeOfAKind)
            {
                yield return new Hand(new Card[]
                {
                    new Card(Suit.Club, Rank.Ace),
                    new Card(Suit.Spade, Rank.Ace),
                    new Card(Suit.Diamond, Rank.Ace),
                    new Card(Suit.Heart, Rank.Two),
                    new Card(Suit.Club, Rank.Three)
                }, _handCalculator);
            }

            if (status == HandStatus.TwoPair)
            {
                yield return new Hand(new Card[]
                {
                    new Card(Suit.Club, Rank.Ace),
                    new Card(Suit.Spade, Rank.Ace),
                    new Card(Suit.Diamond, Rank.Three),
                    new Card(Suit.Heart, Rank.Three),
                    new Card(Suit.Club, Rank.Eight)
                }, _handCalculator);
            }

            if (status == HandStatus.OnePair)
            {
                yield return new Hand(new Card[]
                {
                    new Card(Suit.Club, Rank.Ace),
                    new Card(Suit.Spade, Rank.Ace),
                    new Card(Suit.Diamond, Rank.Five),
                    new Card(Suit.Heart, Rank.Jack),
                    new Card(Suit.Club, Rank.Three)
                }, _handCalculator);
            }

            if (status == HandStatus.HighCard)
            {
                yield return new Hand(new Card[]
                {
                    new Card(Suit.Club, Rank.Two),
                    new Card(Suit.Spade, Rank.Ace),
                    new Card(Suit.Diamond, Rank.Eight),
                    new Card(Suit.Heart, Rank.Five),
                    new Card(Suit.Club, Rank.Six)
                }, _handCalculator);
            }
        }

        [TestCaseSource(nameof(GetTestHand), new object[] { HandStatus.HighCard })]
        public void HighCard_HighCard_ReturnsTrue(Hand hand)
        {
            HandStatus status = _handCalculator.CreateHandStatus(hand);
            Assert.That(status, Is.EqualTo(HandStatus.HighCard));
        }

        [TestCaseSource(nameof(GetTestHand), new object[] { HandStatus.OnePair })]
        public void OnePair_IsOnePair_ReturnsTrue(Hand hand)
        {
            HandStatus status = _handCalculator.CreateHandStatus(hand);
            Assert.That(status, Is.EqualTo(HandStatus.OnePair));
        }

        [TestCaseSource(nameof(GetTestHand), new object[] { HandStatus.TwoPair })]
        public void TwoPair_IsTwoPair_ReturnsTrue(Hand hand)
        {
            HandStatus status = _handCalculator.CreateHandStatus(hand);
            Assert.That(status, Is.EqualTo(HandStatus.TwoPair));
        }

        [TestCaseSource(nameof(GetTestHand), new object[] { HandStatus.ThreeOfAKind })]
        public void ThreePair_IsThreeOfAKind_ReturnsTrue(Hand hand)
        {
            HandStatus status = _handCalculator.CreateHandStatus(hand);
            Assert.That(status, Is.EqualTo(HandStatus.ThreeOfAKind));
        }

        [TestCaseSource(nameof(GetTestHand), new object[] { HandStatus.Straight })]
        public void Straight_IsStraight_ReturnsTrue(Hand hand)
        {
            HandStatus status = _handCalculator.CreateHandStatus(hand);
            Assert.That(status, Is.EqualTo(HandStatus.Straight));
        }

        [TestCaseSource(nameof(GetTestHand), new object[] { HandStatus.Flush })]
        public void Flush_IsFlush_ReturnsTrue(Hand hand)
        {
            HandStatus status = _handCalculator.CreateHandStatus(hand);
            Assert.That(status, Is.EqualTo(HandStatus.Flush));
        }

        [TestCaseSource(nameof(GetTestHand), new object[] { HandStatus.FullHouse })]
        public void FullHouse_IsFullHouse_ReturnsTrue(Hand hand)
        {
            HandStatus status = _handCalculator.CreateHandStatus(hand);
            Assert.That(status, Is.EqualTo(HandStatus.FullHouse));
        }

        [TestCaseSource(nameof(GetTestHand), new object[] { HandStatus.FourOfAKind })]
        public void FourPair_IsFourOfAKind_ReturnsTrue(Hand hand)
        {
            HandStatus status = _handCalculator.CreateHandStatus(hand);
            Assert.That(status, Is.EqualTo(HandStatus.FourOfAKind));
        }

        [TestCaseSource(nameof(GetTestHand), new object[] { HandStatus.StraightFlush })]
        public void StraightFlush_IsStraightFlush_ReturnsTrue(Hand hand)
        {
            HandStatus status = _handCalculator.CreateHandStatus(hand);
            Assert.That(status, Is.EqualTo(HandStatus.StraightFlush));
        }

        [TestCaseSource(nameof(GetTestHand), new object[] { HandStatus.RoyalFlush })]
        public void RoyalFlush_IsRoyalFlush_ReturnsTrue(Hand hand)
        {
            HandStatus status = _handCalculator.CreateHandStatus(hand);
            Assert.That(status, Is.EqualTo(HandStatus.RoyalFlush));
        }
    }
}