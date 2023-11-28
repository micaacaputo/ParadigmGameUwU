using MyGame.assets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGame
{
    public class GameManager
    {
        private static GameManager instance;
        private IntPtr menu = Engine.LoadImage("assets/Screen/menu.png");
        private IntPtr victory = Engine.LoadImage("assets/Screen/victory.png");
        private IntPtr defeat = Engine.LoadImage("assets/Screen/defeat.png");
        private int gameCondition = 0;
        public int score;
        public int MaxScore = 50;
        public static IntPtr gameFont;
        
        public Action OnRestart;
        public static GameManager Instance
        {
            get
            {
                if(instance == null)
                {
                    instance = new GameManager();
                }
                return instance;
            }
        }

        public void ChangeCondition(int cc)
        {
            gameCondition = cc;
        }

        public void Initialize()
        {
            LevelController.Initialize();
            Collision.OnEnemyDesable += ScoreUp;
            gameFont = Engine.LoadFont("Fonts/digital-7.ttf", 50);
        }
        public void Update()
       {

            switch(gameCondition)
            {
                case 0:
                    if (Engine.KeyPress(Engine.KEY_S))
                    {
                        ChangeCondition(1);
                    }
                    break;
                case 1:
                    LevelController.Update();
                    break;
                case 2:
                    if (Engine.KeyPress(Engine.KEY_R))
                    {
                        OnRestart?.Invoke();
                        score = 0;
                        ChangeCondition(0);

                    }
                    break;
                case 3:
                    if (Engine.KeyPress(Engine.KEY_R))
                    {
                        OnRestart?.Invoke();
                        score = 0;
                        ChangeCondition(0);

                    }
                    break;
            }


        }

       public void Render()
       {
            Engine.Clear();

            switch (gameCondition)
            {
                case 0:
                    Engine.Draw(menu, 0, 0);
                    break;
                case 1:
                    LevelController.Render();
                    break;
                case 2:
                    Engine.Draw(victory, 0, 0);
                    break;
                case 3:
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
               ChangeCondition(2);
           }
       }

    }

}
