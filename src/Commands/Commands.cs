namespace Pasjans
{
    public class TakeCommand : Command
    {
        public TakeCommand(GameTable game) : base(game)
        {

        }
        public bool Take(ITake source, int indexY)
        {
            // nie dobieramy do bufera jezeli juz mamy karty
            if (!game.CardTemp.isEmpty())
            {
                return false;
            }
            // nie dobieramy z nic
            if (source == null)
            {
                return false;
            }
            // dobieramy
            LinkedList<Card> cards = source.Take(indexY);
            // nic nie dobieralismy
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
            if (dest == null)
            {
                return false;
            }

            LinkedList<Card> cards = game.CardTemp.Take();
            dest.Put(cards);

            if (cards.Count > 0)
            {
                game.CardTemp.Add(cards);
                return false;
            }

            return true;
        }
        public override bool Execute(int x, int y, IPut source)
        {
            return Put(source, y);
        }
    }
    public class NextCommand : Command
    {
        public NextCommand(GameTable game) : base(game)
        {

        }
        // zrodlo to cardTemp
        public bool Next()
        {
            game.Restock.Next();
            return true;
        }
        public override bool Execute(int x, int y)
        {
            return Next();
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