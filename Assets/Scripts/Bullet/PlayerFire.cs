using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine.Utility;
using Enum;
using Unity.VisualScripting;
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

    private void FixedUpdate()
    {
        _timer += Time.deltaTime;
        if (_timer >= spawnInterval)
        {
            if (playerRange.enemys.transform.childCount > 0)
            {
                if (playerRange.LookAtEnemy() && !playerRange.GetComponentInChildren<PlayerTrigger>().isDie)
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

    public GameObject bullet;

    public void SpawnObject()
    {
        bullet =
            ObjectPool.Instance.GetObjectFromPool(prefabIndexToSpawn); //hangi prefabın spawnlanacağı index
        if (bullet != null && barel != null)
        {
            //   bullet.transform.SetParent(parentSpawnObject);
            bullet.transform.position = barel.transform.position;
            bullet.transform.rotation = body.transform.rotation;
            //   Rigidbody bulletRigidbody = bullet.GetComponent<Rigidbody>();
            //     bulletRigidbody.velocity = barel.transform.forward * bulletSpeed;
           // bullet.transform.position = transform.forward * bulletSpeed;
          //  bullet.transform.Translate(Vector3.forward * bulletSpeed * Time.deltaTime);
            bullet.GameObject().SetActive(true);
        }

        fireEffect.SetActive(true);
        StartCoroutine(CheckFireStatus(bullet));
    }

    IEnumerator CheckFireStatus(GameObject bullet)
    {
        yield return new WaitForSeconds(3f);
        transform.position = Vector3.zero;
        transform.rotation = Quaternion.identity;
        Rigidbody bulletRigidbody = bullet.GetComponent<Rigidbody>();
        bulletRigidbody.velocity = Vector3.zero;
        ObjectPool.Instance.ReturnObjectToPool(bullet);
        fireEffect.SetActive(false);
    }
}