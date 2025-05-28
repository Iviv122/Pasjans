// Punkt wejsczowy do programu 

using Pasjans;

class Program 
{
    static void Main(string[] args)
    {

        // Game game = new();
        Game game = new();

        bool isPlaying = true;
        while (isPlaying)
        {
            //game.GameLoop();
            //player.Input();
            game.Update();
        }
    }
}
