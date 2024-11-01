using System.Collections;
using System.Collections.Generic;
using SKLN_Pooler.Manager;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public string enemyTag = "Enemy";
    
    void Start()
    {
        StartCoroutine(SpawnEnemy());
    }
    
    IEnumerator SpawnEnemy()
    {
        while (true)
        {
            yield return new WaitForSeconds(5);
            GameObject enemy = PoolManager.Instance.SpawnFromPool(enemyTag, new Vector3(Random.Range(-5, 5), 1, Random.Range(-5, 5)), Quaternion.identity);
            enemy.GetComponent<Rigidbody>().linearVelocity = new Vector3(Random.Range(-1, 1), 0, Random.Range(-1, 1)) * 2;
        }
    }
    
}
