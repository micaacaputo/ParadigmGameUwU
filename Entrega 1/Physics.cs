using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyGame.assets;

namespace MyGame
{
    public static class Physics
    {
        //multiply
        public static Vector2 Mul(Vector2 vector,float num)
        {
            return new Vector2(vector.x * num, vector.y * num);
        }
        public static Vector2 Mul(Vector2 vector,int num)
        {
            return new Vector2(vector.x * num, vector.y * num);
        }
        //Division
        public static Vector2 Div(Vector2 vector, float num)
        {
            return new Vector2(vector.x / num, vector.y / num);
        }
        public static Vector2 Div(Vector2 vector, int num)
        {
            return new Vector2(vector.x / num, vector.y / num);
        }
        //Sum
        public static Vector2 Sum(Vector2 vector1, Vector2 vector2)
        {
            return new Vector2(vector1.x + vector2.x, vector1.y + vector2.y);
        }
        //Subtraction
        public static Vector2 Res(Vector2 vector1, Vector2 vector2)
        {
            return new Vector2(vector1.x - vector2.x, vector1.y - vector2.y);
        }
        //Magnitude
        public static float Mag(Vector2 vector)
        {
            return (float)Math.Sqrt(vector.x * vector.x + vector.y * vector.y);
        }
        //Normalized
        public static Vector2 Nor(Vector2 vector)
        {
            var magnitude = Mag(vector);
            return new Vector2(vector.x / magnitude, vector.y / magnitude);
        }
        //Dot
        public static float Dot(Vector2 vector1, Vector2 vector2)
        {
            return vector1.x * vector2.x + vector1.y * vector2.y;
        }
        public static void PhysicsCalculate(Character character)
        {
            //MRUV
            character.Velocity = Sum(character.Velocity, Mul(character.Aceleration, Program.DeltaTime));
            character.Position = Sum(character.Position,Sum(Mul(character.Velocity, Program.DeltaTime),Mul(character.Aceleration,(0.5f * Program.DeltaTime * Program.DeltaTime)))); 
            
            character.Aceleration = new Vector2(0, 0);

        }
        public static void PhysicsCalculate(Enemy character)
        {
            //MRUV
            character.Velocity = Sum(character.Velocity, Mul(character.Aceleration, Program.DeltaTime));
            character.Position = Sum(character.Position,Sum(Mul(character.Velocity, Program.DeltaTime),Mul(character.Aceleration,(0.5f * Program.DeltaTime * Program.DeltaTime)))); 
         
            character.Aceleration = new Vector2(0, 0);

        }
        public static void PhysicsCalculate(Bullet character)
        {
            //MRUV
            character.Velocity = Sum(character.Velocity, Mul(character.Aceleration, Program.DeltaTime));
            character.Position = Sum(character.Position,Sum(Mul(character.Velocity, Program.DeltaTime),Mul(character.Aceleration,(0.5f * Program.DeltaTime * Program.DeltaTime)))); 
            
            character.Aceleration = new Vector2(0, 0);
            
        }
        public static void PhysicsCalculate(Camera character)
        {
            //MRUV
            character.Velocity = Sum(character.Velocity, Mul(character.Aceleration, Program.DeltaTime));
            character.Position = Sum(character.Position,Sum(Mul(character.Velocity, Program.DeltaTime),Mul(character.Aceleration,(0.5f * Program.DeltaTime * Program.DeltaTime)))); 
            
            character.Aceleration = new Vector2(0, 0);
            
        }

        public static void AddForce(Character character, Vector2 force)
        {
            character.Aceleration = Sum(character.Aceleration, Div(force, character.mass));
        }
        public static void AddForce(Enemy character, Vector2 force)
        {
            character.Aceleration = Sum(character.Aceleration, Div(force, character.mass));
        }
        public static void AddForce(Bullet character, Vector2 force)
        {
            character.Aceleration = Sum(character.Aceleration, Div(force, character.mass));
        }
        
        public static void AddImpulse(Enemy character, Vector2 force)
        {
            character.Velocity = Sum(character.Aceleration, Div(force, character.mass));
        }
        public static void Friction(Character character)
        {
            var nor = Nor(character.Velocity);
            var mag = Mag(nor);
            if (mag > 0.1)
            {
                AddForce(character, Mul(nor, -200));
            }
            else
            {
                AddForce(character,Mul(character.Velocity,-10));
            }
        }
        public static void Friction(Enemy character)
        {
            var nor = Nor(character.Velocity);
            var mag = Mag(nor);
            if (mag > 0.1)
            {
                AddForce(character, Mul(nor, -300));
            }
        }
    }

}

