
using System.Collections;
using UnityEngine;

namespace SKLN_Pooler.PoolableObject
{
    public interface IPoolable
    {
        void OnSpawn(Vector3 position, Quaternion rotation);
        IEnumerator ReturnToPool();
    }
}