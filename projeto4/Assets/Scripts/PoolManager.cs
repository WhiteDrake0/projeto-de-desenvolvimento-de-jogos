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

    //Variaveis do tamanho da camera
    private float pos;
    private float width;

    // Use this for initialization
    void Start () {

        //Determinar a largura da camara
        Camera cam = Camera.main;
        float height = 2f * cam.orthographicSize;
        width = height * cam.aspect;

        //Determinar a largura do background e do paceio/estrada
        float Wbg = width * 0.71f;
        float Wstreet = Wbg * 0.4f;
        pos = (Wstreet / 3) / 2;

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
            Debug.LogWarning("Pool with tag " + tag + " doesn't exist");
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
        yield return new WaitForSeconds(1f);
        while (true)
        {
            yield return new WaitForSeconds(2f);
            float randomY = 3, randomZ = 3;

            var randomPos = Random.Range(1, 4);

            if (randomPos == 1)
            {
                randomY = -1f;
                randomZ = -1f;
            }
            else if (randomPos == 2)
            {
                randomY = -1f - pos;
                randomZ = -1f - pos;
            }
            else if (randomPos == 3)
            {
                randomY = -1f - pos*2;
                randomZ = -1f - pos * 2;
            }

            var obsPosition = new Vector3(width, randomY, randomZ);

            SpawnFromPool(_tag, obsPosition, Quaternion.Euler(Vector3.zero));
        }

    
    }
}
