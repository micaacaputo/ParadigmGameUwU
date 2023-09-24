using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGame
{
    public static class Comportamiento
    {
        public static void follow(Character character, Enemy enemy,float fuerza)
        {
            var A = (character.x + 0.5*character.radio)- (enemy.x+0.5*enemy.radio);
            var B = (character.y + 0.5 * character.radio) - (enemy.y + 0.5 * enemy.radio);
            var Mag = Math.Sqrt(A * A + B * B);
            var X = (float)(A/Mag);
            var Y = (float)(B/Mag);
            Physics.AddForce(enemy, X*fuerza, Y*fuerza);
        }
    }
}
