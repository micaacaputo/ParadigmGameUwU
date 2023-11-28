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
        }

        private static void Wave2()
        {
            if (Enemies && timer > 10)
            {
                Enemies = false;
                for (int i = 4; i < 8; i++)
                {
                    LevelController.EnemyPool.allList[i].isActive = true;
                }
            }
        }

        

    }
}