using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGame
{
    public static class Colision
    {
        private static int widthCollision = Engine.GetWidth();
        private static int heigthCollision = Engine.GetHeight();
        private static float timer = 0;

        public static void WallsCollision(Character character)
        {
            if(character.x < 0) //Pared izquierda
            {
                character.x = 0;
                character.velX = 0;
            }
            if(character.x > widthCollision - 100) //Pared derecha
            {
                character.x = widthCollision - 100;
                character.velX = 0;
            }
            if(character.y < 0) //Pared arriba
            {
                character.y = 0;
                character.velY = 0;
            }
            if(character.y > heigthCollision - 100) //Pared abajo
            {
                character.y = heigthCollision - 100;
                character.velY = 0;
            }
        }

        public static void WallsCollisionEnemy(Enemy enemy)
        {
            if (enemy.x < 0) //Pared izquierda
            {
                enemy.x = 1;
                enemy.velX = 0;
            }
            if (enemy.x > widthCollision - 105) //Pared derecha
            {
                enemy.x = widthCollision - 105;
                enemy.velX = 0;
            }
            if (enemy.y < 0) //Pared arriba
            {
                enemy.y = 1;
                enemy.velY = 0;
            }
            if (enemy.y > heigthCollision - 105) //Pared abajo
            {
                enemy.y = heigthCollision - 105;
                enemy.velY = 0;
            }
        }

        public static void CollisionPlayerEnemy(Character character, Enemy enemy)
        {
            var A = (character.x + 0.5 * character.radio) - (enemy.x + 0.5 * enemy.radio);
            var B = (character.y + 0.5 * character.radio) - (enemy.y + 0.5 * enemy.radio);
            var Mag = Math.Sqrt(A * A + B * B);
            if (Mag < character.radio + enemy.radio) {

                
                timer += Program.DeltaTime;
                if(timer > 1)
                {
                    character.health -= 1;
                    timer = 0;
                    Console.WriteLine("vida: " + character.health);
                
                }
                enemy.isActive = false;

            }
        }


    }
}
