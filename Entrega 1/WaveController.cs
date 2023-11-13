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
        static IntPtr image = Engine.LoadImage("assets/fondoPoo.png");
        public static List<Character> CharacterList = new List<Character>();
        public static List<Enemy> EnemyList = new List<Enemy>();
        public static List<Bullet> BulletListActive = new List<Bullet>();
        public static List<Bullet> BulletListNotActive = new List<Bullet>();
        private static List<Bullet> Bullets = new List<Bullet>();
        public static Camera camera = new Camera();
        private static float timer;
        private static bool Enemies;
        

        public static void Initialize()
        {
            GameManager.Instance.OnRestart += Restart;
            camera.Position = new Vector2(1360, 769);
            Enemies = true;
            Engine.Initialize();
            CharacterList.Add(new Character(1360, 769, 37, 74, 74));
            EnemyList.Add(new Enemy(0,513, 43, "assets/Enemy/enemy1.png", 86, 86));
            EnemyList.Add(new Enemy(0, 1026, 43, "assets/Enemy/enemy1.png", 86, 86));
            EnemyList.Add(new Enemy(2720, 513, 43, "assets/Enemy/enemy1.png", 86, 86));
            EnemyList.Add(new Enemy(2720, 1026, 43, "assets/Enemy/enemy1.png", 86, 86));
            
            EnemyList.Add(new Enemy(0,769, 43, "assets/Enemy/enemy1.png", 86, 86, false));
            EnemyList.Add(new Enemy(2720, 769, 43, "assets/Enemy/enemy1.png", 86, 86, false));
            EnemyList.Add(new Enemy(1360, 0, 43, "assets/Enemy/enemy1.png", 86, 86, false));
            EnemyList.Add(new Enemy(1360, 1538, 43, "assets/Enemy/enemy1.png", 86, 86, false));
            BulletListNotActive.Add(new Bullet(new Vector2(0,0), new Vector2(0,0)));
            BulletListNotActive.Add(new Bullet(new Vector2(0,0), new Vector2(0,0)));
            BulletListNotActive.Add(new Bullet(new Vector2(0,0), new Vector2(0,0)));


        }
        public static void Update()
        {
            timer += Program.DeltaTime;
            camera.Update();
            foreach (Character character in CharacterList)
            {
                character.Update();
                Collision.WallsCollision(character);
                Physics.PhysicsCalculate(character);
                Physics.Friction(character);
            }
            foreach (Enemy enemy in EnemyList)
            {
                if (enemy.isActive)
                {
                    enemy.Update();
                    Collision.WallsCollisionEnemy(enemy);
                    Collision.CollisionPlayerEnemy(CharacterList[0], enemy);
                    Behavior.Follow(CharacterList[0], enemy, 480);
                    Physics.Friction(enemy);
                    Physics.PhysicsCalculate(enemy);
                }
                
            }
            
            foreach(Bullet bullet in BulletListActive) 
            {  
                bullet.Update();
                Collision.WallsCollisionBullet(bullet);
                if (Physics.Mag(bullet.Velocity) > 0.1)
                {
                    Collision.CollisionBulletEnemy(bullet);
                }
                Collision.CollisionBulletCharacter(bullet,CharacterList[0]);
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
            Wave2();
        }

        private static void Wave2()
        {
            if (Enemies && timer > 10)
            {
                Enemies = false;
                for (int i = 4; i < 8; i++)
                {
                    EnemyList[i].isActive = true;
                }
            }
        }

        public static void Render()
        {
            Engine.Draw(image, 0 - camera.Position.x, 0 - camera.Position.y);
            Engine.Draw(image, 0 - camera.Position.x, 0 + 768 - camera.Position.y);
            Engine.Draw(image, 0 + 1360 - camera.Position.x, 0 - camera.Position.y);
            Engine.Draw(image, 0 + 1360 - camera.Position.x, 0 + 768 - camera.Position.y);
            
            foreach (Bullet bullet in BulletListActive)
            {
                bullet.Render();
            }   
            foreach (Enemy enemy in EnemyList)
            {
                if (enemy.isActive)
                {
                    Vector2 position = new Vector2(enemy.Position.x - WaveController.camera.Position.x,
                        enemy.Position.y - WaveController.camera.Position.y);
                    Renderer.RenderImage(enemy.image,position);
                }
            }
            foreach (Character character in CharacterList)
            {
                Vector2 position = new Vector2( character.Position.x - WaveController.camera.Position.x,
                    character.Position.y - WaveController.camera.Position.y);
                Renderer.RenderImage(character.image,position);
                Vector2 position2 = new Vector2(character.Position.x - 26 - WaveController.camera.Position.x,
                    (character.Position.y + 56) - WaveController.camera.Position.y);
                Renderer.RenderImage(character.image2,position2);
            }

        }

        private static void Restart()
        {
            Relocate(0,true,0,513);
            Relocate(1,true,0,1026);
            Relocate(2,true,2720,513);
            Relocate(3,true,2720,1026);
            
            Relocate(4,false,0,769);
            Relocate(5,false,2720,769);
            Relocate(6,false,1360,0);
            Relocate(7,false,1360,1538);

            CharacterList[0].Position = new Vector2(1360, 768);
            CharacterList[0].Velocity = new Vector2(0, 0);
            CharacterList[0].ammo = 3;
            CharacterList[0].health = 1;

            AllBulletsNotActive();

            timer = 0;
            Enemies = true;
        }

        private static void AllBulletsNotActive()
        {
            foreach (var bullet in BulletListActive)
            {
                if (!bullet.isActive)
                {
                    Bullets.Add(bullet);
                }
                else
                {
                    bullet.isActive = false;
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

        private static void Relocate(int index, bool active, int x, int y)
        {
            EnemyList[index].Position = new Vector2(x, y);
            EnemyList[index].isActive = active;
            EnemyList[index].Velocity = new Vector2(0, 0);
        }
    }
}