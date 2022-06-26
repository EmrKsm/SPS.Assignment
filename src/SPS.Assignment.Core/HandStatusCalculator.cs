namespace SPS.Assignment.Core
{
    public class HandStatusCalculator : IHandCalculator
    {
        public bool IsFlush(Hand hand)
        {
            Card[] sortedCards = hand.SortBySuit();
            int lastCardIndex = sortedCards.Length - 1;

            return sortedCards[0].Suit.Equals(sortedCards[lastCardIndex].Suit);
        }

        public bool IsStraight(Hand hand)
        {
            Card[] sortedCards = hand.SortByRank();

            int sequentialRank = (int)sortedCards[0].Rank + 1;

            for (int i = 1; i < sortedCards.Count(); i++)
            {
                if ((int)sortedCards[i].Rank != sequentialRank)
                {
                    return false;
                }

                sequentialRank++;
            }

            return true;

        }

        public bool IsStraightFlush(Hand hand) => IsStraight(hand) && IsFlush(hand);

        public bool IsRoyalFlush(Hand hand) => IsStraightFlush(hand) && hand.Cards.Last().Rank == Rank.Ace;

        public bool IsFullHouse(Hand hand)
        {
            Card[] sortedCards = hand.SortByRank();

            // 11122
            bool lowFullHouse = (int)sortedCards[0].Rank == (int)sortedCards[1].Rank &&
                                (int)sortedCards[1].Rank == (int)sortedCards[2].Rank &&
                                (int)sortedCards[3].Rank == (int)sortedCards[4].Rank;
            // 11222
            bool highFullHouse = (int)sortedCards[0].Rank == (int)sortedCards[1].Rank &&
                                 (int)sortedCards[2].Rank == (int)sortedCards[3].Rank &&
                                 (int)sortedCards[3].Rank == (int)sortedCards[4].Rank;

            return lowFullHouse || highFullHouse;
        }

        public bool IsFourOfAKind(Hand hand)
        {
            Card[] sortedCards = hand.SortByRank();

            // 11112
            bool lowFourOfAKind = (int)sortedCards[0].Rank == (int)sortedCards[1].Rank &&
                                  (int)sortedCards[1].Rank == (int)sortedCards[2].Rank &&
                                  (int)sortedCards[2].Rank == (int)sortedCards[3].Rank;
            // 12222
            bool highFourOfAKind = (int)sortedCards[1].Rank == (int)sortedCards[2].Rank &&
                                   (int)sortedCards[2].Rank == (int)sortedCards[3].Rank &&
                                   (int)sortedCards[3].Rank == (int)sortedCards[4].Rank;

            return lowFourOfAKind || highFourOfAKind;
        }

        public bool IsThreeOfAKind(Hand hand)
        {
            Card[] sortedCards = hand.SortByRank();

            // 11123
            bool lowThreeOfAKind = (int)sortedCards[0].Rank == (int)sortedCards[1].Rank &&
                                    (int)sortedCards[1].Rank == (int)sortedCards[2].Rank;
            // 12223
            bool middleThreeOfAKind = (int)sortedCards[1].Rank == (int)sortedCards[2].Rank &&
                                      (int)sortedCards[2].Rank == (int)sortedCards[3].Rank;
            // 12333
            bool highThreeOfAKind = (int)sortedCards[2].Rank == (int)sortedCards[3].Rank &&
                                     (int)sortedCards[3].Rank == (int)sortedCards[4].Rank;

            return lowThreeOfAKind || middleThreeOfAKind || highThreeOfAKind;
        }

        public bool IsTwoPair(Hand hand)
        {
            Card[] sortedCards = hand.SortByRank();

            // 11223
            bool lowTwoPair = (int)sortedCards[0].Rank == (int)sortedCards[1].Rank &&
                              (int)sortedCards[2].Rank == (int)sortedCards[3].Rank;
            // 11233
            bool cornerTwoPair = (int)sortedCards[0].Rank == (int)sortedCards[1].Rank &&
                                 (int)sortedCards[3].Rank == (int)sortedCards[4].Rank;
            // 12233
            bool highTwoPair = (int)sortedCards[1].Rank == (int)sortedCards[2].Rank &&
                               (int)sortedCards[3].Rank == (int)sortedCards[4].Rank;

            return lowTwoPair || cornerTwoPair || highTwoPair;
        }

        public bool IsOnePair(Hand hand)
        {
            Card[] sortedCards = hand.SortByRank();

            // 11234
            bool lowPair = (int)sortedCards[0].Rank == (int)sortedCards[1].Rank;
            // 12234
            bool lowerMiddlePair = (int)sortedCards[1].Rank == (int)sortedCards[2].Rank;
            // 12334
            bool higherMiddlePair = (int)sortedCards[2].Rank == (int)sortedCards[3].Rank;
            // 12344
            bool higherPair = (int)sortedCards[3].Rank == (int)sortedCards[4].Rank;

            return lowPair || lowerMiddlePair || higherMiddlePair || higherPair;
        }

        public HandStatus CreateHandStatus(Hand hand)
        {
            if (IsRoyalFlush(hand))
                return HandStatus.RoyalFlush;

            if (IsStraightFlush(hand))
                return HandStatus.StraightFlush;

            if (IsFourOfAKind(hand))
                return HandStatus.FourOfAKind;

            if (IsFullHouse(hand))
                return HandStatus.FullHouse;

            if (IsFlush(hand))
                return HandStatus.Flush;

            if (IsStraight(hand))
                return HandStatus.Straight;

            if (IsThreeOfAKind(hand))
                return HandStatus.ThreeOfAKind;

            if (IsTwoPair(hand))
                return HandStatus.TwoPair;

            if (IsOnePair(hand))
                return HandStatus.OnePair;

            return HandStatus.HighCard;

        }
    }
}
