namespace SPS.Assignment.Core
{
    public record Round
    {
        public int Number { get; init; }
        public Hand Player1 { get; init; }
        public Hand Player2 { get; init; }
        public PlayerType Winner => Player1.CompareTo(Player2) < 0 ? PlayerType.Player2 : PlayerType.Player1;
    }
}
