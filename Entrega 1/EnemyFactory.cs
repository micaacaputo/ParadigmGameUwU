using MyGame.assets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGame
{
    public static class EnemyFactory
    {
        public static Enemy CreateEnemy(Vector2 position, string image, bool isActive = true)
        {
            var enemy = new Enemy(position.x,position.y,image,isActive);
            return enemy;
        }
        public static Enemy CreateEnemy(int positionX, int positionY, string image, bool isActive = true)
        {
            var enemy = new Enemy(positionX, positionY, image, isActive);
            return enemy;
        }
    }
}
