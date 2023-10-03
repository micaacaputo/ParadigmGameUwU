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
        static public List<Character> CharacterList = new List<Character>();
        static public List<Enemy> EnemyList = new List<Enemy>();
        static public List<Bullet> BulletListActive = new List<Bullet>();
        static public List<Bullet> BulletListNotActive = new List<Bullet>();
        static public List<Bullet> Bullets = new List<Bullet>();
        static public Camera camera = new Camera();
        

        public static void Initialize()
        {
            Engine.Initialize();
            CharacterList.Add(new Character(600, 334, 37, 74, 74));
            EnemyList.Add(new Enemy(0,0, 43, "assets/Enemy/enemy1.png", 86, 86));
            EnemyList.Add(new Enemy(0, 700, 43, "assets/Enemy/enemy1.png", 86, 86));
            EnemyList.Add(new Enemy(1200, 0, 43, "assets/Enemy/enemy1.png", 86, 86));
            EnemyList.Add(new Enemy(1200, 700, 43, "assets/Enemy/enemy1.png", 86, 86));
            BulletListNotActive.Add(new Bullet(new Vector2(0,0), new Vector2(0,0)));
            BulletListNotActive.Add(new Bullet(new Vector2(0,0), new Vector2(0,0)));
            BulletListNotActive.Add(new Bullet(new Vector2(0,0), new Vector2(0,0)));


        }
        public static void Update()
        {
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
                enemy.Update();
                Collision.WallsCollisionEnemy(enemy);
                Collision.CollisionPlayerEnemy(CharacterList[0], enemy);
                Behavior.Follow(CharacterList[0], enemy, 480);
                Physics.Friction(enemy);
                Physics.PhysicsCalculate(enemy);
            }
            
            foreach(Bullet bullet in BulletListActive) 
            {  
                bullet.Update();
                Collision.WallsCollisionBullet(bullet);
                Collision.CollisionBulletEnemy(bullet);
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
        }

        public static void Render()
        {
            Engine.Draw(image, 0 - camera.Position.x, 0 - camera.Position.y);
            Engine.Draw(image, 0 - camera.Position.x, 0 + 768 - camera.Position.y);
            Engine.Draw(image, 0 + 1360 - camera.Position.x, 0 - camera.Position.y);
            Engine.Draw(image, 0 + 1360 - camera.Position.x, 0 + 768 - camera.Position.y);
            

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