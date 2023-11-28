using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyGame.assets;

namespace MyGame
{
    public static class Collision
    {
        private static int widthCollision => 2720;
        private static int heigthCollision => 1538;
        private static int correction => 27;
        public static Action OnEnemyDesable { get; set; }

        public static void WallsCollision(Character character)
        {
            if (character.Position.x < 0) //left wall
            {
                character.Position = new Vector2(0 + 1 , character.Position.y);
                character.Velocity = new Vector2(0, character.Velocity.y);
            }
            if (character.Position.x > widthCollision - character.Collider.width) //right wall
            {
                character.Position = new Vector2(widthCollision - character.Collider.width - 1, character.Position.y);
                character.Velocity = new Vector2(0, character.Velocity.y);
            }
            if (character.Position.y < 0 - correction) //up wall
            {
                character.Position = new Vector2(character.Position.x ,0 + 1 - correction);
                character.Velocity = new Vector2(character.Velocity.x, 0);
            }
            if (character.Position.y > heigthCollision - character.Collider.height - correction) //down wall
            {
                character.Position = new Vector2(character.Position.x, heigthCollision - character.Collider.height - 1 - correction);
                character.Velocity = new Vector2(character.Velocity.x, 0);
            }
        }

        public static void WallsCollisionEnemy(Enemy enemy)
        {
            if (enemy.Position.x < 0) 
            {
                enemy.Position = new Vector2(0 + 1, enemy.Position.y);
                enemy.Velocity = new Vector2(0, enemy.Velocity.y);
            }
            if (enemy.Position.x > widthCollision - enemy.Collider.width) 
            {
                enemy.Position = new Vector2(widthCollision - enemy.Collider.width - 1, enemy.Position.y);
                enemy.Velocity = new Vector2(0, enemy.Velocity.y);
            }
            if (enemy.Position.y < 0) 
            {
                enemy.Position = new Vector2(enemy.Position.x, 0 + 1);
                enemy.Velocity = new Vector2(enemy.Velocity.x, 0);
            }
            if (enemy.Position.y > heigthCollision - enemy.Collider.height) 
            {
                enemy.Position = new Vector2(enemy.Position.x, heigthCollision - enemy.Collider.height - 1);
                enemy.Velocity = new Vector2(enemy.Velocity.x, 0);
            }
        }

        public static void CollisionPlayerEnemy(Character character, Enemy enemy)
        {
            if (enemy.isActive)
            {
                var A = ((character.Position.x + 0.5f * character.Collider.width  - (enemy.Position.x + 0.5f * enemy.Collider.width)));
                var B = ((character.Position.y + correction + 0.5f * character.Collider.height - (enemy.Position.y + 0.5f * enemy.Collider.height)));
                var Mag = Physics.Mag(new Vector2(A, B));

                if (Mag < character.Collider.radius + enemy.Collider.radius) {

                
                    if (enemy.timer > 0.6 && character.invulnerabilityTimer > 0.6)
                    {
                        character.HealthController.HealthDown();
                        enemy.timer = 0;
                        character.invulnerabilityTimer = 0;

                    }

                }
            }
            
        }

        public static void WallsCollisionBullet(Bullet bullet)
        {
            if (bullet.Position.x < 0) 
            {
                bullet.Position = new Vector2(0, bullet.Position.y);
                bullet.Velocity = new Vector2(0, 0);
            }
            if (bullet.Position.x > widthCollision - 58) 
            {
                bullet.Position = new Vector2(widthCollision - 58, bullet.Position.y);
                bullet.Velocity = new Vector2(0, 0);
            }
            if (bullet.Position.y < 0) 
            {
                bullet.Position = new Vector2(bullet.Position.x, 0);
                bullet.Velocity = new Vector2(0, 0);
            }
            if (bullet.Position.y > heigthCollision - 75) 
            {
                bullet.Position = new Vector2(bullet.Position.x, heigthCollision - 75);
                bullet.Velocity = new Vector2(0, 0);
            }
        }

        public static void CollisionBulletEnemy(Bullet bullet)
        {
            if (bullet.isActive)
            {
                foreach (var enemy in LevelController.EnemyPool.allList)
                {
                    if (enemy.isActive)
                    {
                        
                        var A = ((bullet.Position.x + 0.5f * bullet.Collider.width  - (enemy.Position.x + 0.5f * enemy.Collider.width)));
                        var B = ((bullet.Position.y + 0.5f * bullet.Collider.height - (enemy.Position.y + 0.5f * enemy.Collider.height)));
                        var Mag = Physics.Mag(new Vector2(A, B));

                        if (Mag < bullet.Collider.radius + enemy.Collider.radius)
                        {
                            OnEnemyDesable?.Invoke();
                            enemy.isActive = false;
                            bullet.Velocity = new Vector2(0, 0);

                        }
                    }
                }
            }

        }
        public static void CollisionBulletCharacter(Bullet bullet, Character character)
        {
            if (bullet.isActive)
            {
                var A = ((bullet.Position.x + 0.5f * bullet.Collider.width  - (character.Position.x + 0.5f * character.Collider.width)));
                var B = ((bullet.Position.y + 0.5f * bullet.Collider.height - (character.Position.y + correction + 0.5f * character.Collider.height)));
                var Mag = Physics.Mag(new Vector2(A, B));

                if( Mag < bullet.Collider.radius + character.Collider.radius & bullet.reached) 
                { 
                    bullet.isActive = false; 
                    bullet.Velocity = new Vector2(0,0);
                    bullet.reached = false;
                    bullet.comingBack = false;
                    character.ammo++;
                }
            }

        }

    }
}
