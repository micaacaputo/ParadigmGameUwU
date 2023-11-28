using MyGame.assets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGame
{
    public abstract class Enemy : GameObject
    {
        public float timer { get; set; }
        public bool isActive { get; set; }
        public EnemyType EnemyType{ get; }
        public Renderer Renderer{ get; }
        public ICollider Collider{ get; private set; }
        public Animation currentAnimation{ get; }
        protected Animation moveAnimation{ get; set; }
        public Enemy(float x, float y, string image,EnemyType enemyType, bool isActive = true)
        {
            Position = new Vector2(x, y);

            radius = 43;
            width = 86;
            height = 86;
            timer = 1;
            mass = 1;
            this.isActive = isActive;
            EnemyType = enemyType;
            Renderer = new Renderer();
            CreateAnimations();
            currentAnimation = moveAnimation;
        }
        protected virtual void CreateAnimations()
        {
            List<IntPtr> moveEnemy = new List<IntPtr>();
            for (int i = 1; i < 3; i++)
            {
                IntPtr frame = Engine.LoadImage($"assets/Animation/enemies/Mele/{i}.png");
                moveEnemy.Add(frame);
            }
            moveAnimation = new Animation("Idle", moveEnemy, 0.4f, true);

        }
        public virtual void Update()
        {
            currentAnimation.Update();
            timer += Program.DeltaTime;
        }
        public void AssignDependencies(ICollider newCollider)
        {
            Collider = newCollider;
            Collider.AssignProps(width,height,radius);
            
        }
    }

    public enum EnemyType
    {
        Mele,
        Smart
    }
}
