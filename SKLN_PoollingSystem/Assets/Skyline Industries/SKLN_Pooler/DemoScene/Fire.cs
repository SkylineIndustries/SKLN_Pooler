using System;
using SKLN_Pooler.Manager;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public string bulletTag = "Bullet"; // De tag die je in PoolManager hebt ingesteld
    public Transform firePoint; // De positie waar de kogel moet verschijnen
    private Rigidbody rb;

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            GameObject bullet = PoolManager.Instance.SpawnFromPool(bulletTag, firePoint.position, firePoint.rotation);
            bullet.GetComponent<Rigidbody>().linearVelocity = firePoint.forward * 10;
        }
    }
}