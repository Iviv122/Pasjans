using IO;
using Menu;

namespace Pasjans
{
    public class Game
    {
        GameTable gameTable;
        ControllMenu menu;

        FinalScreen finalScreen;
        Player player;
        Cursor menuCursour;

        GameState state;

        public Game()
        {
            StartGame();
        }
        public void StartGame()
        {
            menuCursour = new(1, 1);
            menu = new(menuCursour, new Screen());


            Cursor playerCursour = new(1, 1);
            gameTable = new(playerCursour, new CardDeck(), new Screen());
            player = new(gameTable, playerCursour);

            finalScreen = new(new Screen(), 0);

            menu.OnStartGame += (Difficulty diff) =>
            {
                gameTable.SetDifficulty(diff);
                ChangeState(GameState.Game);
            };

            gameTable.OnGameEnd += () =>
            {
                finalScreen.SetTurns(gameTable.TurnsMade);
                ChangeState(GameState.FinalScreen);
            };
            gameTable.OnGameExit += () =>
            {
                Reset();
            };
            
            finalScreen.OnNameEntered += () =>
            {
                Reset();
            };
        }
        void Reset()
        {
            menuCursour = new(1, 1);
            menu = new(menuCursour, new Screen());

            Cursor playerCursour = new(1, 1);
            gameTable = new(playerCursour, new CardDeck(), new Screen());
            player = new(gameTable, playerCursour);

            finalScreen = new(new Screen(),0);


            menu.OnStartGame += (Difficulty diff) =>
            {
                gameTable.SetDifficulty(diff);
                ChangeState(GameState.Game);
            };

            gameTable.OnGameEnd += () =>
            {
                ChangeState(GameState.FinalScreen);
            };
            gameTable.OnGameExit += () =>
            {
                Reset();
            };

            finalScreen.OnNameEntered += () =>
            {
                Reset();
            };

            // Add this line:
            ChangeState(GameState.MainMenu);
        }

        public void Update()
        {
            switch (state)
            {
                case GameState.MainMenu:
                    menu.Update();
                    menuCursour.GetInput();
                    break;
                case GameState.Game:
                    gameTable.GameLoop();
                    player.Input();
                    break;
                case GameState.FinalScreen:
                    finalScreen.Run(); 
                    break;
            }
        }

        void ResetCursorState()
        {
            menuCursour.Y = 0;
            menuCursour.X = 0;
        }
        void ChangeState(GameState NewState)
        {

            //ResetCursorState();
            state = NewState;
        }
    }
}