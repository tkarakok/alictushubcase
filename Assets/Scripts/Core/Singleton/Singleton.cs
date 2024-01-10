using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
    static T m_Instance;
    public static T Instance {
        get {
            if (m_Instance == null) 
            {
                m_Instance = FindObjectOfType<T>();
            }
            return m_Instance;
        }
    }
}
