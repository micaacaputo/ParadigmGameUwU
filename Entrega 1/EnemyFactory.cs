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
        public static EnemyMele CreateEnemyMele(Vector2 position, string image, bool isActive = true)
        {
            var enemy = new EnemyMele(position.x,position.y,image,EnemyType.Mele,isActive);
            return enemy;
        }
        public static EnemyMele CreateEnemyMele(int positionX, int positionY, string image, bool isActive = true)
        {
            var enemy = new EnemyMele(positionX, positionY, image,EnemyType.Mele, isActive);
            return enemy;
        }
        
        public static EnemySmart CreateEnemySmart(Vector2 position, string image, bool isActive = true)
        {
            var enemy = new EnemySmart(position.x,position.y,image,EnemyType.Smart,isActive);
            return enemy;
        }
        public static EnemySmart CreateEnemySmart(int positionX, int positionY, string image, bool isActive = true)
        {
            var enemy = new EnemySmart(positionX, positionY, image,EnemyType.Smart, isActive);
            return enemy;
        }
    }
}
