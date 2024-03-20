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
    public AudioSource bulletSound;
    private bool isRange;
    private GameObject narestEnemy;

    private void FixedUpdate()
    {
        _timer += Time.deltaTime;

        if (playerRange.enemys.transform.childCount > 0)
        {
            narestEnemy = playerRange.NearestEnemy();
            isRange = playerRange.LookAtEnemy();
        }

        if (_timer >= spawnInterval)
        {
            _timer = 0f;
            if (playerRange.enemys.transform.childCount > 0)
            {
                if (isRange && !playerRange.GetComponentInChildren<PlayerTrigger>().isDie &&
                    !narestEnemy.GetComponent<EnemyLife>().isDie)
                {
                    SpawnObject();
                }
                else
                {
                    fireEffect.SetActive(false);
                    if (bulletSound.enabled)
                       bulletSound.Stop();
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
            bullet.GameObject().SetActive(true);
        }

        fireEffect.SetActive(true);
        if (bulletSound.enabled)
            bulletSound.Play();
        StartCoroutine(CheckFireStatus(bullet));
    }

    IEnumerator CheckFireStatus(GameObject bullet)
    {
        yield return new WaitForSeconds(3f);
        transform.position = Vector3.zero;
        transform.rotation = Quaternion.identity;
        Rigidbody bulletRigidbody = bullet.GetComponent<Rigidbody>();
        bulletRigidbody.velocity = Vector3.zero;
      //  ObjectPool.Instance.ReturnObjectToPool(bullet);
        fireEffect.SetActive(false);
    }
}