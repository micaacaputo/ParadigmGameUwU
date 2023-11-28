namespace MyGame
{
    public interface IInputeable
    {
        float reloadTimer{ get; }
        void InputUpdate();
    }
}