IHandCalculator handStatusCalculator = new HandStatusCalculator();
IDealer dealer = new Dealer(handStatusCalculator);

var lines = await Task.FromResult(FileHelper.GetLines()).Result;
var rounds = dealer.DealCards(lines);
int player1WinCount = 0, player2WinCount = 0;

foreach (var round in rounds)
{
    if (round.Winner == PlayerType.Player1)
        player1WinCount++;
    else
        player2WinCount++;
}

Console.WriteLine($"Player 1 wins {player1WinCount} times.");
Console.WriteLine($"Player 2 wins {player2WinCount} times.");
