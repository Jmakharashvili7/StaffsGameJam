using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [SerializeField]
    ObjectPooler objectPool;

    private void Awake()
    {
        Instance = this;
    }
}
