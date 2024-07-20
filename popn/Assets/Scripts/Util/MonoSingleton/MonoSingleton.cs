using UnityEngine;

public class MonoSingleton<T> : MonoBehaviour where T : MonoBehaviour
{
    private static T _instance = null;
    public T Instance
    {
        get
        {
            if( _instance == null)
            {
                _instance = (T)FindObjectOfType(typeof(T));
                if(_instance == null)
                {
                    var obj = new GameObject($"{typeof(T)} Singleton");
                    obj.AddComponent<T>();
                    DontDestroyOnLoad(obj);
                }
            }
            return _instance;
        }
    }

    protected virtual void Awake()
    {
        if (_instance != null) Destroy(gameObject);
        else DontDestroyOnLoad(gameObject);
    }
}
