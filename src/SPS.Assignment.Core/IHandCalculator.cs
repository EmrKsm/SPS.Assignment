namespace SPS.Assignment.Core
{
    public interface IHandCalculator
    {
        bool IsFlush(Hand hand);
        bool IsStraight(Hand hand);
        bool IsStraightFlush(Hand hand);
        bool IsRoyalFlush(Hand hand);
        bool IsFullHouse(Hand hand);
        bool IsFourOfAKind(Hand hand);
        bool IsThreeOfAKind(Hand hand);
        bool IsTwoPair(Hand hand);
        bool IsOnePair(Hand hand);
        HandStatus CreateHandStatus(Hand hand);
    }
}
