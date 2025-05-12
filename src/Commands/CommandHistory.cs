namespace Pasjans
{
    class CommandHistory
    {
        List<Command> history = new();

        public void push(Command com){
            history.Add(com);
        }
        public Command pop(){
            if (history.Count == 0)
                return null; // or throw exception, depending on desired behavior

            Command lastCommand = history[history.Count - 1];
            history.RemoveAt(history.Count - 1);
            return lastCommand;
        }
    }
}