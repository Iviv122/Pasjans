// Punkt wejsczowy do programu 

using IO;
using Pasjans;

class Program
{
    static void Main(string[] args)
    {
        CardDrawer render = new CardDrawer(new IO.IO.Screen());
        render.DrawCard(new Vector2(1,0),new Card(1,CardSymbol.Hearts));
    }
}
