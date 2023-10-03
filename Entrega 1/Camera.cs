using MyGame.assets;

namespace MyGame
{
    public class Camera
    {
        public Vector2 Position { get; set; }
        public Vector2 Velocity { get; set; }
        public Vector2 Aceleration { get; set; }

        public void Update()
        {
            var objective = Physics.Res(WaveController.CharacterList[0].Position,
                new Vector2(0.5f * 1360, 0.5f * 768));
            var velCamera = Physics.Res(objective, Position);
            velCamera = Physics.Mul(velCamera, 5);
            Velocity = velCamera;
            Physics.PhysicsCalculate(this);
        }
    }
}