using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnScript : MonoBehaviour
{
    [SerializeField] GameObject m_objToSpawn;

    List<Vector3> m_spawnPoints;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < transform.childCount; i++)
        {

        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
