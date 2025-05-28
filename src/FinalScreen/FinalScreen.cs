using LiderBoard;
using Menu.ButtonDrawer;

namespace IO
{
    public class FinalScreen
    {
        Screen screen;
        LiderBoardManager liderBoardManager;
        ButtonDraw buttonDrawer;
        int turns;
        public event Action OnNameEntered;
        public FinalScreen(Screen screen, int turns)
        {
            this.screen = screen;
            this.liderBoardManager = new();
            this.buttonDrawer = new(screen);

            this.turns = turns;
        }
        public void SetTurns(int turns)
        {
            this.turns = turns;
        }
        public void Run()
        {
            screen.ClearConsole();

            buttonDrawer.DrawButton(new Vector2(0, 0), new Vector2(screen.Width, screen.Height));

            // Calculate center of the screen
            int centerX = screen.Width / 3;

            int centerY1 = screen.Height / 2 - screen.Height / 4;
            int centerY = screen.Height / 2;

            // Message to display
            string prompt = "Enter your name: ";

            // Adjust X so the prompt is centered
            int promptX = centerX - prompt.Length / 2;

            buttonDrawer.DrawButton(new Vector2(centerX, centerY1), new Vector2(50, 3), "Enter Your Name and press enter to confirm");
            screen.Display();


            // Set cursor and write prompt


            Console.SetCursorPosition(promptX, centerY);
            Console.SetCursorPosition(promptX + prompt.Length, centerY);
            string playerName = Console.ReadLine();
            liderBoardManager.AddResult(new Result(playerName, turns));

            OnNameEntered?.Invoke();

        }
    }
}