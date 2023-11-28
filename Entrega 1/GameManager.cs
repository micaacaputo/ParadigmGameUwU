using MyGame.assets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGame
{
    public enum GameCondition
    {
        MainMenu = 0,
        InGame = 1,
        Victory = 2,
        Defeat = 3
    }

    public class GameManager
    {
        private static GameManager instance{ get; set; }
        private IntPtr menu = Engine.LoadImage("assets/Screen/menu.png");
        private IntPtr victory = Engine.LoadImage("assets/Screen/victory.png");
        private IntPtr defeat = Engine.LoadImage("assets/Screen/defeat.png");
        private GameCondition gameCondition = GameCondition.MainMenu;
        public int score{ get; private set; }
        private int MaxScore = 50;
        public static IntPtr gameFont{ get; private set; }

        public Action OnRestart;

        public static GameManager Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new GameManager();
                }
                return instance;
            }
        }

        public void ChangeCondition(GameCondition newCondition)
        {
            gameCondition = newCondition;
        }

        public void Initialize()
        {
            LevelController.Initialize();
            Collision.OnEnemyDesable += ScoreUp;
            gameFont = Engine.LoadFont("Fonts/digital-7.ttf", 50);
        }

        public void Update()
        {
            switch (gameCondition)
            {
                case GameCondition.MainMenu:
                    if (Engine.KeyPress(Engine.KEY_S))
                    {
                        ChangeCondition(GameCondition.InGame);
                    }
                    break;
                case GameCondition.InGame:
                    LevelController.Update();
                    break;
                case GameCondition.Victory:
                case GameCondition.Defeat:
                    if (Engine.KeyPress(Engine.KEY_R))
                    {
                        OnRestart?.Invoke();
                        score = 0;
                        ChangeCondition(GameCondition.MainMenu);
                    }
                    break;
            }
        }

        public void Render()
        {
            Engine.Clear();

            switch (gameCondition)
            {
                case GameCondition.MainMenu:
                    Engine.Draw(menu, 0, 0);
                    break;
                case GameCondition.InGame:
                    LevelController.Render();
                    break;
                case GameCondition.Victory:
                    Engine.Draw(victory, 0, 0);
                    break;
                case GameCondition.Defeat:
                    Engine.Draw(defeat, 0, 0);
                    break;
            }

            Engine.Show();
        }

        private void ScoreUp()
        {
            score++;
            if (score == MaxScore)
            {
                ChangeCondition(GameCondition.Victory);
            }
        }
    }
}

