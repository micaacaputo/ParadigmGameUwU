using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading;
using MyGame.assets;
using Tao.Sdl;
namespace MyGame
{
    public static class WaveController
    {
        // Falta todo el sistema de waves
        public static float timer;
        public static bool Enemies;



        public static void Update()
        {
            timer += Program.DeltaTime;

            Wave2();
            /*Wave3();
            Wave4();
            Wave5();*/
        }

        private static void Wave2()
        {
            if (Enemies && timer > 15)
            {
                Enemies = false;
                for (int i = 4; i < 8; i++)
                {
                    LevelController.EnemyPool.allList[i].isActive = true;
                }
            }
        }
        private static void Wave3()
        {
            if (Enemies && timer > 30)
            {
                Enemies = false;
                for (int i = 8; i < 12; i++)
                {
                    LevelController.EnemyPool.allList[i].isActive = true;
                }
            }
        }
        private static void Wave4()
        {
            if (Enemies && timer > 45)
            {
                Enemies = false;
                for (int i = 12; i < 16; i++)
                {
                    LevelController.EnemyPool.allList[i].isActive = true;
                }
            }
        }
        private static void Wave5()
        {
            if (Enemies && timer > 60)
            {
                Enemies = false;
                for (int i = 16; i < 20; i++)
                {
                    LevelController.EnemyPool.allList[i].isActive = true;
                }
            }
        }

        

    }
}