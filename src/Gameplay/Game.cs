using System.ComponentModel;
using IO;

namespace Pasjans
{
    // Entry Point and Installer + Manager -- bad practice
    public class Game
    {
        readonly List<CardColumn> columns = new();
        readonly List<SymbolPackage> packs = new();
        readonly CardRestock restock;
        readonly Screen screen = new();
        readonly CardDrawer cardRender;
        readonly CardTemp cardTemp = new();
        Cursor cursor;
        CommandHistory history = new();

        readonly public int ColumnsAmountExcluding;
        readonly public int DeepestColumn;
        // Difficulty

        public event Action? OnGameEnd;


        // no acces, only for give cards to columns and give cards to restock
        public Game(Cursor cursor, CardDeck deck, int columnsAmountExcluding = 8)
        {
            this.cursor = cursor;

            this.ColumnsAmountExcluding = columnsAmountExcluding;

            deck.Shuffle();
            DeepestColumn = columnsAmountExcluding - 1;
            for (int i = 0; i < columnsAmountExcluding; i++)
            {
                LinkedList<Card> cards = new();
                for (int j = 0; j < i; j++)
                {
                    cards.AddFirst(deck.TakeCard());
                }
                CardColumn newColumn = new CardColumn(cards);
                columns.Add(newColumn);

            }
            restock = new CardRestock(deck.TakeRemainingCards());

            CardSymbol[] symbols = (CardSymbol[])Enum.GetValues(typeof(CardSymbol));

            foreach (var item in symbols)
            {
                packs.Add(new SymbolPackage(item));
            }
            cardRender = new(screen);
        }

        public void GameLoop()
        {
            Draw();
        }

        public void Draw()
        {
            // wyczysc żeby było puste
            screen.ClearScreen();
            screen.ClearConsole();
            //rysujemy columny
            for (int i = columns.Count - 1; i >= 0; i--)
            {
                cardRender.DrawColumn(new Vector2(0, i * cardRender.cardWidth - cardRender.cardWidth), columns[i].GetListUnkown());
            }
            // rysujemy stosy
            var symbols = Enum.GetValues(typeof(CardSymbol));
            for (int i = 0; i < symbols.Length; i++)
            {
                cardRender.DrawCardWithSymbol(new Vector2(i * cardRender.cardWidth, DeepestColumn * cardRender.cardHeight), (CardSymbol)symbols.GetValue(i));
            }

            // rysujemy rezerwowy 
            Vector2 reservePos = new Vector2(symbols.Length * cardRender.cardWidth + cardRender.cardWidth, DeepestColumn * cardRender.cardHeight);
            if (restock.PeekCardCurrent() != null)
            {
                cardRender.DrawUnknownCard(reservePos);
            }
            else
            {
                cardRender.DrawEmptyCard(reservePos, ConsoleColor.White);
            }
            // rysujemy karte ze stozu rezerwowego
            reservePos.X += cardRender.cardWidth;
            if (restock.PeekCardLefted() != null)
            {
                cardRender.DrawCard(reservePos, restock.PeekCardLefted());
            }
            else
            {
                cardRender.DrawEmptyCard(reservePos, ConsoleColor.White);
            }
            // rysujemy wzięte karty
            if (cardTemp.Peek() != null)
            {
                cardRender.DrawColumn(new Vector2(0, cardRender.cardWidth * ColumnsAmountExcluding), new(cardTemp.Peek(), 0), ConsoleColor.Blue);
            }
            // rysujemy cursor ostantim dla override 
            cardRender.DrawCardCoursour(new Vector2(cursor.X * cardRender.cardWidth, cursor.Y * cardRender.cardHeight), ConsoleColor.Green);

            screen.Display();
        }
        public Game Clone()
        {
            throw new NotImplementedException();
        }
        public void Undo()
        {
            Command command = history.pop();
            if (command != null)
            {
                command.undo();
            }
            else
            {
                System.Console.WriteLine("At last Change");
            }
        }
        public void ExecuteCommand(int x, int y)
        {
            // bad practices alarm, too many hard coded commands reffered to current interface layout :/
            if (y < DeepestColumn) // 0 - 6 rows 
            {
                if (cardTemp.isEmpty())
                {
                    //ExecuteCommand(); take command 
                }
                else
                {
                    //ExecuteCommand();  put command 
                }
            }
            else // 7 row
            {
                if (x < packs.Count) // 4
                {
                    //ExecuteCommand(); try put command; // 0,1,2,3 
                }
                else if (x > packs.Count) // 4
                {
                    if (x == packs.Count + 1)
                    {
                        // ExecuteCommand(); // 5
                    }
                    else
                    {
                        // ExecuteCommand(); // 6   
                    }
                }
            }

        }
        /*
        void ExecuteCommand(Command command)
        {
            if (command.Execute())
            {
                history.push(command);
            }
        }
        */
        void EndGame()
        {
            OnGameEnd?.Invoke();
        }
    }
}
