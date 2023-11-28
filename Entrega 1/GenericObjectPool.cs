using System.Collections.Generic;

namespace MyGame
{
    public class GenericObjectPool<T> where T : class
    {
        public List<T> allList = new List<T>();
    }
}