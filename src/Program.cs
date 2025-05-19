// Punkt wejsczowy do programu 

using IO;
using Pasjans;

class Program
{
    /*
    static void Main(string[] args)
    {
        Screen screen = new();
        CardDrawer render = new CardDrawer(screen);
        CardDeck deck = new();
        deck.Shuffle();
        List<CardColumn> columns = new();
        for (int i = 0; i < 8; i++)
        {
            LinkedList<Card> cards = new();
            for (int j = 0; j < i; j++)
            {
                cards.AddFirst(deck.TakeCard());
            }
            CardColumn newColumn = new CardColumn(cards);
            columns.Add(newColumn);

        }
        //Card card11 = columns[1].GetCard().Value;

        Cursor cursor = new();
        while (true)
        {
            screen.ClearScreen();
            screen.ClearConsole();
            for (int i = columns.Count - 1; i >= 0; i--)
            {
                render.DrawColumn(new Vector2(0, i * 6 - 6), columns[i].GetListUnkown());
            }
            var symbols = Enum.GetValues(typeof(CardSymbol));
            for (int i = 0; i < symbols.Length; i++)
            {
                render.DrawCardWithSymbol(new Vector2(i * 6, 20), (CardSymbol)symbols.GetValue(i));
            }

            render.DrawEmptyCard(new Vector2(cursor.X, cursor.Y), ConsoleColor.Green);

            screen.Display();

            cursor.GetInput();

            if (cursor.X <= 0)
            {
                cursor.X = 0;
            }
            if (cursor.Y <= 0)
            {
                cursor.Y = 0;
            }
            if (cursor.X >= screen.Width)
            {
                cursor.X = screen.Width - 6;
            }
            if (cursor.Y >= screen.Height)
            {
                cursor.Y = screen.Height - 6;
            }

        }
    }
    */
    static void Main(string[] args)
    {
        Cursor cursor = new(1,1);
        Game game = new(cursor,new CardDeck());
        Player player = new(game,cursor);

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
