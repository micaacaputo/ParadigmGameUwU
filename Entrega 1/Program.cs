

using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading;
using Tao.Sdl;

namespace MyGame
{

    class Program
    {
                    
        static IntPtr image = Engine.LoadImage("assets/fondoPoo.png");
        static public List<Character> CharacterList = new List<Character>();
        static public List<Enemy> EnemyList = new List<Enemy>();
        static public List<Bullet> BulletList = new List<Bullet>();
        private static DateTime _startTime;
        private static float _lastTimeFrame;
        public static float DeltaTime;


        static void Main(string[] args)
        {
            Initialize();

            while (true)
            {
                Update();

                Render();

                Sdl.SDL_Delay(5);
            }
        }

        private static void Initialize()
        {
            Engine.Initialize();
            CharacterList.Add(new Character(600, 334, (float)37.5, 0,0,0,1, "assets/Character/player.png"));
            EnemyList.Add(new Enemy(0,0, (float)37.5, "assets/Enemy/enemy.png"));
            EnemyList.Add(new Enemy(0, 700, (float)37.5, "assets/Enemy/enemy.png"));
            EnemyList.Add(new Enemy(1200, 0, (float)37.5, "assets/Enemy/enemy.png"));
            EnemyList.Add(new Enemy(1200, 700, (float)37.5, "assets/Enemy/enemy.png"));

            _startTime = DateTime.Now;
        }

        private static void Update()
        {

            foreach (Character character in CharacterList)
            {
                character.Update();
                Colision.WallsCollision(character);
                Physics.PhysicsCalculate(character);
                Physics.Friction(character);
            }
            foreach (Enemy enemy in EnemyList)
            {
                enemy.Update();
                Colision.WallsCollisionEnemy(enemy);
                Colision.CollisionPlayerEnemy(CharacterList[0], enemy);
                Comportamiento.Follow(CharacterList[0], enemy, 100);
                Physics.PhysicsCalculate(enemy);
            }
            foreach(Bullet bullet in BulletList) 
            {  
                bullet.Update();
                Colision.WallsCollisionBullet(bullet);
                Colision.CollisionBulletEnemy(bullet);
                Physics.PhysicsCalculate(bullet);
            }

        }

        private static void Render()

        {
            float currentTime = (float)(DateTime.Now - _startTime).TotalSeconds;
            DeltaTime = currentTime - _lastTimeFrame;
            _lastTimeFrame = currentTime;

            Engine.Clear();
            Engine.Draw(image, 0, 0);

            foreach (Character character in CharacterList)
            {
                character.Render();
            }
            foreach (Enemy enemy in EnemyList)
            {
                enemy.Render();
            }
            foreach (Bullet bullet in BulletList)
            {
                bullet.Render();
            }
            Engine.Show();
        }

    }

}
