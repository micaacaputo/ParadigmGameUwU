using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGame
{
    public static class PhysicsAplication
    {
        public static void Update()
        {
            LevelController.camera.Update();
            foreach (Character character in LevelController.CharacterList)
            {
                character.Update();
                Collision.WallsCollision(character);
                Physics.PhysicsCalculate(character);
                Physics.Friction(character);
            }
            foreach (Enemy enemy in LevelController.EnemyList)
            {
                if (enemy.isActive)
                {
                    enemy.Update();
                    Collision.WallsCollisionEnemy(enemy);
                    Collision.CollisionPlayerEnemy(LevelController.CharacterList[0], enemy);
                    Behavior.Follow(LevelController.CharacterList[0], enemy, 480);
                    Physics.Friction(enemy);
                    Physics.PhysicsCalculate(enemy);
                }

            }

            foreach (Bullet bullet in LevelController.BulletListActive)
            {
                bullet.Update();
                Collision.WallsCollisionBullet(bullet);
                if (Physics.Mag(bullet.Velocity) > 0.1)
                {
                    Collision.CollisionBulletEnemy(bullet);
                }
                Collision.CollisionBulletCharacter(bullet, LevelController.CharacterList[0]);
                Physics.PhysicsCalculate(bullet);
                if (!bullet.isActive)
                {
                    LevelController.Bullets.Add(bullet);
                }
            }
            foreach (var bullet in LevelController.Bullets)
            {
                LevelController.BulletListActive.Remove(bullet);
                LevelController.BulletListNotActive.Add(bullet);
            }
            LevelController.Bullets.Clear();
        }
    }
}
