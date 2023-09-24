using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGame
{
    public static class Comportamiento
    {
        public static void Follow(Character character, Enemy enemy,float fuerza)
        {
            var vec = Physics.Res(character.Position, enemy.Position);
            var vecNor = Physics.Nor(vec);
            Physics.AddForce(enemy,Physics.Mul(vecNor,fuerza));
        }
    }
}
