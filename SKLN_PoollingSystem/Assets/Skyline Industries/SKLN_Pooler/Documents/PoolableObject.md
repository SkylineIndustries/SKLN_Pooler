# PoolableObject

PoolableObject is a class that can be pooled and reused. 
It is used by the Pooler class to manage a pool of objects that can be reused to avoid the overhead of creating 
and destroying objects.


Every object that wants to work with the Pooler system must implement the `IPoolable` interface.
This interface requires the object to have a `ReturnToPool` and `OnSpawn` method that will be called when the object is spawned from the pool.
This method should reset the object to its default state.
There is a base class that is provided with the Pooler system called `PoolableGameObject`.

Without this interface/base class the Pooler system will not be able to reconize the object as a poolable object.
And thus will not be able to pool it.

>***Note:*** The PoolableObject class can be used on not prefab objects. But it is recommended to use it on prefab objects.

## Features
- Reset method that is called when the object is spawned from the pool
- Base class `PoolableGameObject` that implements the `IPoolable` interface
- Allows objects to be pooled and reused
- Avoids the overhead of creating and destroying objects

## Allowed Types
The Pooler system allows you to create pools of any type of gameObject.

## Example Usage for own implementation
```csharp

using UnityEngine;
using SKLN_Pooler.Manager;

public class MyPoolableObject : MonoBehaviour, IPoolable
{
        public IEnumerator ReturnToPool()
        {
            if (despawnMode == DespawnMode.Timer) yield return new WaitForSeconds(1f);

            gameObject.SetActive(false);
            if (PoolManager.Instance.poolDictionary.TryGetValue(poolTag, out Queue<GameObject> objectPool))
            {
                objectPool.Enqueue(gameObject);
            }
            else
            {
                Logger.LogWarning("Pool error", $"Pool with tag {poolTag} does not exist.");
            }
            
            yield break;
        }

        public void OnSpawn(Vector3 position, Quaternion rotation)
        {
            transform.position = position;
            transform.rotation = rotation;

            gameObject.SetActive(true);
            
            HandleDespawn();
            
        }
}
```
This is an example of how you can implement the `IPoolable` interface in your own class.
The `ReturnToPool` method is a coroutine that is called when the object needs to be returned to the pool.
This is method can be used to despawn the object and reset it to its default state.
This method can be called by in the PoolableObject class.
The base class `PoolableGameObject` has 3 ways to call this method: `Despawn`, `DespawnAfterTime` and `Manual`.

The `OnSpawn` method is called when the object is spawned from the pool.
This method is called by the Pooler system and should be used to reset the object to its default state.
>***Note:*** The `OnSpawn` method is called by the Pooler system and should not be called manually.