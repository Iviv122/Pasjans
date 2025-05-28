using IO;
using Menu.ButtonDrawer;
using Pasjans;

namespace Menu
{
    public class StartGame : Menu
    {
        Screen Screen;
        public event Action EnterStartGame;
        public event Action EnterExitGame;
        // dla wyswietlenia pod przeciskami
        private int buttonOffset = 2;
        private int buttonHeight = 3;
        ButtonDraw buttonDrawer;

        public event Action OnExit;
        public event Action<Difficulty> OnDifficultyChoose;

        public StartGame(Screen screen) : base()
        {
            buttonDrawer = new(screen);
            this.Screen = screen;
            CreateButtons();
        }
        public override void CreateButtons()
        {
            Button EasyMode = new("EasyMode");
            EasyMode.OnUse +=  () => OnDifficultyChoose?.Invoke(Difficulty.Easy);
            buttons.Add(EasyMode);

            Button HardMode = new("HardMode");
            HardMode.OnUse +=  () => OnDifficultyChoose?.Invoke(Difficulty.Hard);
            buttons.Add(HardMode);

            //Button Custom = new("Custom");
            //HardMode.OnUse += StartGame;
            //buttons.Add(Custom);

            Button ExitButton = new("Exit");
            ExitButton.OnUse += Exit;
            buttons.Add(ExitButton);
        }
        override public void Draw()
        {
            int yPos = buttonOffset;
            buttonDrawer.DrawButton(new Vector2(0, 0), new Vector2(Screen.Width, Screen.Height));
            for (int i = 0; i < buttons.Count; i++)
            {
                buttonDrawer.DrawButton(new Vector2(MathF.Floor(Screen.Width / 3), yPos), new Vector2(40, buttonHeight), buttons[i].Label);
                yPos += buttonHeight + buttonOffset;
            }

        }
        public override void DrawCursor(Cursor cursor)
        {
            buttonDrawer.DrawButton(new Vector2(MathF.Floor(Screen.Width / 3), 0 + buttonOffset + buttonHeight * cursor.Y + buttonOffset * cursor.Y), new Vector2(40, buttonHeight), buttons[cursor.Y].Label, ConsoleColor.Blue);
        }
        public override void Exit()
        {
            OnExit?.Invoke();
        }
    }
}