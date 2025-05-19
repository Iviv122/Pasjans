using Pasjans;

namespace IO
{
    class CardDrawer
    {
        readonly Screen screen;
        public readonly int cardWidth = 5;
        public readonly int cardHeight = 4;
        public readonly int cardOffset = 2;

        public Screen Screen
        {
            get
            {
                return screen;
            }
        }

        public CardDrawer(Screen screen)
        {
            this.screen = screen;
        }
        public CardDrawer(Screen screen, int cardWidth, int cardHeight, int cardOffset)
        {
            this.screen = screen;
            if (cardWidth < 5)
            {
                throw new ArgumentException("to thin card size");
            }
            if (cardHeight < 4)
            {
                throw new ArgumentException("to short card size");
            }
            if (cardOffset < 2)
            {
                throw new ArgumentException("to short offset");
            }
        }

        public void DrawCard(Vector2 pos, Card card)
        {
            ConsoleColor color = (card.Color == CardColor.Red) ? ConsoleColor.Red : ConsoleColor.White;

            Point[,] content = new Point[cardHeight, cardWidth];

            string cardString = card.ToString();
            cardString = cardString.Length > 3 ? cardString.Substring(0, 3) : cardString.PadRight(3);

            for (int y = 0; y < cardHeight; y++)
            {
                for (int x = 0; x < cardWidth; x++)
                {
                    // Corners
                    if ((x == 0 || x == cardWidth - 1) && (y == 0 || y == cardHeight - 1))
                    {
                        content[y, x] = new Point('+', color);
                    }
                    // Vertical borders
                    else if (x == 0 || x == cardWidth - 1)
                    {
                        content[y, x] = new Point('|', color);
                    }
                    // Horizontal borders
                    else if (y == 0 || y == cardHeight - 1)
                    {
                        content[y, x] = new Point('-', color);
                    }
                    // Card label centered in second row (y == 1)
                    else if (y == 1 && x >= 1 && x <= 3)
                    {
                        int labelIndex = x - 1;
                        content[y, x] = new Point(cardString[labelIndex], color);
                    }
                    else
                    {
                        content[y, x] = new Point(' ', color);
                    }
                }
            }
            screen.Place(pos, content);
        }

        public void DrawCard(Vector2 pos, Card card, ConsoleColor borderColor)
        {
            ConsoleColor color = (card.Color == CardColor.Red) ? ConsoleColor.Red : ConsoleColor.White;

            Point[,] content = new Point[cardHeight, cardWidth];

            string cardString = card.ToString();
            cardString = cardString.Length > 3 ? cardString.Substring(0, 3) : cardString.PadRight(3);

            for (int y = 0; y < cardHeight; y++)
            {
                for (int x = 0; x < cardWidth; x++)
                {
                    // Corners
                    if ((x == 0 || x == cardWidth - 1) && (y == 0 || y == cardHeight - 1))
                    {
                        content[y, x] = new Point('+', borderColor);
                    }
                    // Vertical borders
                    else if (x == 0 || x == cardWidth - 1)
                    {
                        content[y, x] = new Point('|', borderColor);
                    }
                    // Horizontal borders
                    else if (y == 0 || y == cardHeight - 1)
                    {
                        content[y, x] = new Point('-', borderColor);
                    }
                    // Card label centered in second row (y == 1)
                    else if (y == 1 && x >= 1 && x <= 3)
                    {
                        int labelIndex = x - 1;
                        content[y, x] = new Point(cardString[labelIndex], color);
                    }
                    else
                    {
                        content[y, x] = new Point(' ', color);
                    }
                }
            }
            screen.Place(pos, content);
        }
        public void DrawCardWithSymbol(Vector2 pos, CardSymbol symbol)
        {

            Point[,] content = new Point[cardHeight, cardWidth];
            Card card = new Card(Card.MinValue, symbol);
            string cardString = card.ToString();

            ConsoleColor color = (card.Color == CardColor.Red) ? ConsoleColor.Red : ConsoleColor.White;


            for (int y = 0; y < cardHeight; y++)
            {
                for (int x = 0; x < cardWidth; x++)
                {
                    // Corners
                    if ((x == 0 || x == cardWidth - 1) && (y == 0 || y == cardHeight - 1))
                    {
                        content[y, x] = new Point('+', color);
                    }
                    // Vertical borders
                    else if (x == 0 || x == cardWidth - 1)
                    {
                        content[y, x] = new Point('|', color);
                    }
                    // Horizontal borders
                    else if (y == 0 || y == cardHeight - 1)
                    {
                        content[y, x] = new Point('-', color);
                    }
                    else
                    {
                        content[y, x] = new Point(cardString[1], color);
                    }
                }
            }
            screen.Place(pos, content);
        }
        public void DrawEmptyCard(Vector2 pos, ConsoleColor color)
        {

            Point[,] content = new Point[cardHeight, cardWidth];


            for (int y = 0; y < cardHeight; y++)
            {
                for (int x = 0; x < cardWidth; x++)
                {
                    // Corners
                    if ((x == 0 || x == cardWidth - 1) && (y == 0 || y == cardHeight - 1))
                    {
                        content[y, x] = new Point('+', color);
                    }
                    // Vertical borders
                    else if (x == 0 || x == cardWidth - 1)
                    {
                        content[y, x] = new Point('|', color);
                    }
                    // Horizontal borders
                    else if (y == 0 || y == cardHeight - 1)
                    {
                        content[y, x] = new Point('-', color);
                    }
                }
            }
            screen.Place(pos, content);
        }
        public void DrawCardCoursour(Vector2 pos, ConsoleColor color)
        {
            Point[,] content = new Point[cardHeight, cardWidth];


            for (int y = 0; y < cardHeight; y++)
            {
                for (int x = 0; x < cardWidth; x++)
                {
                    // Corners
                    if ((x == 0 || x == cardWidth - 1) && (y == 0 || y == cardHeight - 1))
                    {
                        content[y, x] = new Point('+', color);
                    }
                    // Vertical borders
                    else if (x == 0 || x == cardWidth - 1)
                    {
                        content[y, x] = new Point('|', color);
                    }
                    // Horizontal borders
                    else if (y == 0 || y == cardHeight - 1)
                    {
                        if (screen.Get(new Vector2(x, y)).Value == ' ')
                        {
                            content[y, x] = new Point('-', color);
                        }
                    }
                }
            }
            screen.Place(pos, content);
        }
        public void DrawUnknownCard(Vector2 pos,ConsoleColor color = ConsoleColor.White)
        {

            Point[,] content = new Point[cardHeight, cardWidth];


            for (int y = 0; y < cardHeight; y++)
            {
                for (int x = 0; x < cardWidth; x++)
                {
                    // Corners
                    if ((x == 0 || x == cardWidth - 1) && (y == 0 || y == cardHeight - 1))
                    {
                        content[y, x] = new Point('+', color);
                    }
                    // Vertical borders
                    else if (x == 0 || x == cardWidth - 1)
                    {
                        content[y, x] = new Point('|', color);
                    }
                    // Horizontal borders
                    else if (y == 0 || y == cardHeight - 1)
                    {
                        content[y, x] = new Point('-', color);
                    }
                    else
                    {
                        content[y, x] = new Point('#', color);
                    }
                }
            }
            screen.Place(pos, content);
        }
        public void DrawColumn(Vector2 pos, Tuple<LinkedList<Card>, int> column)
        {
            for (int i = 0; i < column.Item1.Count; i++)
            {
                Vector2 cardPos = new Vector2(pos.Y, pos.X + i * cardHeight);

                if (i < column.Item2)
                {
                    DrawUnknownCard(cardPos);
                }
                else
                {
                    DrawCard(cardPos, column.Item1.ElementAt(i));
                }
            }
        }
        public void DrawColumn(Vector2 pos, Tuple<LinkedList<Card>, int> column, ConsoleColor borderColor)
        {
            for (int i = 0; i < column.Item1.Count; i++)
            {
                Vector2 cardPos = new Vector2(pos.Y, pos.X + i * cardHeight);

                if (i < column.Item2)
                {
                    DrawUnknownCard(cardPos,borderColor);
                }
                else
                {
                    DrawCard(cardPos, column.Item1.ElementAt(i),borderColor);
                }
            }
        }
        public void DrawPackage(Vector2 pos, SymbolPackage package)
        {

            if (package.NextCardValue() == Card.MinValue)
            {
                DrawCardWithSymbol(new Vector2(), package.CardSymbol);
            }
            Card tmpCard = new Card(package.NextCardValue() - 1, package.CardSymbol);

            DrawCard(new Vector2(), tmpCard);
        }


    }
}
