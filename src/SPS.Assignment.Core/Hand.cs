namespace SPS.Assignment.Core
{
    public class Hand : IComparable<Hand>, IEquatable<Hand>
    {
        private readonly Card[] _cards;

        public readonly IHandCalculator _handCalculator;

        public Card[] Cards => _cards;

        public HandStatus Status => _handCalculator.CreateHandStatus(this);

        public Card HighCard => SortByRank()[_cards.Length - 1];

        public Hand(Card[] cards, IHandCalculator handCalculator)
        {
            _cards = cards;
            _handCalculator = handCalculator;
        }

        public Card[] SortByRank() => _cards.OrderBy(card => (int)card.Rank).ToArray();
        public Card[] SortBySuit() => _cards.OrderBy(card => (int)card.Suit).ToArray();

        public int CompareTo(Hand other)
        {
            if (Equals(other))
                return HighCard.CompareTo(other.HighCard);

            return Status.CompareTo(other.Status);
        }

        public bool Equals(Hand other)
        {
            if (ReferenceEquals(null, other))
                return false;

            if (ReferenceEquals(this, other))
                return true;

            return Status.Equals(other.Status);
        }

        public override int GetHashCode()
        {
            throw new NotImplementedException();
        }
    }
}
