using System;
using System.Collections.Generic;

namespace MyGame
{
    public class EnemyMele : Enemy
    {
        protected override void CreateAnimations()
        {
            List<IntPtr> moveEnemy = new List<IntPtr>();
            for (int i = 1; i < 3; i++)
            {
                IntPtr frame = Engine.LoadImage($"assets/Animation/enemies/Mele/{i}.png");
                moveEnemy.Add(frame);
            }
            moveAnimation = new Animation("Idle", moveEnemy, 0.4f, true);
        }

        public EnemyMele(float x, float y, string image, EnemyType enemyType, bool isActive = true) : base(x, y, image, enemyType, isActive)
        {
        }
        
    }
}