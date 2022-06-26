namespace SPS.Assignment.ConsoleUI
{
    public class Dealer : IDealer
    {
        private readonly IHandCalculator _handCalculator;

        public Dealer(IHandCalculator handCalculator)
        {
            _handCalculator = handCalculator;
        }

        public List<Round> DealCards(IEnumerable<string> cardInputs)
        {
            List<Round> rounds = new();
            int round = 1;
            foreach (var line in cardInputs)
            {
                Dictionary<string, Hand> playerHands = CreateCardsFromString(line);

                rounds.Add(new Round
                {
                    Number = round,
                    Player1 = playerHands["Player1"],
                    Player2 = playerHands["Player2"],
                });

                round++;
            }

            return rounds;
        }

        private Dictionary<string, Hand> CreateCardsFromString(string line)
        {
            string[] cards = line.Split(' ');

            List<Card> player1Cards = new();
            List<Card> player2Cards = new();

            for (int i = 0; i < 5; i++)
            {
                FillUpCardLists(cards[i], player1Cards);
            }

            for (int i = 5; i < cards.Length; i++)
            {
                FillUpCardLists(cards[i], player2Cards);
            }

            Dictionary<string, Hand> result = new();

            result.Add("Player1", new Hand(player1Cards.ToArray(), _handCalculator));
            result.Add("Player2", new Hand(player2Cards.ToArray(), _handCalculator));

            return result;
        }

        private void FillUpCardLists(string cardText, List<Card> cards)
        {
            Rank rank = cardText[0].ToString().GetRank();
            Suit suit = cardText[1].ToString().GetSuit();

            Card card = new(suit, rank);
            cards.Add(card);
        }
    }
}
