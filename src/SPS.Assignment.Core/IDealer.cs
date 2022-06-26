namespace SPS.Assignment.Core
{
    public interface IDealer
    {
        List<Round> DealCards(IEnumerable<string> cards);
    }
}
