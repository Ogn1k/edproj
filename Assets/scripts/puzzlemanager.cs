using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class puzzlemanager : MonoBehaviour
{
    [System.Serializable]
    public class Pool
    {
        public string tag;
        public GameObject prefab;
        public int size;
    }

    public List<Pool> pools;
    public Dictionary<string, Queue<GameObject>> poolDictionary;

   // public int amount = 1;
    //public int distance =  1;
    // Start is called before the first frame update
    void Start()
    {
        poolDictionary = new Dictionary<string, Queue<GameObject>>();

        foreach (Pool pool in pools)
        {
            Queue<GameObject> objectPool = new Queue<GameObject>();
            for (int i = 0; i < pool.size; i++)
            {
                GameObject obj = Instantiate(pool.prefab);
                obj.SetActive(false);
                objectPool.Enqueue(obj);
            }

            poolDictionary.Add(pool.tag, objectPool);
        }
    }

    // Update is called once per frame
    void Update()
        {
        
    }
    private void FixedUpdate()
    {

    }

    public void SpawnFromPool(string tag, Vector3 pos, Quaternion rotation)
    {
        GameObject objectToSpawn = poolDictionary[tag].Dequeue();
    }
}
