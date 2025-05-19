namespace Pasjans
{
    public class TakeCommand : Command
    {
        public TakeCommand(GameTable game) : base(game)
        {

        }
        public bool Take(ITake source, int indexY)
        {
            LinkedList<Card> cards = source.Take(indexY);
            if (cards == null || cards.Count == 0)
            {
                return false;
            }
            game.CardTemp.Add(cards);
            return true;
        }
        public override bool Execute(int x, int y, ITake source)
        {
            return Take(source, y);

        }
    }

    public class PutCommand : Command
    {
        public PutCommand(GameTable game) : base(game)
        {

        }
        // zrodlo to cardTemp
        public bool Put(IPut dest, int indexY)
        {
            if (game.CardTemp.isEmpty())
            {
                return false;
            }
            dest.Put(game.CardTemp.Take());
            return true;
        }
        public override bool Execute(int x, int y, IPut source)
        {
            return Put(source, y);
        }
    }
    public class UndoCommand : Command
    {
        public UndoCommand(GameTable game) : base(game)
        {

        }
        public override bool Execute(int x, int y, IPut source)
        {
            game.Undo();
            return false;
        }
    }
}