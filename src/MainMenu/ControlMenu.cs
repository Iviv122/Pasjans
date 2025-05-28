using IO;
using Menu.ButtonDrawer;
using Pasjans;

namespace Menu
{
    public class ControllMenu
    {
        Cursor cursor;
        Screen Screen;
        MenuState state;
        Menu currentMenu;
        MainMenu mainMenu;
        LeaderBoard liderBoard;
        StartGame StartGame;

        public event Action<Difficulty> OnStartGame;
        public ControllMenu(Cursor cursor, Screen screen)
        {
            this.cursor = cursor;
            this.Screen = screen;

            cursor.OnUse += Use;


            // stan poczatkowy
            mainMenu = new(screen);
            mainMenu.EnterLiderBoard += () => ChangeState(MenuState.LiderBoard);
            mainMenu.EnterStartGame += () => ChangeState(MenuState.StartGame);
            currentMenu = mainMenu;

            liderBoard = new(screen, new ButtonDraw(screen));
            liderBoard.OnExit += () => ChangeState(MenuState.Menu);

            StartGame = new(screen);
            StartGame.OnExit += () => ChangeState(MenuState.Menu);
            StartGame.OnDifficultyChoose += (Difficulty diff) =>
            {
                OnStartGame?.Invoke(diff);
            };


            state = MenuState.Menu;
        }

        public void Update()
        {
            InputLogic();
            Draw();
        }
        void InputLogic()
        {

            if (currentMenu.Buttons.Count == 0)
            {
                cursor.Y = 0;
                return;
            }
            if (cursor.Y < 0)
            {
                cursor.Y = 0;
            }
            if (cursor.Y >= currentMenu.Buttons.Count - 1)
            {
                cursor.Y = currentMenu.Buttons.Count - 1;
            }
        }
        void ChangeState(MenuState NewState)
        {
            state = NewState;
            cursor.Y = 0;
        }
        void Draw()
        {
            Screen.ClearScreen();
            Screen.ClearConsole();

            switch (state)
            {
                case MenuState.Menu:
                    currentMenu = mainMenu;
                    mainMenu.Draw();
                    mainMenu.DrawCursor(cursor);
                    break;
                case MenuState.LiderBoard:
                    currentMenu = liderBoard;

                    liderBoard.Draw();
                    liderBoard.DrawCursor(cursor);
                    break;
                case MenuState.StartGame:
                    currentMenu = StartGame;

                    StartGame.Draw();
                    StartGame.DrawCursor(cursor);
                    break;
            }


            Screen.Display();
        }
        void Use()
        {
            currentMenu.Buttons[cursor.Y].Use();
        }
        void Start()
        {
            cursor.X = 0;
            cursor.Y = 0;
        }

    }
}