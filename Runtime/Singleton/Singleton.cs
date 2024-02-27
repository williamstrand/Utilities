using UnityEngine;

namespace Utilities.Singleton
{
    public class Singleton<T> where T : MonoBehaviour
    {
        static T instance;
        
        public static T Instance
        {
            get
            {
                if (instance != null) return instance;
                
                instance = Object.FindObjectOfType<T>();
                
                if (instance != null) return instance;
                
                instance = new GameObject(typeof(T).Name).AddComponent<T>();
                return instance;
            }
        }
    }
}