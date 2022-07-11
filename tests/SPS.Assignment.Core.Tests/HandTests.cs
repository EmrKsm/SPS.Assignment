namespace SPS.Assignment.Core.Tests
{
    [TestFixture]
    public class Hand_CompareTo
    {
        Hand hand1; // flush
        Hand hand2; // straigt
        Hand hand3; // flush with high card
        IHandCalculator handCalculator;

        [SetUp]
        public void SetUp()
        {
            handCalculator = new HandStatusCalculator();

            hand1 = new Hand(new Card[]
                {
                    new Card(Suit.Club, Rank.Two),
                    new Card(Suit.Club, Rank.Jack),
                    new Card(Suit.Club, Rank.Ten),
                    new Card(Suit.Club, Rank.Three),
                    new Card(Suit.Club, Rank.Nine)
                }, handCalculator);

            hand2 = new Hand(new Card[]
                {
                    new Card(Suit.Club, Rank.Two),
                    new Card(Suit.Diamond, Rank.Three),
                    new Card(Suit.Spade, Rank.Four),
                    new Card(Suit.Heart, Rank.Five),
                    new Card(Suit.Club, Rank.Six)
                }, handCalculator);

            hand3 = new Hand(new Card[]
                {
                    new Card(Suit.Club, Rank.Two),
                    new Card(Suit.Club, Rank.Jack),
                    new Card(Suit.Club, Rank.Ten),
                    new Card(Suit.Club, Rank.Three),
                    new Card(Suit.Club, Rank.Ace)
                }, handCalculator);
        }

        [Test]
        public void CompareTo_FlushShouldBiggerThanStraight_ReturnTrue()
        {
            Assert.That(hand1.CompareTo(hand2), Is.GreaterThan(0));
        }

        [Test]
        public void CompareTo_FlushShouldLowerThanHighFlush_ReturnTrue()
        {
            Assert.That(hand3.CompareTo(hand2), Is.GreaterThan(0));
        }
    }

    [TestFixture]
    public class Hand_Equals
    {
        Hand hand1; // flush
        Hand hand3; // flush with high card
        IHandCalculator handCalculator;

        [SetUp]
        public void SetUp()
        {
            handCalculator = new HandStatusCalculator();

            hand1 = new Hand(new Card[]
                {
                    new Card(Suit.Club, Rank.Two),
                    new Card(Suit.Club, Rank.Jack),
                    new Card(Suit.Club, Rank.Ten),
                    new Card(Suit.Club, Rank.Three),
                    new Card(Suit.Club, Rank.Nine)
                }, handCalculator);

            hand3 = new Hand(new Card[]
                {
                    new Card(Suit.Club, Rank.Two),
                    new Card(Suit.Club, Rank.Jack),
                    new Card(Suit.Club, Rank.Ten),
                    new Card(Suit.Club, Rank.Three),
                    new Card(Suit.Club, Rank.Ace)
                }, handCalculator);
        }

        [Test]
        public void Equals_FlushAndHighFlushShouldHasSameStatus_ReturnTrue()
        {
            Assert.That(hand1, Is.EqualTo(hand3));
        }
    }
}
