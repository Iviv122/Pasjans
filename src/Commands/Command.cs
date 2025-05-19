namespace Pasjans
{
    // Command pattern so we can undo and do turns =)
    public abstract class Command{

        protected Game game;
        // Supressing warning
        protected Game backup = null!;
        public Command(Game game)
        {
            this.game = game;
            saveBackup();
        }
        public void saveBackup(){
            backup = game.Clone(); 
        }
        public void undo(){
            game = backup;
        }
        abstract public bool Execute(int x, int y);
    }   
}