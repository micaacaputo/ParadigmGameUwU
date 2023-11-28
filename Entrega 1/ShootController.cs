using System.Linq;
using MyGame.assets;

namespace MyGame
{
    public class ShootController : IShooteable
    {
        private float timer { get; set; }= 1;
        private Character character { get; }

        public ShootController(Character chara)
        {
            character = chara;
        }
        public void ShootUpdate()
        {
            timer += Program.DeltaTime;
            Shooting();
        }
        public void Reload()
        {
            foreach (var bullet in LevelController.BulletListActive)
            {
                if (bullet.reached)
                {
                    bullet.comingBack = true;
                }
            }
        }
        public void Shooting()
        {
            foreach (Enemy enemy in LevelController.EnemyPool.allList)
            {
                if (enemy.isActive)
                {
                    Vector2 vec = Physics.Res(enemy.Position, character.Position);
                    Vector2 dir = Physics.Nor(vec);
                    float mag = Physics.Mag(vec);

                    if (mag < 300 && timer > 1)
                    {
                        timer = 0;
                        if (character.ammo > 0)
                        {
                            character.ammo--;
                            Shot(dir);

                        }
                    }
                }
            }
        }
        public void Shot(Vector2 dir)
        {


            if (LevelController.BulletListNotActive.Any())
            {
                var bullet = LevelController.BulletListNotActive[0];
                Vector2 newPosition =new Vector2(character.Position.x+character.Collider.width-bullet.Collider.width, character.Position.y+character.Collider.height-bullet.Collider.height + 27);
                if (dir.x > 0)
                {
                    bullet.isRight = true;
                }
                else
                {
                    bullet.isRight = false;
                }
                bullet.isActive = true;
                bullet.Position = newPosition;
                bullet.Velocity = Physics.Mul(dir, 650);
                LevelController.BulletListActive.Add(bullet);
                LevelController.BulletListNotActive.Remove(bullet);
            }
            else
            {
                var bullet = BulletFactory.CreateBullet(new Vector2(0, 0), new Vector2(0, 0));
                LevelController.BulletListNotActive.Add(bullet);
                IBulletBehavioreable bulletBehavioreable = new BulletBehavior(bullet);
                ICollider collider = new Collider2D();
                bullet.AssignDependencies(bulletBehavioreable, collider);
            }
        }
    }
}