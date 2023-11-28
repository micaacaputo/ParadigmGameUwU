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
        public static int EnemyCounter = 0;
        public static int CantidaPorOleada = 4;
        public static int Wave = 1;
        public static List<Enemy> ListaEnemigosAInstanciar = new List<Enemy>();
        private static bool a = false;
        private static Random random = new Random();
        


        public static void Update()
        {
            timer += Program.DeltaTime;
            if (timer> 10)
            {
                Wave++;
                if (CantidaPorOleada <= 10)
                {
                    CantidaPorOleada++;
                }
                Wave2();
                if (a)
                {
                    foreach (var enemy in LevelController.EnemyPool.allList)
                    {
                        if (!enemy.isActive)
                        {
                            ListaEnemigosAInstanciar.Add(enemy);
                        }
                    }
                    ListaEnemigosAInstanciar = ListaEnemigosAInstanciar.OrderBy(x => random.Next()).ToList();
                    var enemyCount = LevelController.EnemyPool.allList.Count(p => p.isActive);
                    var enemiesToActivate = CantidaPorOleada - enemyCount;
                    if (enemiesToActivate > 0 && enemyCount <= 10)
                    {
                        for (int i = 0; i < enemiesToActivate; i++)
                        {
                            ListaEnemigosAInstanciar[i].isActive = true;
                        }
                        ListaEnemigosAInstanciar.Clear();
                    }
                }
                timer = 0;
            }
            
        }

        private static void Wave2()
        {
            if (a)
            {
                return;
            }

            a = true;
            for (int i = 4; i < 8; i++)
            {
                LevelController.EnemyPool.allList[i].isActive = true;
            }

            foreach (var enemy in LevelController.EnemyPool.allList)
            {
                if (!enemy.isActive)
                {
                    ListaEnemigosAInstanciar.Add(enemy);
                }
            }
        }
    }
}