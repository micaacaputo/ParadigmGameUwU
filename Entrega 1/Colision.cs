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
            if(character.Position.x < 0) //Pared izquierda
            {
                character.Position = new Vector2(0,character.Position.y);
                character.Velocity = new Vector2(0,character.Velocity.y);
            }
            if(character.Position.x > widthCollision - 100) //Pared derecha
            {
                character.Position = new Vector2(widthCollision-100,character.Position.y);
                character.Velocity = new Vector2(0,character.Velocity.y);
            }
            if(character.Position.y < 0) //Pared arriba
            {
                character.Position = new Vector2(character.Position.x,0);
                character.Velocity = new Vector2(character.Velocity.x,0);
            }
            if(character.Position.y > heigthCollision - 100) //Pared abajo
            {
                character.Position = new Vector2(character.Position.x,heigthCollision-100);
                character.Velocity = new Vector2(character.Velocity.x,0);
            }
        }

        public static void WallsCollisionEnemy(Enemy enemy)
        {
            if(enemy.Position.x < 0) //Pared izquierda
            {
                enemy.Position = new Vector2(0,enemy.Position.y);
                enemy.Velocity = new Vector2(0,enemy.Velocity.y);
            }
            if(enemy.Position.x > widthCollision - 100) //Pared derecha
            {
                enemy.Position = new Vector2(widthCollision-100,enemy.Position.y);
                enemy.Velocity = new Vector2(0,enemy.Velocity.y);
            }
            if(enemy.Position.y < 0) //Pared arriba
            {
                enemy.Position = new Vector2(enemy.Position.x,0);
                enemy.Velocity = new Vector2(enemy.Velocity.x,0);
            }
            if(enemy.Position.y > heigthCollision - 100) //Pared abajo
            {
                enemy.Position = new Vector2(enemy.Position.x,heigthCollision-100);
                enemy.Velocity = new Vector2(enemy.Velocity.x,0);
            }
        }

        public static void CollisionPlayerEnemy(Character character, Enemy enemy)
        {
            var A = (float)((character.Position.x + 0.5 * character.radio) - (enemy.Position.x + 0.5 * enemy.radio));
            var B = (float)((character.Position.y + 0.5 * character.radio) - (enemy.Position.y + 0.5 * enemy.radio));
            var Mag = Physics.Mag(new Vector2(A,B));
            
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
