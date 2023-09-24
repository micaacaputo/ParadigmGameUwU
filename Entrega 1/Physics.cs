using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGame
{
    public static class Physics
    {
        public static void PhysicsCalculate(Character character)
        {
            //MRUV
            character.velX = character.velX + character.aceX * Program.DeltaTime;
            character.velY = character.velY + character.aceY * Program.DeltaTime;

            character.x = character.x + character.velX * Program.DeltaTime + character.aceX * 0.5f * Program.DeltaTime * Program.DeltaTime;
            character.y = character.y + character.velY * Program.DeltaTime + character.aceY * 0.5f * Program.DeltaTime * Program.DeltaTime;

            //Seteo la aceleracion
            character.aceX = 0;
            character.aceY = 0;

            //MCU
            character.w = character.w + character.ar * Program.DeltaTime;

            //Seteo la aceleracion
            character.w = 0;
            character.ar = 0;
        }
        public static void PhysicsCalculate(Enemy character)
        {
            //MRUV
            character.velX = character.velX + character.aceX * Program.DeltaTime;
            character.velY = character.velY + character.aceY * Program.DeltaTime;

            character.x = (character.x + character.velX * Program.DeltaTime + character.aceX * 0.5f * Program.DeltaTime * Program.DeltaTime);
            character.y = (character.y + character.velY * Program.DeltaTime + character.aceY * 0.5f * Program.DeltaTime * Program.DeltaTime);

            //Seteo la aceleracion
            character.aceX = 0;
            character.aceY = 0;

            //MCU
            character.w = character.w + character.ar * Program.DeltaTime;

            //Seteo la aceleracion
            character.w = 0;
            character.ar = 0;
        }

        public static void AddForce(Character character, float forceX, float forceY)
        {
            character.aceX = character.aceX + forceX / character.mass;
            character.aceY = character.aceY + forceY / character.mass;
        }
        public static void AddForce(Enemy character, float forceX, float forceY)
        {
            character.aceX = character.aceX + forceX / character.mass;
            character.aceY = character.aceY + forceY / character.mass;
        }
    }

}

