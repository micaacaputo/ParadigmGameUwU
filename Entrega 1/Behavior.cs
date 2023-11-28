using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGame
{
    public static class Behavior
    {
        public static void Follow(Character character, Enemy enemy,float fuerza)
        {
            var vec = Physics.Res(character.Position, enemy.Position);
            var vecNor = Physics.Nor(vec);
            Physics.AddForce(enemy,Physics.Mul(vecNor,fuerza));
        }
        public static void SmartFollow(Character character, EnemySmart enemy,float fuerza)
        {
            var vec = Physics.Res(character.Position, enemy.Position);
            var vecNor = Physics.Nor(vec);
            if (enemy.impulseTimer > 1.0f)
            {
                Physics.AddImpulse(enemy,Physics.Mul(vecNor,fuerza));
                enemy.impulseTimer = 0;
            }
            
        }
    }
}
