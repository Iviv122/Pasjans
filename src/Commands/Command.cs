namespace Pasjans
{
    // Command pattern so we can undo and do turns =)
    public abstract class Command
    {

        protected GameTable game;
        // Supressing warning
        protected GameTable backup = null!;
        public Command(GameTable game)
        {
            this.game = game;
            saveBackup();
        }
        public void saveBackup()
        {
            backup = game.Clone();
        }
        public void undo()
        {
            game.Restore(backup);
        }
        virtual public bool Execute(int x, int y)
        {
            return false;
        }
        virtual public bool Execute(int x, int y, ITake source)
        {
            return false;
        }
        virtual public bool Execute(int x, int y,IPut destination) {
            return false;
        }
    }   
}