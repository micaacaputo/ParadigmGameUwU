using System.Collections.Generic;

namespace MyGame
{
    public class GenericObjectPool<T> where T : class
    {
        public List<T> activeList = new List<T>();
        public List<T> notActiveList = new List<T>();

        public T GetNotActiveOrNew(T tBasic)
        {
            T newT = null;

            if (notActiveList.Count > 0) 
            { 
                newT = notActiveList[0];
                notActiveList.RemoveAt(0);
            }
            else
            {
                newT = tBasic;
            }
            return newT;
        }

        public void RecycleT (T tParameter)
        {
            activeList.Remove(tParameter);
            notActiveList.Add(tParameter);
        }
    }
}