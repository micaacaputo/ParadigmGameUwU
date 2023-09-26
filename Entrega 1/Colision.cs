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
            if (character.Position.x < 0 - 50) //Pared izquierda
            {
                character.Position = new Vector2(0 - 50, character.Position.y);
                character.Velocity = new Vector2(0, character.Velocity.y);
            }
            if (character.Position.x > widthCollision - 150) //Pared derecha
            {
                character.Position = new Vector2(widthCollision - 150, character.Position.y);
                character.Velocity = new Vector2(0, character.Velocity.y);
            }
            if (character.Position.y < 0) //Pared arriba
            {
                character.Position = new Vector2(character.Position.x, 0);
                character.Velocity = new Vector2(character.Velocity.x, 0);
            }
            if (character.Position.y > heigthCollision - 150) //Pared abajo
            {
                character.Position = new Vector2(character.Position.x, heigthCollision - 150);
                character.Velocity = new Vector2(character.Velocity.x, 0);
            }
        }

        public static void WallsCollisionEnemy(Enemy enemy)
        {
            if (enemy.Position.x < 0) //Pared izquierda
            {
                enemy.Position = new Vector2(0, enemy.Position.y);
                enemy.Velocity = new Vector2(0, enemy.Velocity.y);
            }
            if (enemy.Position.x > widthCollision - 100) //Pared derecha
            {
                enemy.Position = new Vector2(widthCollision - 100, enemy.Position.y);
                enemy.Velocity = new Vector2(0, enemy.Velocity.y);
            }
            if (enemy.Position.y < 0) //Pared arriba
            {
                enemy.Position = new Vector2(enemy.Position.x, 0);
                enemy.Velocity = new Vector2(enemy.Velocity.x, 0);
            }
            if (enemy.Position.y > heigthCollision - 100) //Pared abajo
            {
                enemy.Position = new Vector2(enemy.Position.x, heigthCollision - 100);
                enemy.Velocity = new Vector2(enemy.Velocity.x, 0);
            }
        }

        public static void CollisionPlayerEnemy(Character character, Enemy enemy)
        {
            var A = (float)((character.Position.x + 0.5 * character.radio) - (enemy.Position.x + 0.5 * enemy.radio));
            var B = (float)((character.Position.y + 0.5 * character.radio) - (enemy.Position.y + 0.5 * enemy.radio));
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
                    bullet.isActive = false;

                }
            }
            }

        }

    }
}
