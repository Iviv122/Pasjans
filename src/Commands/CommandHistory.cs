namespace Pasjans
{
    class CommandHistory
    {
        List<Command> history = new();

        public CommandHistory()
        {

        }
        public CommandHistory(List<Command> commands)
        {
            history = commands;
        }
        public void push(Command com)
        {
            history.Add(com);
        }
        public Command pop()
        {
            if (history.Count == 0)
                return null; // or throw exception, depending on desired behavior

            Command lastCommand = history.Last();
            history.Remove(lastCommand);
            return lastCommand;
        }
        public CommandHistory Clone()
        {
            List<Command> NStrory = new();
            foreach (Command i in history)
            {
                NStrory.Add(i); 
            }
            return new CommandHistory(NStrory);
        }
    }
}