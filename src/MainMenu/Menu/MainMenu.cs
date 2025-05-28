using IO;
using Menu.ButtonDrawer;
using Pasjans;

namespace Menu
{
    public class MainMenu : Menu
    {
        Screen Screen;
        public event Action EnterStartGame;
        public event Action EnterLiderBoard;
        public event Action EnterExitGame;
        // dla wyswietlenia pod przeciskami
        private CardDrawer cardDrawer;
        private int buttonOffset = 2;
        private int buttonHeight = 3;
        ButtonDraw buttonDrawer;


        public MainMenu(Screen screen) : base()
        {
            cardDrawer = new(screen);
            buttonDrawer = new(screen);
            this.Screen = screen;
            CreateButtons();
        }
        public override void CreateButtons()
        {
            Button StartGameButton = new("Start Game");
            StartGameButton.OnUse += StartGame;
            buttons.Add(StartGameButton);

            Button LiderBoardButton = new("Lider Board");
            LiderBoardButton.OnUse += StartLiderBoard;
            buttons.Add(LiderBoardButton);

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

            // decorative cards
            CardSymbol[] symbols = (CardSymbol[])Enum.GetValues(typeof(CardSymbol));
            Vector2 pos = new Vector2(buttonOffset * 3, Screen.Height - 1 - buttonOffset - cardDrawer.cardHeight);
            foreach (var item in symbols)
            {
                for (int i = 1; i <= Card.MaxValue; i++)
                {
                    cardDrawer.DrawCard(pos, new Card(i, item));
                    pos.X += cardDrawer.cardOffset;
                }

            }
        }
        public override void DrawCursor(Cursor cursor)
        {
            buttonDrawer.DrawButton(new Vector2(MathF.Floor(Screen.Width / 3), 0 + buttonOffset + buttonHeight * cursor.Y + buttonOffset * cursor.Y), new Vector2(40, buttonHeight), buttons[cursor.Y].Label, ConsoleColor.Blue);
        }
        void StartLiderBoard()
        {
            EnterLiderBoard?.Invoke();
        }
        void StartGame()
        {
            EnterStartGame?.Invoke();
        }
        public override void Exit()
        {
            EnterExitGame?.Invoke();
            Screen.ClearConsole();
            Environment.Exit(0);

        }
    }
}