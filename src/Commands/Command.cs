namespace Pasjans
{
    // Command pattern so we can undo turns =)
    public abstract class Command{

        Game game;
        // Supressing warning
        Game backup = null!;
        public Command(Game game){
            this.game = game;
        }
        public void saveBackup(){
            //TODO
        }
        public void undo(){
            game = backup;
        }
        abstract public bool Execute();
    }   
}