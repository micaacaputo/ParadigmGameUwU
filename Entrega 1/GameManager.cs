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
                    Program.Update();
                    break;
                case 4:
                    
                    if (Engine.KeyPress(Engine.KEY_R))
                    {
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
                    Program.Render();
                    break;
                case 2:
                    Engine.Draw(victory, 0, 0);
                    break;
                case 3:
                    Engine.Draw(defeat, 0, 0);
                    break;
                case 4:
                    Engine.Draw(menu, 0, 0);
                    break;

            }
            Engine.Show();
        }



    }

}
