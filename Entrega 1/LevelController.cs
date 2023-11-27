using MyGame.assets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGame
{
    public static class LevelController
    {
        static IntPtr image = Engine.LoadImage("assets/fondoPoo.png");
        public static List<Character> CharacterList = new List<Character>();
        public static List<Enemy> EnemyList = new List<Enemy>();
        public static List<Bullet> BulletListActive = new List<Bullet>();
        public static List<Bullet> BulletListNotActive = new List<Bullet>();
        public static List<Bullet> Bullets = new List<Bullet>();
        public static Camera camera = new Camera();
        

        public static void Initialize()
        {
            
            GameManager.Instance.OnRestart += Restart;
            camera.Position = new Vector2(1360, 769);
            WaveController.Enemies = true;
            Engine.Initialize();
            
            CharacterList.Add(new Character(1360, 769, 37, 74, 74));
            IShooteable shootController = new ShootController(CharacterList[0]);
            IInputeable inputController = new InputCharacterController(CharacterList[0], shootController);
            IHealthControllerable healthControllerable = new HealthController(CharacterList[0]);
            CharacterList[0].AssignDependecies(inputController,shootController, healthControllerable);
            EnemyList.Add(EnemyFactory.CreateEnemy(0, 513, "assets/Enemy/enemy1.png"));
            EnemyList.Add(EnemyFactory.CreateEnemy(0, 1026, "assets/Enemy/enemy1.png"));
            EnemyList.Add(EnemyFactory.CreateEnemy(2720, 513, "assets/Enemy/enemy1.png"));
            EnemyList.Add(EnemyFactory.CreateEnemy(2720, 1026, "assets/Enemy/enemy1.png"));

            EnemyList.Add(EnemyFactory.CreateEnemy(0, 769, "assets/Enemy/enemy1.png", false));
            EnemyList.Add(EnemyFactory.CreateEnemy(2720, 769, "assets/Enemy/enemy1.png", false));
            EnemyList.Add(EnemyFactory.CreateEnemy(1360, 0, "assets/Enemy/enemy1.png", false));
            EnemyList.Add(EnemyFactory.CreateEnemy(1360, 1538, "assets/Enemy/enemy1.png", false));

            BulletListNotActive.Add(new Bullet(new Vector2(0, 0), new Vector2(0, 0)));
            BulletListNotActive.Add(new Bullet(new Vector2(0, 0), new Vector2(0, 0)));
            BulletListNotActive.Add(new Bullet(new Vector2(0, 0), new Vector2(0, 0)));


        }

        

        public static void Update()
        {
            PhysicsAplication.Update();
            WaveController.Update();
        }
        public static void Render() // Esto vuela (Renderer)
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
                    Vector2 position = new Vector2(enemy.Position.x - camera.Position.x,
                        enemy.Position.y - camera.Position.y);
                    Renderer.RenderImage(enemy.image, position);
                }
            }
            foreach (Character character in CharacterList)
            {
                Vector2 position = new Vector2(character.Position.x - camera.Position.x,
                    character.Position.y - camera.Position.y);
                Renderer.RenderImage(character.image, position);
                Vector2 position2 = new Vector2(character.Position.x - 26 - camera.Position.x,
                    (character.Position.y + 56) - camera.Position.y);
                Renderer.RenderImage(character.image2, position2);
            }

        }
        private static void Restart()
        {
            Relocate(0, true, 0, 513);
            Relocate(1, true, 0, 1026);
            Relocate(2, true, 2720, 513);
            Relocate(3, true, 2720, 1026);

            Relocate(4, false, 0, 769);
            Relocate(5, false, 2720, 769);
            Relocate(6, false, 1360, 0);
            Relocate(7, false, 1360, 1538);

            CharacterList[0].Position = new Vector2(1360, 768);
            CharacterList[0].Velocity = new Vector2(0, 0);
            CharacterList[0].ammo = 3;
            CharacterList[0].health = 1;

            AllBulletsNotActive();

            WaveController.timer = 0;
            WaveController.Enemies = true;
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

