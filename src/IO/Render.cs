using System.Numerics;
using IO.IO;
using Pasjans;

namespace IO
{
    class CardDrawer
    {
        Screen screen;
        int cardWidth = 6;
        int cardHeight = 6;

        public CardDrawer(Screen screen)
        {
            this.screen = screen;
        }
        public void DrawCard(Vector2 pos, Card card)
        {
            

            ConsoleColor color; 
            if (card.Color == CardColor.Red)
                color = ConsoleColor.Red;
            else
                color = ConsoleColor.White;


            Point[,] content = new Point[cardWidth,cardHeight];   
        }

    }
}