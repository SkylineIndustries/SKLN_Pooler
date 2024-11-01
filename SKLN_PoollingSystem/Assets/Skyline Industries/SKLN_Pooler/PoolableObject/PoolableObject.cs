using System.Collections;
using System.Collections.Generic;
using SKLN_Pooler.Manager;
using UnityEngine;

namespace SKLN_Pooler.PoolableObject
{
    [RequireComponent(typeof(Collider))]
    public class PoolableObject : MonoBehaviour, IPoolable
    {
        [HideInInspector] public string poolTag;
        
        
        [Tooltip("Despawn mode: Timer - object will despawn after a set time, OnCollision - object will despawn on collision with a tagged object, Manual - object will not despawn automatically and needs to be called to despawn.")]
        public DespawnMode despawnMode;
        
        [Tooltip("Time before object despawns.")]
        public float despawnTime;
        
        [Tooltip("Minimum collision velocity required to despawn object.")]
        public float collisionThreshold = 1f;
        
        [Tooltip("Tags of objects that will cause this object to despawn on collision.")]
        public List<string> tags = new List<string>();
        
        
        private static readonly ILogger Logger = Debug.unityLogger;
        


        private void Start()
        {
            HandleDespawn();
        }

        public void OnSpawn(Vector3 position, Quaternion rotation)
        {
            transform.position = position;
            transform.rotation = rotation;

            gameObject.SetActive(true);
            
            HandleDespawn();
            
        }

        public IEnumerator ReturnToPool()
        {
            if (despawnMode == DespawnMode.Timer) yield return new WaitForSeconds(despawnTime);

            gameObject.SetActive(false);
            if (PoolManager.Instance.poolDictionary.TryGetValue(poolTag, out Queue<GameObject> objectPool))
            {
                objectPool.Enqueue(gameObject);
            }
            else
            {
                Logger.LogWarning("Pool error", $"Pool with tag {poolTag} does not exist.");
            }
        }

        private void OnDisable()
        {
            CancelInvoke();
        }
        
        private void HandleDespawn()
        {
            switch (despawnMode)
            {
                case DespawnMode.Timer:
                    StartCoroutine(ReturnToPool());
                    break;
                case DespawnMode.OnCollision:
                    
                    break;
                case DespawnMode.Manual:
                    break;
            }
        }
        
        private void OnCollisionEnter(Collision collision)
        {
            if (DespawnMode.OnCollision == despawnMode && tags.Contains(collision.gameObject.tag) && collision.relativeVelocity.magnitude > collisionThreshold)
            {
             StartCoroutine(ReturnToPool());   
            }
        }
    }
}
