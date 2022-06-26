using System.ComponentModel;

namespace SPS.Assignment.Core.Extensions
{
    public static class CardExtension
    {
        public static Rank GetRank(this string rank)
        {
            switch (rank)
            {
                case "T":
                    return Rank.Ten;
                case "J":
                    return Rank.Jack;
                case "Q":
                    return Rank.Queen;
                case "K":
                    return Rank.King;
                case "A":
                    return Rank.Ace;
                default:
                    int rankAsInt = Convert.ToInt32(rank);
                    return (Rank)rankAsInt;
            }
        }

        public static Suit GetSuit(this string suit)
        {
            switch (suit)
            {
                case "C":
                    return Suit.Club;
                case "S":
                    return Suit.Spade;
                case "H":
                    return Suit.Heart;
                case "D":
                    return Suit.Diamond;
                default:
                    throw new InvalidEnumArgumentException("Invalid enum");
            }
        }
    }
}
