namespace Pasjans
{
    public class TakeCommand : Command
    {
        public TakeCommand(Game game) : base(game)
        {

        }

        public override bool Execute(int x, int y)
        {
            throw new NotImplementedException();
        }
    }

    public class PutCommand : Command
    {
        public PutCommand(Game game) : base(game)
        {

        }

        public override bool Execute(int x, int y)
        {
            throw new NotImplementedException();
        }
    }
}