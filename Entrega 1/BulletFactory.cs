using MyGame.assets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGame
{
    public static class BulletFactory
    {
        public static Bullet CreateBullet(Vector2 position, Vector2 dir)
        {
            var bullet = new Bullet(position,dir);
            return bullet;
        }
        public static List<Bullet> InitialBullets()
        {
            var initialBullets = new List<Bullet>() 
            {
                CreateBullet(new Vector2(0, 0), new Vector2(0, 0)),
                CreateBullet(new Vector2(0, 0), new Vector2(0, 0)),
                CreateBullet(new Vector2(0, 0), new Vector2(0, 0))
            };
            return initialBullets;
        }
    }
}
