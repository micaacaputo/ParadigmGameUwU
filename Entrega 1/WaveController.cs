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
        


        public static void Update()
        {
            timer += Program.DeltaTime;
            foreach (var enemy in LevelController.EnemyPool.allList)
            {
                if (!enemy.isActive)
                {
                    ListaEnemigosAInstanciar.Add(enemy);
                }
                else
                {
                    EnemyCounter++;
                }
            }

            if (EnemyCounter < CantidaPorOleada * Wave)
            {
                ListaEnemigosAInstanciar[0].isActive = true;
                LevelController.EnemyPool.allList[0].Position = new Vector2(2720, 769);
                LevelController.EnemyPool.allList[0].Velocity = new Vector2(0, 0);
                ListaEnemigosAInstanciar.RemoveAt(0);
            }
            if (GameManager.Instance.score > CantidaPorOleada * Wave)
            {
                Wave++;
            }
        }
    }
}