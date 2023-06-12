using UnityEngine;

public class MonoSingleton<T> : MonoBehaviour where T : MonoBehaviour
{

    private static T singleton = null;
    public static T Instance
    {
        get
        {
            if (singleton == null)
            {
                singleton = FindObjectOfType(typeof(T)) as T;
            }

            if (singleton == null)
            {
                GameObject obj = new GameObject(typeof(T).ToString());
                singleton = obj.AddComponent(typeof(T)) as T;
            }

            return singleton;
        }
    }

    public static bool IsInstanceExists { get { return (singleton != null); } }

    public virtual void OnDestroy()
    {
        singleton = null;
    }
}

public class MonoSingletonDontDestroyed<T> : MonoBehaviour where T : MonoBehaviour
{
    private static T singleton = null;
    public static T Instance
    {
        get
        {
            if (singleton == null)
            {
                singleton = FindObjectOfType(typeof(T)) as T;

                if (singleton != null)
                    singleton.transform.parent = MonoSingletonGroup.transform;
            }

            if (singleton == null)
            {
                GameObject obj = new GameObject(typeof(T).ToString());
                singleton = obj.AddComponent(typeof(T)) as T;
                singleton.transform.parent = MonoSingletonGroup.transform;
            }

            return singleton;
        }

    }
}

//DonDestory ±×·ì¿ë
public class MonoSingletonGroup
{
    static private GameObject group = null;
    static private string name { get { return "_MonoSingletonGroup"; } }

    static public GameObject gameObject
    {
        get
        {
            if (group == null)
            {
                group = new GameObject(name);
                group.isStatic = true;
                GameObject.DontDestroyOnLoad(group);
            }
            return group;
        }
    }

    static public Transform transform { get { return gameObject.transform; } }
}
