using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour
{
    public Dictionary<string, Queue<GameObject>> dictionary;

    [System.Serializable]
    public class Pool
    {
        public GameObject parent;
        public string tag;
        public GameObject prefab;
        public int size;
    }

    public List<Pool> pools;
    void Start()
    {
        dictionary = new Dictionary<string, Queue<GameObject>>();

        foreach (Pool pool in pools)
        {
            Queue<GameObject> objPool = new Queue<GameObject>();

            for (int i = 0; i < pool.size; i++)
            {
                GameObject obj = Instantiate(pool.prefab);
                obj.transform.SetParent(pool.parent.transform, false);
                obj.SetActive(false);
                objPool.Enqueue(obj);
            }

            dictionary.Add(pool.tag, objPool);
        }
    }

    public GameObject GetEnemy(string tag, Vector3 position, Quaternion rotation)
    {
        if (!dictionary.ContainsKey(tag))
        {
            Debug.LogError("Tag not found " + tag);
            return null;
        }
        GameObject temp = dictionary[tag].Dequeue();
        temp.SetActive(true);
        temp.transform.position = position;
        transform.transform.rotation = rotation;

        dictionary[tag].Enqueue(temp);

        return temp;
    }
}
