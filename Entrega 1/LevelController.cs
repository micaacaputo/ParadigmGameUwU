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
        static IntPtr axeHud = Engine.LoadImage("assets/HUD/axehud.png");
        static IntPtr healthHud = Engine.LoadImage("assets/HUD/healthhud.png");
        static IntPtr extraLife = Engine.LoadImage("assets/Screen/extralife.png");
        static IntPtr extraAxe = Engine.LoadImage("assets/Screen/extraaxe.png");
        public static List<Character> CharacterList = new List<Character>();
        public static GenericObjectPool<Enemy> EnemyPool= new GenericObjectPool<Enemy>();
        public static List<Bullet> BulletListActive = new List<Bullet>();
        public static List<Bullet> BulletListNotActive = new List<Bullet>();
        public static List<Bullet> Bullets = new List<Bullet>();
        public static Camera camera = new Camera();
        private static Renderer Renderer = new Renderer();
        private static int EnemigosParaRecompensa = 5;
        private static int ContadorRecompensas = EnemigosParaRecompensa;
        private static Random random = new Random();
        private static bool lifeEarned = false;
        private static bool axeEarned = false;
        private static float rewardUITimer = 0;
        private static Vector2 rewardUIPosition;
        

        public static void Initialize()
        {
            rewardUIPosition = new Vector2(680 - 207, 768 - 117);
            Collision.OnEnemyDesable += DecreaseEnemyNumber;
            GameManager.Instance.OnRestart += Restart;
            camera.Position = new Vector2(1360, 769);
            WaveController.Wave = 1;
            Engine.Initialize();
            
            CreateCharacter();
            CreateEnemies();
            CreateBullets();
        }
        public static void Update()
        {
            rewardUITimer += Program.DeltaTime;
            PhysicsAplication.Update();
            WaveController.Update();
            RewardUpdate();
        }
        public static void Render()
        {
            RenderBack();
            RenderBullets();
            RenderEnemies();
            RenderCharacter();
            RenderTextUI();
            RenderImagesUI();
            RewardUIRender();
        }

        private static void RenderImagesUI()
        {
            Renderer.RenderImage(axeHud, 585, 20);
            Renderer.RenderImage(healthHud, 735, 20);
        }

        private static void RenderTextUI()
        {
            Engine.DrawText("Score: " + GameManager.Instance.score, 20, 20, 183, 90, 249, GameManager.gameFont);
            Engine.DrawText(": " + CharacterList[0].ammo, 635, 20, 183, 90, 249, GameManager.gameFont);
            Engine.DrawText(": " + CharacterList[0].health, 780, 20, 183, 90, 249, GameManager.gameFont);
            Engine.DrawText("Wave: " + WaveController.Wave, 1200, 20, 183, 90, 249, GameManager.gameFont);
            if (CharacterList[0].InputCharacterController.reloadTimer > 3)
            {
                Engine.DrawText("Reload Ready", 1080, 720, 183, 90, 249, GameManager.gameFont);
            }
        }

        private static void RewardUIRender()
        {
            if (axeEarned)
            {
                if (rewardUITimer < 1)
                {
                    Renderer.RenderImage(extraAxe, rewardUIPosition);
                }
                else
                {
                    axeEarned = false;
                }
            }

            if (lifeEarned)
            {
                if (rewardUITimer < 1)
                {
                    Renderer.RenderImage(extraLife, rewardUIPosition);
                }
                else
                {
                    lifeEarned = false;
                }
            }
        }

        private static void RewardUpdate()
        {
            if (GameManager.Instance.score > ContadorRecompensas)
            {
                ContadorRecompensas += EnemigosParaRecompensa;
                double probabilidad = random.NextDouble();
                switch (probabilidad <= 0.5)
                {
                    case true:
                        CharacterList[0].HealthController.HealthUp();
                        lifeEarned = true;
                        rewardUITimer = 0;
                        break;
                    case false:
                        CharacterList[0].ammo++;
                        axeEarned = true;
                        rewardUITimer = 0;
                        break;
                }
            }
        }
        // Métodos de creación
        private static void CreateCharacter()
        {
            CharacterList.Add(new Character(1360, 769, 37, 74, 74));
            IShooteable shootController = new ShootController(CharacterList[0]);
            IInputeable inputController = new InputCharacterController(CharacterList[0], shootController);
            IHealthControllerable healthControllerable = new HealthController(CharacterList[0]);
            ICollider collider = new Collider2D();
            CharacterList[0].AssignDependencies(inputController, shootController, healthControllerable, collider);
        }

        private static void CreateBullets()
        {
            BulletListNotActive.AddRange(BulletFactory.InitialBullets());  
            foreach (var bullet in BulletListNotActive)
            {
                IBulletBehavioreable bulletBehavioreable = new BulletBehavior(bullet);
                ICollider collider = new Collider2D();
                bullet.AssignDependencies(bulletBehavioreable, collider);
            }
        }

        private static void CreateEnemies()
        {
            EnemyPool.allList.Add(EnemyFactory.CreateEnemyMele(0, 513, "assets/Enemy/enemy1.png"));
            EnemyPool.allList.Add(EnemyFactory.CreateEnemyMele(0, 1026, "assets/Enemy/enemy1.png"));
            EnemyPool.allList.Add(EnemyFactory.CreateEnemyMele(2720, 513, "assets/Enemy/enemy1.png"));
            EnemyPool.allList.Add(EnemyFactory.CreateEnemyMele(2720, 1026, "assets/Enemy/enemy1.png"));
            EnemyPool.allList.Add(EnemyFactory.CreateEnemyMele(2000, 0, "assets/Enemy/enemy1.png"));
            EnemyPool.allList.Add(EnemyFactory.CreateEnemyMele(1000, 1538, "assets/Enemy/enemy1.png"));

            EnemyPool.allList.Add(EnemyFactory.CreateEnemySmart(0, 769, "assets/Enemy/enemy1.png", false));
            EnemyPool.allList.Add(EnemyFactory.CreateEnemySmart(2720, 769, "assets/Enemy/enemy1.png", false));
            EnemyPool.allList.Add(EnemyFactory.CreateEnemySmart(1360, 0, "assets/Enemy/enemy1.png", false));
            EnemyPool.allList.Add(EnemyFactory.CreateEnemySmart(1360, 1538, "assets/Enemy/enemy1.png", false));
            EnemyPool.allList.Add(EnemyFactory.CreateEnemySmart(700, 0, "assets/Enemy/enemy1.png", false));
            EnemyPool.allList.Add(EnemyFactory.CreateEnemySmart(1900, 1538, "assets/Enemy/enemy1.png", false));

            foreach (var enemy in EnemyPool.allList)
            {
                ICollider collider = new Collider2D();
                enemy.AssignDependencies(collider);
            }
        }

        
        // Métodos de Renderizado
        private static void RenderCharacter()
        {
            foreach (Character character in CharacterList)
            {
                Vector2 position = new Vector2(character.Position.x - camera.Position.x,
                    character.Position.y - camera.Position.y);
                character.Renderer.RenderImage(character.currentAnimationEyes.CurrentFrame, position);
                Vector2 position2 = new Vector2(character.Position.x - 28 - camera.Position.x,
                    (character.Position.y + 56) - camera.Position.y);
                character.Renderer.RenderImage(character.currentAnimationFeetArms.CurrentFrame, position2);
            }
        }

        private static void RenderEnemies()
        {
            foreach (Enemy enemy in EnemyPool.allList)
            {
                if (enemy.isActive)
                {
                    Vector2 position = new Vector2(enemy.Position.x - camera.Position.x,
                        enemy.Position.y - camera.Position.y);
                    enemy.Renderer.RenderImage(enemy.currentAnimation.CurrentFrame, position);
                }
            }
        }

        private static void RenderBullets()
        {
            foreach (Bullet bullet in BulletListActive)
            {
                if (bullet.isActive)
                {
                    if (bullet.Velocity == new Vector2(0, 0))
                    {
                        if (bullet.isRight)
                        {
                            bullet.Renderer.RenderImage(bullet.image3, bullet.Position.x - camera.Position.x,
                                bullet.Position.y - camera.Position.y);
                        }
                        else
                        {
                            bullet.Renderer.RenderImage(bullet.image2, bullet.Position.x - camera.Position.x,
                                bullet.Position.y - camera.Position.y);
                        }
                    }
                    else
                    {
                        bullet.Renderer.RenderImage(bullet.currentAnimation.CurrentFrame, bullet.Position.x - camera.Position.x,
                            bullet.Position.y - camera.Position.y);
                    }
                }
            }
        }

        private static void RenderBack()
        {
            Renderer.RenderImage(image, 0 - camera.Position.x, 0 - camera.Position.y);
            Renderer.RenderImage(image, 0 - camera.Position.x, 0 + 768 - camera.Position.y);
            Renderer.RenderImage(image, 0 + 1360 - camera.Position.x, 0 - camera.Position.y);
            Renderer.RenderImage(image, 0 + 1360 - camera.Position.x, 0 + 768 - camera.Position.y);
        }
        
        
        //Metodos de Restart
        private static void Restart()
        {
            RelocateFirstSix();

            RelocateLastSix();

            CharacterList[0].Position = new Vector2(1360, 768);
            CharacterList[0].Velocity = new Vector2(0, 0);
            CharacterList[0].ammo = 3;
            CharacterList[0].health = 5;

            AllBulletsNotActive();

            WaveController.timer = 0;
            WaveController.Wave = 1;
        }

        public static void RelocateLastSix()
        {
            Relocate(6, false, 0, 769);
            Relocate(7, false, 2720, 769);
            Relocate(8, false, 1360, 0);
            Relocate(9, false, 1360, 1538);
            Relocate(10, false, 2000, 0);
            Relocate(11, false, 1000, 1538);
        }

        public static void RelocateFirstSix()
        {
            Relocate(0, true, 0, 513);
            Relocate(1, true, 0, 1026);
            Relocate(2, true, 2720, 513);
            Relocate(3, true, 2720, 1026);
            Relocate(4, false, 700, 0);
            Relocate(5, false, 1900, 1538);
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

        public static void Relocate(int index, bool active, int x, int y)
        {
            EnemyPool.allList[index].Position = new Vector2(x, y);
            EnemyPool.allList[index].isActive = active;
            EnemyPool.allList[index].Velocity = new Vector2(0, 0);
        }

        public static void DecreaseEnemyNumber()
        {
            WaveController.EnemyCounter--;
        }
    }
}

