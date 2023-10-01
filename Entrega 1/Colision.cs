using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyGame.assets;

namespace MyGame
{
    public static class Colision
    {
        private static int widthCollision = Engine.GetWidth();
        private static int heigthCollision = Engine.GetHeight();
        private static float timer = 0;

        public static void WallsCollision(Character character)
        {
            if (character.Position.x < 0) //Pared izquierda
            {
                character.Position = new Vector2(0 + 1 , character.Position.y);
                character.Velocity = new Vector2(0, character.Velocity.y);
            }
            if (character.Position.x > widthCollision - character.width) //Pared derecha
            {
                character.Position = new Vector2(widthCollision - character.width - 1, character.Position.y);
                character.Velocity = new Vector2(0, character.Velocity.y);
            }
            if (character.Position.y < 0) //Pared arriba
            {
                character.Position = new Vector2(character.Position.x ,0 + 1);
                character.Velocity = new Vector2(character.Velocity.x, 0);
            }
            if (character.Position.y > heigthCollision - character.height) //Pared abajo
            {
                character.Position = new Vector2(character.Position.x, heigthCollision - character.height - 1);
                character.Velocity = new Vector2(character.Velocity.x, 0);
            }
        }

        public static void WallsCollisionEnemy(Enemy enemy)
        {
            if (enemy.Position.x < 0) //Pared izquierda
            {
                enemy.Position = new Vector2(0 + 1, enemy.Position.y);
                enemy.Velocity = new Vector2(0, enemy.Velocity.y);
            }
            if (enemy.Position.x > widthCollision - enemy.width) //Pared derecha
            {
                enemy.Position = new Vector2(widthCollision - enemy.width - 1, enemy.Position.y);
                enemy.Velocity = new Vector2(0, enemy.Velocity.y);
            }
            if (enemy.Position.y < 0) //Pared arriba
            {
                enemy.Position = new Vector2(enemy.Position.x, 0 + 1);
                enemy.Velocity = new Vector2(enemy.Velocity.x, 0);
            }
            if (enemy.Position.y > heigthCollision - enemy.height) //Pared abajo
            {
                enemy.Position = new Vector2(enemy.Position.x, heigthCollision - enemy.height - 1);
                enemy.Velocity = new Vector2(enemy.Velocity.x, 0);
            }
        }

        public static void CollisionPlayerEnemy(Character character, Enemy enemy)
        {
            var A = ((character.Position.x + 0.5f * character.width) - (enemy.Position.x + 0.5f * enemy.width));
            var B = ((character.Position.y + 0.5f * character.height) - (enemy.Position.y + 0.5f * enemy.height));
            var Mag = Physics.Mag(new Vector2(A, B));

            if (Mag < character.radio + enemy.radio) {


                timer += Program.DeltaTime;
                if (timer > 1)
                {
                    character.health -= 1;
                    timer = 0;
                    Console.WriteLine("vida: " + character.health);

                }
                enemy.isActive = false;

            }
        }

        public static void WallsCollisionBullet(Bullet bullet)
        {
            if (bullet.Position.x < 0) //Pared izquierda
            {
                bullet.Position = new Vector2(0, bullet.Position.y);
                bullet.Velocity = new Vector2(0, 0);
            }
            if (bullet.Position.x > widthCollision - 58) //Pared derecha
            {
                bullet.Position = new Vector2(widthCollision - 58, bullet.Position.y);
                bullet.Velocity = new Vector2(0, 0);
            }
            if (bullet.Position.y < 0) //Pared arriba
            {
                bullet.Position = new Vector2(bullet.Position.x, 0);
                bullet.Velocity = new Vector2(0, 0);
            }
            if (bullet.Position.y > heigthCollision - 75) //Pared abajo
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
                    Vector2 vec = Physics.Res(enemy.Position, bullet.Position);
                    float magnitud = Physics.Mag(vec);

                    if( magnitud < bullet.radio + enemy.radio)
                    {
                        enemy.isActive = false;
                        bullet.Velocity = new Vector2(0,0);

                    }
                }
            }

        }
        public static void CollisionBulletCharacter(Bullet bullet, Character character)
        {
            if (bullet.isActive)
            {
                Vector2 vec = Physics.Res(character.Position , bullet.Position);
                float magnitud = Physics.Mag(vec);

                if( magnitud < bullet.radio + character.radio & bullet.reached) 
                { 
                    bullet.isActive = false; 
                    bullet.Velocity = new Vector2(0,0);
                    bullet.reached = false;
                    character.ammo++;
                }
            }

        }

    }
}
