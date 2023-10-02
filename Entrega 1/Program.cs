﻿

using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading;
using MyGame.assets;
using Tao.Sdl;

namespace MyGame
{

    class Program
    {
                    
        static IntPtr image = Engine.LoadImage("assets/fondoPoo.png");
        static public List<Character> CharacterList = new List<Character>();
        static public List<Enemy> EnemyList = new List<Enemy>();
        static public List<Bullet> BulletListActive = new List<Bullet>();
        static public List<Bullet> BulletListNotActive = new List<Bullet>();
        static public List<Bullet> Bullets = new List<Bullet>();
        static public Camera camara = new Camera();
        private static DateTime _startTime;
        private static float _lastTimeFrame;
        public static float DeltaTime;


        static void Main(string[] args)
        {
            Initialize();

            while (true)
            {
                GameManager.Instance.Update();

                GameManager.Instance.Render();

                Sdl.SDL_Delay(5);
            }
        }

        private static void Initialize()
        {
            Engine.Initialize();
            CharacterList.Add(new Character(600, 334, (float)37.5, 202, 76));
            EnemyList.Add(new Enemy(0,0, (float)37.5, "assets/Enemy/enemy1.png", 75, 75));
            EnemyList.Add(new Enemy(0, 700, (float)37.5, "assets/Enemy/enemy1.png", 75, 75));
            EnemyList.Add(new Enemy(1200, 0, (float)37.5, "assets/Enemy/enemy1.png", 75, 75));
            EnemyList.Add(new Enemy(1200, 700, (float)37.5, "assets/Enemy/enemy1.png", 75, 75));
            BulletListNotActive.Add(new Bullet(new Vector2(0,0), new Vector2(0,0)));
            BulletListNotActive.Add(new Bullet(new Vector2(0,0), new Vector2(0,0)));
            BulletListNotActive.Add(new Bullet(new Vector2(0,0), new Vector2(0,0)));
            BulletListNotActive.Add(new Bullet(new Vector2(0,0), new Vector2(0,0)));

            _startTime = DateTime.Now;
        }

        public static void Update()
        {
            camara.Update();
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
            
            foreach(Bullet bullet in BulletListActive) 
            {  
                bullet.Update();
                Colision.WallsCollisionBullet(bullet);
                Colision.CollisionBulletEnemy(bullet);
                Colision.CollisionBulletCharacter(bullet,CharacterList[0]);
                Physics.PhysicsCalculate(bullet);
                if (!bullet.isActive)
                {
                    Bullets.Add(bullet);
                }
            }
            foreach (var bullet in Bullets)
            {
                BulletListActive.Remove(bullet);
                BulletListNotActive.Add(bullet);
            }
            Bullets.Clear();


        }

        public static void Render()

        {
            float currentTime = (float)(DateTime.Now - _startTime).TotalSeconds;
            DeltaTime = currentTime - _lastTimeFrame;
            _lastTimeFrame = currentTime;

            
            Engine.Draw(image, 0- camara.Position.x, 0- camara.Position.y);

            foreach (Character character in CharacterList)
            {
                character.Render();
            }
            foreach (Enemy enemy in EnemyList)
            {
                enemy.Render();
            }
            foreach (Bullet bullet in BulletListActive)
            {
                bullet.Render();
            }
            
        }

    }

}
