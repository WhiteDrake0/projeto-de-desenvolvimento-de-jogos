using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoBehaviour {
    
    [System.Serializable]
    public class Pool
    {
        public string tag;
        public GameObject prefab;
        public int size;
    }


    public List<Pool> pools;
    public Dictionary<string, Queue<GameObject>> poolDictionary;

    // Use this for initialization
    void Start () {
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


        StartCoroutine(StartSpawn("obst"));
    }
	
	
    public GameObject SpawnFromPool(string tag, Vector3 position, Quaternion rotation)
    {
        if (!poolDictionary.ContainsKey(tag))
        {
            Debug.LogWarning("Pool with tag" + tag + "doesn't exist");
            return null;
        }

        GameObject objectToSpawn = poolDictionary[tag].Dequeue();

        objectToSpawn.SetActive(true);
        objectToSpawn.transform.position = position;

        poolDictionary[tag].Enqueue(objectToSpawn);

        return objectToSpawn;
    }

    private IEnumerator StartSpawn(string _tag)
    {
        yield return new WaitForSeconds(6f);
        while (true)
        {
            yield return new WaitForSeconds(2f);
            float randomY = 3, randomZ = 3;

            var randomPos = Random.Range(1, 4);

            if (randomPos == 1)
            {
                randomY = -0.2f;
                randomZ = -0.1f;
            }
            else if (randomPos == 2)
            {
                randomY = -1.2f;
                randomZ = -1.1f;
            }
            else if (randomPos == 3)
            {
                randomY = -2.2f;
                randomZ = -2.1f;
            }

            var obsPosition = new Vector3(13, randomY, randomZ);

            SpawnFromPool(_tag, obsPosition, Quaternion.Euler(Vector3.zero));
        }

    
    }
}
