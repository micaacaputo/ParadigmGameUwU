namespace MyGame
{
    public interface IInputeable
    {
        float reloadTimer{ get; set;}
        void InputUpdate();
    }
}