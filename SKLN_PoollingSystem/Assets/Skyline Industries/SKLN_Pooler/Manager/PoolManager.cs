using System.Collections.Generic;
using UnityEngine;

namespace SKLN_Pooler.Manager
{
    public class PoolManager : MonoBehaviour
    {
        public static PoolManager Instance;
        private static readonly ILogger Logger = Debug.unityLogger;

        [System.Serializable]
        public class Pool
        {
            [Tooltip("The tag of the pool that will be used to spawn objects.")]
            public string tag;
            
            [Tooltip("If true, the pool will expand if there are no objects left in the pool.")]
            public bool expandable;
            
            [Tooltip("The prefab that will be spawned from the pool.")]
            public GameObject prefab;
            
            [Tooltip("The amount of objects that will be created in the pool. If expandable is true, this is the initial size of the pool.")]
            public int size;
        }

        public List<Pool> pools;
        public Dictionary<string, Queue<GameObject>> poolDictionary;

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }
            else
            {
                Destroy(gameObject);
            }
        }

        private void Start()
        {
            poolDictionary = new Dictionary<string, Queue<GameObject>>();

            foreach (var pool in pools)
            {
                var objectPool = new Queue<GameObject>();

                for (int i = 0; i < pool.size; i++)
                {
                    var obj = Instantiate(pool.prefab);
                    obj.SetActive(false);
                    objectPool.Enqueue(obj);
                }

                poolDictionary.Add(pool.tag, objectPool);
            }
        }

        public GameObject SpawnFromPool(string tag, Vector3 position, Quaternion rotation)
        {
            if (!poolDictionary.ContainsKey(tag))
            {
                Logger.LogWarning("Tag error", $"Pool with tag {tag} does not exist.");
                return null;
            }

            // Check if the pool is empty and if it's expandable
            if (poolDictionary[tag].Count == 0)
            {
                Pool pool = pools.Find(p => p.tag == tag);
                
                if (pool != null && pool.expandable)
                {
                    var obj = Instantiate(pool.prefab);
                    obj.SetActive(false);
                    poolDictionary[tag].Enqueue(obj);
                    Logger.Log("Pool expanded", $"Expanded pool with tag {tag}.");
                }
                else
                {
                    Logger.LogWarning("Pool error", $"Pool with tag {tag} is not expandable or does not exist.");
                    return null;
                }
            }

            GameObject objectToSpawn = poolDictionary[tag].Dequeue();

            PoolableObject.PoolableObject poolableObject = objectToSpawn.GetComponent<PoolableObject.PoolableObject>();
            if (!poolableObject)
            {
                Logger.LogWarning("PoolableObject error",
                    $"Object with tag {tag} does not have a PoolableObject component.");
                return null;
            }

            // Set the tag and call OnSpawn
            poolableObject.poolTag = tag;
            poolableObject.OnSpawn(position, rotation);

            return objectToSpawn;
        }
    }
}
