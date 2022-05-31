using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnScript : MonoBehaviour
{
    [SerializeField] List<GameObject> m_enemyPrefabs;

    List<Vector3> m_spawnPoints;
    List<GameObject> m_spawnedObjects;

    float m_spawnTimer;
    [SerializeField] float m_spawnRate;
    
    bool m_waveOver = false;
    public bool WaveOver
    {
        get { return m_waveOver; }
        set { m_waveOver = value; }
    }

    int[] m_EnemyCount;
    int m_currentWave;

    // Start is called before the first frame update
    void Start()
    {
        m_spawnPoints = new List<Vector3>();
        m_spawnedObjects = new List<GameObject>();

        for (int i = 0; i < transform.childCount; i++)
        {
            m_spawnPoints.Add(transform.GetChild(i).position);
        }

        m_EnemyCount = transform.parent.GetComponent<WaveManager>().m_enemyCount;
    }

    // Update is called once per frame
    void Update()
    {
        m_spawnTimer += Time.deltaTime;

        Debug.Log(m_currentWave);

        if (m_currentWave < m_EnemyCount.Length)
        {
            if (!m_waveOver)
            {
                if (m_spawnedObjects.Count < m_EnemyCount[m_currentWave])
                {
                    if (m_spawnTimer >= m_spawnRate)
                    {
                        int index = Random.Range(0, m_spawnPoints.Count);
                        int enemyIndex = Random.Range(0, m_enemyPrefabs.Count);

                        if (index < m_spawnPoints.Count && enemyIndex < m_enemyPrefabs.Count)
                        {
                            GameObject temp = Instantiate(m_enemyPrefabs[enemyIndex], m_spawnPoints[index], Quaternion.identity);
                            m_spawnedObjects.Add(temp);
                        }

                        m_spawnTimer = 0.0f;
                    }
                }
            }
        }
    }

    public void ClearEnemies()
    {
        for (int i = 0; i < m_spawnedObjects.Count; i++)
        {
            if (m_spawnedObjects[i])
            {
                Destroy(m_spawnedObjects[i]);
            }
        }

        m_spawnedObjects.Clear();
        m_spawnedObjects = new List<GameObject>();
        m_currentWave++;
    }
}
