namespace Pasjans
{
    public class Game
    {
        readonly List<CardColumn> columns = new();
        readonly List<SymbolPackage> packs = new();
        readonly CardRestock restock; 
        CommandHistory history = new();
        // Difficulty

        // no acces, only for give cards to columns and give cards to restock
        public Game(CardDeck deck,int columnsAmount =8)
        {
            for (int i = 1; i < columnsAmount; i++)
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

            packs.Add(new SymbolPackage(CardSymbol.Clubs));
            packs.Add(new SymbolPackage(CardSymbol.Diamonds));
            packs.Add(new SymbolPackage(CardSymbol.Hearts));
            packs.Add(new SymbolPackage(CardSymbol.Spades));
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
        public void ExecuteCommand(Command command)
        {
            if (command.Execute())
            {
                history.push(command);
            }
        }
        public Game Clone()
        {
            throw new NotImplementedException();
        }
        public override string ToString()
        {
            string output = "";

         
            foreach (var item in columns)
            {
                output += $"{columns.IndexOf(item)+1}" + item + "\n\n";
            }

            output += "packs \n";
            foreach (var item in packs)
            {
                output += item + "\n";
            }

            output += restock;

            return output;
        }
    }
}
