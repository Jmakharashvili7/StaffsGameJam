using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnScript : MonoBehaviour
{
    [SerializeField] List<GameObject> m_enemies;
    GameObject m_WaveManager;

    List<Vector3> m_spawnPoints;
    List<Vector3> m_spawnedObjects;

    float m_spawnTimer;
    [SerializeField] float m_spawnRate;

    // Start is called before the first frame update
    void Start()
    {
        m_spawnPoints = new List<Vector3>();
        for (int i = 0; i < transform.childCount; i++)
        {
            m_spawnPoints.Add(transform.GetChild(i).position);
        }
    }

    // Update is called once per frame
    void Update()
    {
        m_spawnTimer += Time.deltaTime;
        
        if (m_spawnTimer >= m_spawnRate)
        {
            int index = Random.Range(0, m_spawnPoints.Count);
            int enemyIndex = Random.Range(0, m_enemies.Count);

            Instantiate(m_enemies[enemyIndex], m_spawnPoints[index], Quaternion.identity);
            m_spawnTimer = 0.0f;
        }
    }
}
