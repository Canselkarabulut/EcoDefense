using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine.Utility;
using UnityEngine;

public class PlayerFire : MonoBehaviour
{
    public int prefabIndexToSpawn = 0;
    public Transform parentSpawnObject;
    public float spawnInterval = 2f;
    public GameObject barel;
    public GameObject body;
    private float _timer = 0f;
    public float bulletSpeed;
 

    private void Update()
    {
        _timer += Time.deltaTime;
        if (_timer >= spawnInterval)
        {
            _timer = 0f;
            SpawnObject();
        }
    }

    public void SpawnObject()
    {
        //ateş namlunun ucunda oluşup forward yönüne gideccek
        GameObject bullet =
            ObjectPool.Instance.GetObjectFromPool(prefabIndexToSpawn); //hangi prefabın spawnlanacağı index
        if (bullet != null && barel != null)
        {
            //   bullet.transform.SetParent(parentSpawnObject);
            bullet.transform.position = barel.transform.position;
            bullet.transform.rotation = body.transform.rotation;
            Rigidbody bulletRigidbody = bullet.GetComponent<Rigidbody>();
            bulletRigidbody.velocity = barel.transform.forward * bulletSpeed;
        }
        StartCoroutine(CheckFireStatus(bullet));
    }

    IEnumerator CheckFireStatus(GameObject bullet)
    {
        yield return new WaitForSeconds(5f);
        ObjectPool.Instance.ReturnObjectToPool(bullet);
    }
}