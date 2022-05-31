using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
    [SerializeField] public int[] m_enemyCount;
    [SerializeField] public float[] m_waveDuration;
    [SerializeField] GameObject m_Elite;
    [SerializeField] GameObject m_MiniBoss;
    [SerializeField] GameObject m_Boss;

    int m_currentWave = 0;
    float m_currentWaveTimer = 0;
    Vector3 m_bossSpawn;
    bool m_waveBossSpawned = false;

    // Start is called before the first frame update
    void Start()
    {
        m_bossSpawn = GameObject.Find("BossSpawn").transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        m_currentWaveTimer += Time.deltaTime;

        Debug.Log(m_currentWave);

        if (m_currentWave < m_waveDuration.Length)
        {
            if (m_currentWaveTimer >= m_waveDuration[m_currentWave])
            {
                m_currentWave++;

                for (int i = 0; i < transform.childCount; i++)
                {
                    transform.GetChild(i).GetComponent<SpawnScript>().ClearEnemies();
                    m_waveBossSpawned = false;
                }

                m_currentWaveTimer = 0.0f;
            }

            if (m_currentWaveTimer >= m_waveDuration[m_currentWave]/2)
            {
                if (m_currentWave == 2 && !m_waveBossSpawned)
                {
                    Instantiate(m_Elite, m_bossSpawn, Quaternion.identity);
                    m_waveBossSpawned = true;
                }
                else if (m_currentWave == 3 && !m_waveBossSpawned)
                {
                    Instantiate(m_MiniBoss, m_bossSpawn, Quaternion.identity);
                    m_waveBossSpawned = true;
                }
                else if (m_currentWave == 4 && !m_waveBossSpawned)
                {
                    Instantiate(m_Boss, m_bossSpawn, Quaternion.identity);
                    m_waveBossSpawned = true;
                }
            }
        }
    }
}
