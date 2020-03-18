using System;
using UnityEngine;

//  where ?  형식 제한자
//  사용할 때는 항상 템플릿 형식이 있어야 함
public class MonoSingleton<T> : MonoBehaviour
    where T : Component
{
    private static T instance = null;
    public static T Get
    {
        get
        {
            if (instance == null)
            {
                //  스레드의 침입을 방지하기 위해  lock 선언 및 사용
                object _lock = new object();
                lock (_lock)
                {
                    var values = UnityEngine.Object.FindObjectsOfType<T>();
                    if (values.Length > 1)
                    {
                        Debug.LogError("Too many Singleton component!");
                    }
                    else if (values.Length == 1) instance = values[0];
                    else
                    {
                        GameObject g = new GameObject(typeof(T).Name + "Manager");
                        instance = g.AddComponent<T>();
                        DontDestroyOnLoad(g);
                    }
                }
                return instance;
            }

            return instance;
        }
    }


}
