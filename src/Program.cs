// Punkt wejsczowy do programu 

using Pasjans;

class Program
{
public const char SpadeSymbol = '\u2660';    // ♠
public const char ClubSymbol = '\u2663';     // ♣
public const char HeartSymbol = '\u2665';    // ♥
public const char DiamondSymbol = '\u2666';  // ♦

    static void Main(string[] args)
    {
        Game game = new Game(new CardDeck());
        System.Console.WriteLine(game);
    }
}
