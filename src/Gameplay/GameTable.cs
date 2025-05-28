using IO;
using Menu.ButtonDrawer;

namespace Pasjans
{
    // Entry Point and Installer + Manager -- bad practice
    public class GameTable
    {
        List<CardColumn> columns = new();
        List<SymbolPackage> packs = new();
        CardRestock restock;
        Screen screen;
        CardDrawer cardRender;
        CardTemp cardTemp = new();
        Cursor cursor;
        CommandHistory history = new();
        ButtonDraw buttonDraw;

        Difficulty difficulty;
        public Difficulty Difficulty => difficulty;
        public IReadOnlyList<CardColumn> Columns => columns;
        public IReadOnlyList<SymbolPackage> Packs => packs;
        public CardRestock Restock => restock;
        public CardTemp CardTemp => cardTemp;
        public Cursor Cursor => cursor;

        readonly public int ColumnsAmountExcluding;
        readonly public int DeepestColumn;
        // Difficulty

        // how many packs left
        int PackCounter = 0;
        // ile tur zrobiono
        int turnsMade = 0;
        public int TurnsMade 
        {
            get { return turnsMade; }
            set
            {
                if (value <= 0)
                {
                    turnsMade = 0;
                }
                else
                {
                    turnsMade = value;
                }
            }
        }
        public event Action? OnGameEnd;
        public event Action? OnGameExit;

        // no acces, only for give cards to columns and give cards to restock
        public GameTable(Cursor cursor, CardDeck deck, Screen screen, int columnAmountExluding = 8)
        {
            this.cursor = cursor;
            this.buttonDraw = new(screen);
            this.ColumnsAmountExcluding = columnAmountExluding;

            deck.Shuffle();
            DeepestColumn = Card.MaxValue;
            for (int i = 1; i <= columnAmountExluding; i++)
            {
                LinkedList<Card> cards = new();
                for (int j = 1; j < i; j++)
                {
                    cards.AddFirst(deck.TakeCard());

                }
                CardColumn newColumn = new CardColumn(cards);
                columns.Add(newColumn);

            }
            restock = new CardRestock(deck.TakeRemainingCards());

            CardSymbol[] symbols = (CardSymbol[])Enum.GetValues(typeof(CardSymbol));

            //CardSymbol[] symbols = {CardSymbol.Clubs};

            foreach (var item in symbols)
            {
                SymbolPackage package = new(item);
                package.OnCardFill += TryWin;
                packs.Add(package);

                PackCounter++;
            }
            cardRender = new(screen);
            this.screen = screen;
        }
        public void SetDifficulty(Difficulty level)
        {
            switch (level)
            {
                case Difficulty.Easy:
                    difficulty = level;
                    break;
                case Difficulty.Hard:
                    difficulty = level;
                    break;
            }
        }
        private GameTable(Cursor cursor, List<CardColumn> columns, List<SymbolPackage> packs, CardRestock restock, CardTemp cardTemp, int turnsMade)
        {
            this.cursor = cursor;
            this.columns = columns;
            this.packs = packs;
            this.restock = restock;
            this.cardTemp = cardTemp;
            this.turnsMade = turnsMade;
        }

        public void GameLoop()
        {
            Draw();
        }

        public void TryWin()
        {
            PackCounter--;
            if (PackCounter == 0)
            {
                OnGameEnd?.Invoke();
            }
        }

        private void Draw()
        {
            // wyczysc żeby było puste

            screen.ClearConsole();
            screen.ClearScreen();
            //rysujemy columny
            for (int i = columns.Count - 1; i >= 0; i--)
            {
                cardRender.DrawColumn(new Vector2(0, i * cardRender.cardWidth), columns[i].GetListUnkown());
            }

            Vector2 reservePos = new Vector2(cardRender.cardWidth * ColumnsAmountExcluding + cardRender.cardWidth, 0);
            // rysujemy stosy
            for (int i = 0; i < packs.Count; i++)
            {
                if (packs.ElementAt(i).NextCardValue() == Card.MinValue)
                {
                    cardRender.DrawCardWithSymbol(reservePos, packs.ElementAt(i).CardSymbol);
                }
                else
                {
                    cardRender.DrawCard(reservePos, new Card(packs.ElementAt(i).Value(), packs.ElementAt(i).CardSymbol));
                }
                reservePos.X += cardRender.cardWidth;
            }
            reservePos.X += cardRender.cardWidth;
            // rysujemy rezerwowy 
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
                cardRender.DrawColumn(new Vector2(0, 0), new(cardTemp.Peek(), 0), ConsoleColor.Blue);
            }
            // rysujemy cursor ostantim dla override 
            cardRender.DrawCardCoursour(new Vector2(cursor.X * cardRender.cardWidth, cursor.Y * cardRender.cardOffset), ConsoleColor.Green);

            buttonDraw.DrawButton(new Vector2(reservePos.X, 20), new Vector2(20, 3),$"Turns: {turnsMade}");

            screen.Display();
        }
        public GameTable Clone()
        {

            List<CardColumn> Ncolumns = new();
            List<SymbolPackage> NPackage = new();
            //throw new NotImplementedException();
            foreach (CardColumn item in columns)
            {
                Ncolumns.Add(item.Clone());
            }
            foreach (SymbolPackage item in packs)
            {
                NPackage.Add(item.Clone());
            }
            return new GameTable(cursor, Ncolumns, NPackage, restock.Clone(), cardTemp.Clone(),turnsMade);
        }
        public void Restore(GameTable table)
        {
            columns = table.columns.Select(c => c.Clone()).ToList();
            packs = table.packs.Select(p => p.Clone()).ToList();
            restock = table.restock.Clone();
            cardTemp = table.cardTemp.Clone();
            turnsMade = table.turnsMade;
        }
        public void Undo()
        {
            Command command = history.pop();
            if (command != null)
            {
                command.undo();
            }
        }
        public void ExecuteCommand(int x, int y)
        {
            // bad practices alarm, too many hard coded commands reffered to current interface layout :/


            if (x < columns.Count && x > 0)
            {

                if (cardTemp.isEmpty())
                {
                    ExecuteCommand(new TakeCommand(this), x, y, (ITake)columns.ElementAt(x));
                    return;
                }
                else
                {
                    ExecuteCommand(new PutCommand(this), x, y, (IPut)columns.ElementAt(x));
                    return;
                }
            }
            x -= columns.Count + 1;
            if (x >= 0 && x < packs.Count) // 9,12
            {

                ExecuteCommand(new PutCommand(this), x, y, packs.ElementAt(x));
                return;
            }
            x -= packs.Count + 1;
            if (x == 0) // 14,15
            {
                ExecuteCommand(new NextCommand(this), x, y); // ExecuteCommand(); // 6 
                return;
            }
            else
            {
                ExecuteCommand(new TakeCommand(this), x, y, restock); // ExecuteCommand(); // 6   
                return;
            }
        }
        void ExecuteCommand(Command command, int x, int y)
        {
            if (command.Execute(x, y))
            {
                history.push(command);
            }
        }
        void ExecuteCommand(Command command, int x, int y, ITake source)
        {
            if (command.Execute(x, y, source))
            {
                history.push(command);
            }
        }
        void ExecuteCommand(Command command, int x, int y, IPut dest)
        {
            if (command.Execute(x, y, dest))
            {
                history.push(command);
            }
        }
        void EndGame()
        {
            OnGameEnd?.Invoke();
        }
        public override string ToString()
        {
            string o = "";
            foreach (var item in columns)
            {
                o += item + "\n";
            }
            return o;
        }
        public void Exit()
        {
            OnGameExit?.Invoke();
        }
    }
}
