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
        public static int widthCollision = 2720;
        public static int heigthCollision = 1538;
        private static int correction = 27;

        public static void WallsCollision(Character character)
        {
            if (character.Position.x < 0) //left wall
            {
                character.Position = new Vector2(0 + 1 , character.Position.y);
                character.Velocity = new Vector2(0, character.Velocity.y);
            }
            if (character.Position.x > widthCollision - character.width) //right wall
            {
                character.Position = new Vector2(widthCollision - character.width - 1, character.Position.y);
                character.Velocity = new Vector2(0, character.Velocity.y);
            }
            if (character.Position.y < 0 - correction) //up wall
            {
                character.Position = new Vector2(character.Position.x ,0 + 1 - correction);
                character.Velocity = new Vector2(character.Velocity.x, 0);
            }
            if (character.Position.y > heigthCollision - character.height - correction) //down wall
            {
                character.Position = new Vector2(character.Position.x, heigthCollision - character.height - 1 - correction);
                character.Velocity = new Vector2(character.Velocity.x, 0);
            }
        }

        public static void WallsCollisionEnemy(Enemy enemy)
        {
            if (enemy.Position.x < 0) //left wall
            {
                enemy.Position = new Vector2(0 + 1, enemy.Position.y);
                enemy.Velocity = new Vector2(0, enemy.Velocity.y);
            }
            if (enemy.Position.x > widthCollision - enemy.width) //right wall
            {
                enemy.Position = new Vector2(widthCollision - enemy.width - 1, enemy.Position.y);
                enemy.Velocity = new Vector2(0, enemy.Velocity.y);
            }
            if (enemy.Position.y < 0) //up wall
            {
                enemy.Position = new Vector2(enemy.Position.x, 0 + 1);
                enemy.Velocity = new Vector2(enemy.Velocity.x, 0);
            }
            if (enemy.Position.y > heigthCollision - enemy.height) //down wall
            {
                enemy.Position = new Vector2(enemy.Position.x, heigthCollision - enemy.height - 1);
                enemy.Velocity = new Vector2(enemy.Velocity.x, 0);
            }
        }

        public static void CollisionPlayerEnemy(Character character, Enemy enemy)
        {
            if (enemy.isActive)
            {
                var A = ((character.Position.x + 0.5f * character.width  - (enemy.Position.x + 0.5f * enemy.width)));
                var B = ((character.Position.y + correction + 0.5f * character.height - (enemy.Position.y + 0.5f * enemy.height)));
                var Mag = Physics.Mag(new Vector2(A, B));

                if (Mag < character.radius + enemy.radius) {

                
                    if (enemy.timer > 1)
                    {
                        character.HealthDown();
                        enemy.timer = 0;

                    }

                }
            }
            
        }

        public static void WallsCollisionBullet(Bullet bullet)
        {
            if (bullet.Position.x < 0) //left wall
            {
                bullet.Position = new Vector2(0, bullet.Position.y);
                bullet.Velocity = new Vector2(0, 0);
            }
            if (bullet.Position.x > widthCollision - 58) //right wall
            {
                bullet.Position = new Vector2(widthCollision - 58, bullet.Position.y);
                bullet.Velocity = new Vector2(0, 0);
            }
            if (bullet.Position.y < 0) //up wall
            {
                bullet.Position = new Vector2(bullet.Position.x, 0);
                bullet.Velocity = new Vector2(0, 0);
            }
            if (bullet.Position.y > heigthCollision - 75) //down wall
            {
                bullet.Position = new Vector2(bullet.Position.x, heigthCollision - 75);
                bullet.Velocity = new Vector2(0, 0);
            }
        }

        public static void CollisionBulletEnemy(Bullet bullet)
        {
            if (bullet.isActive)
            {
                foreach (var enemy in Program.EnemyList)
                {
                    if (enemy.isActive)
                    {
                        
                        var A = ((bullet.Position.x + 0.5f * bullet.width  - (enemy.Position.x + 0.5f * enemy.width)));
                        var B = ((bullet.Position.y + 0.5f * bullet.height - (enemy.Position.y + 0.5f * enemy.height)));
                        var Mag = Physics.Mag(new Vector2(A, B));

                        if (Mag < bullet.radius + enemy.radius)
                        {
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
                var A = ((bullet.Position.x + 0.5f * bullet.width  - (character.Position.x + 0.5f * character.width)));
                var B = ((bullet.Position.y + 0.5f * bullet.height - (character.Position.y + correction + 0.5f * character.height)));
                var Mag = Physics.Mag(new Vector2(A, B));

                if( Mag < bullet.radius + character.radius & bullet.reached) 
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
