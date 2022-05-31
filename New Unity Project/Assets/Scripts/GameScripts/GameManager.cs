using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [SerializeField]
    ObjectPooler objectPool;
    public Stats player;

    private void Awake()
    {
        Instance = this;
    }
}
