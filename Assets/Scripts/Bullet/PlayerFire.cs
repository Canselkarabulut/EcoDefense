using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine.Utility;
using UnityEngine;

public class PlayerFire : MonoBehaviour
{
    public int prefabIndexToSpawn = 0;
    public float spawnInterval = 2f;
    public GameObject barel;
    public GameObject body;
    private float _timer = 0f;
    public float bulletSpeed;
    public PlayerRange playerRange;
    public GameObject fireEffect;
    private void Update()
    {
        _timer += Time.deltaTime;
        if (_timer >= spawnInterval)
        {
            if (playerRange.enemys.transform.childCount > 0)
            {
                if (playerRange.LookAtEnemy())
                {
                    _timer = 0f;
                    SpawnObject();
                }
                else
                {
                    fireEffect.SetActive(false);
                }
            }
        }
    }

    public void SpawnObject()
    {
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
        fireEffect.SetActive(true);
        StartCoroutine(CheckFireStatus(bullet));
    }

    IEnumerator CheckFireStatus(GameObject bullet)
    {
        yield return new WaitForSeconds(3f);
        ObjectPool.Instance.ReturnObjectToPool(bullet);
        fireEffect.SetActive(false);
    }
}