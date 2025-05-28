using IO;
using LiderBoard;
using Menu.ButtonDrawer;

namespace Menu
{
    public class LeaderBoard : Menu
    {
        LiderBoardManager liderBoardManager;
        Screen Screen;
        ButtonDraw buttonDrawer;
        int buttonOffset = 2;
        int buttonHeight = 3;
        int firstResults = 5;
        public event Action OnExit;
        public LeaderBoard(Screen screen, ButtonDraw buttonDraw,int firstResults = 5) : base()
        {
            liderBoardManager = new();
            this.Screen = screen;
            buttonDrawer = buttonDraw;

            this.firstResults = firstResults;

            CreateButtons();
        }

        public override void CreateButtons()
        {
            Button ExitButton = new("Exit");
            ExitButton.OnUse += Exit;
            buttons.Add(ExitButton);
        }
        override public void Draw()
        {
            int yPos = buttonOffset;
            buttonDrawer.DrawButton(new Vector2(0, 0), new Vector2(Screen.Width, Screen.Height));
            if (firstResults > liderBoardManager.results.Count)
            {
                firstResults = liderBoardManager.results.Count;
            }
            liderBoardManager.results.Sort(); 
            for (int i = 0; i < firstResults; i++)
            {
                string User = liderBoardManager.results[i].ToString();
                buttonDrawer.DrawButton(new Vector2(MathF.Floor((Screen.Width - User.Length + 2) / 2), yPos), new Vector2(User.Length + 2, buttonHeight), User);
                yPos += buttonHeight + buttonOffset;
            }

        }

        public override void DrawCursor(Cursor cursor)
        {
            buttonDrawer.DrawButton(new Vector2(MathF.Floor(Screen.Width / 2), Screen.Height-5),new Vector2(buttons[0].Label.Length+2,buttonHeight), buttons[0].Label,ConsoleColor.Blue);
        }

        public override void Exit()
        {
            OnExit?.Invoke();
        }
    }
}