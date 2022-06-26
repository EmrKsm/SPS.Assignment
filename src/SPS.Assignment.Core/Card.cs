namespace SPS.Assignment.Core
{
    public sealed record Card : IComparable<Card>, IEquatable<Card>
    {
        public Rank Rank { get; private set; }
        public Suit Suit { get; private set; }

        public Card(Suit suit, Rank rank)
        {
            Rank = rank;
            Suit = suit;
        }

        public int CompareTo(Card other) => Rank.CompareTo(other.Rank);

        public bool Equals(Card other)
        {
            if (ReferenceEquals(null, other))
                return false;

            if (ReferenceEquals(this, other))
                return true;

            return Suit.Equals(other.Suit) &&
                Rank.Equals(other.Rank);

        }

        public override int GetHashCode()
        {
            throw new NotImplementedException();
        }
    }
}
