namespace SPS.Assignment.Core.Tests
{
    [TestFixture]
    public class Card_CompareTo
    {
        Card card1;
        Card card2;
        Card card3;
        Card card4;

        [SetUp]
        public void SetUp()
        {
            card1 = new(Suit.Club, Rank.Five);
            card2 = new(Suit.Diamond, Rank.Four);
            card3 = new(Suit.Spade, Rank.Jack);
            card4 = new(Suit.Diamond, Rank.Four);
        }

        [Test]
        public void CompareTo_FourShoudLowerThanJack_ReturnTrue()
        {
            Assert.That(card2.CompareTo(card3), Is.LessThan(0));
        }

        [Test]
        public void CompareTo_FiveShouldBiggerThanFour_ReturnTrue()
        {
            Assert.That(card1.CompareTo(card4), Is.GreaterThan(0));
        }
    }

    [TestFixture]
    public class Card_Equals
    {
        Card card2;
        Card card4;

        [SetUp]
        public void SetUp()
        {
            card2 = new(Suit.Diamond, Rank.Four);
            card4 = new(Suit.Diamond, Rank.Four);
        }

        [Test]
        public void Equals_ShouldSameCards_ReturnTrue()
        {
            Assert.That(card2.Equals(card4), Is.True);
        }
    }
}
