using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSingleton : MonoBehaviour
{
    private static GameSingleton instance = null;
    public static GameSingleton Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<GameSingleton>();
                if (instance == null)
                {
                    GameObject go = new GameObject();
                    go.name = "GameSingleton";
                    instance = go.AddComponent<GameSingleton>();
                    DontDestroyOnLoad(go);
                }
            }
            return instance;
        }
    }

    public float height;
    public MovementManager.Movements movement;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}