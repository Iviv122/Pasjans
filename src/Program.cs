// Punkt wejsczowy do programu 

using IO;
using Pasjans;

class Program
{
    static void Main(string[] args)
    {
        Cursor cursor = new(1, 1);
        GameTable game = new(cursor, new CardDeck());
        Player player = new(game, cursor);


        bool isPlaying = true;
        game.OnGameEnd += () =>
        {
            isPlaying = false;
        };
        while (isPlaying)
        {
            game.GameLoop();
            player.Input();
        }
    }
}
