using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public PoolManager poolManager;
    public PlayerMove playerMove;
    public bool leftBlock = false;
    public bool rightBlock = false;

    // Start is called before the first frame update
    void Awake()
    {
        if (null == instance)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
