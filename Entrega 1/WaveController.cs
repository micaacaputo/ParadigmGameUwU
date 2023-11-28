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
        public static float timer { get; set; }
        private static int EnemiesPerWave { get; set; }= 4;
        public static int Wave = 1;
        private static List<Enemy> EnemiesToActivateList { get; set; }= new List<Enemy>();
        private static bool Wave2Passed { get; set; }= false;
        private static Random random { get; }= new Random();
        
        public static void Update()
        {
            timer += Program.DeltaTime;
            if (timer> 10)
            {
                Wave++;
                if (EnemiesPerWave <= 10)
                {
                    EnemiesPerWave++;
                }
                Wave2();
                UpperWaves();
                timer = 0;
            }
            
        }

        private static void UpperWaves()
        {
            if (Wave2Passed)
            {
                foreach (var enemy in LevelController.EnemyPool.allList)
                {
                    if (!enemy.isActive)
                    {
                        EnemiesToActivateList.Add(enemy);
                    }
                }

                EnemiesToActivateList = EnemiesToActivateList.OrderBy(x => random.Next()).ToList();
                var enemyCount = LevelController.EnemyPool.allList.Count(p => p.isActive);
                var enemiesToActivate = EnemiesPerWave - enemyCount;
                if (enemiesToActivate > 0 && enemyCount <= 10)
                {
                    for (int i = 0; i < enemiesToActivate; i++)
                    {
                        EnemiesToActivateList[i].isActive = true;
                    }

                    EnemiesToActivateList.Clear();
                }
            }
        }

        private static void Wave2()
        {
            if (Wave2Passed)
            {
                return;
            }

            Wave2Passed = true;
            for (int i = 4; i < 8; i++)
            {
                LevelController.EnemyPool.allList[i].isActive = true;
            }

            foreach (var enemy in LevelController.EnemyPool.allList)
            {
                if (!enemy.isActive)
                {
                    EnemiesToActivateList.Add(enemy);
                }
            }
        }
    }
}