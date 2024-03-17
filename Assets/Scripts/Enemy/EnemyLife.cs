using System;
using System.Collections;
using System.Collections.Generic;
using Enum;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class EnemyLife : MonoBehaviour
{
    private EnemyLevelStatus _enemyLevelStatus;

    private int _lifeCapacity;

    // private int _numberBulletsHit=0; //isabet eden mermi sayısı
    public PlayerRange playerRange;
    public GameObject fireEffect;
    public GameObject dieEffect;
    public GameObject coin;
    public Animator enemyAnimator;
    public bool isDie;
    public GameObject heart;

    public EnemyTrigger enemyTrigger;


    public AudioSource enemyBorn;
    public AudioSource enemyCoin;
    public AudioSource enemyTriggerBullet;
    public AudioSource enemyWalk;

    //  public AudioSource enemySound;
    private void Awake()
    {
        _enemyLevelStatus = this.gameObject.GetComponent<EnemyLevelStatus>();
        playerRange = GameObject.Find("Body").GetComponent<PlayerRange>();
    }

    private void Start()
    {
        InitializeStart();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Bullet bullet))
        {
            _lifeCapacity += enemyTrigger.numberLivesLost;

            var fireEffectCount = _lifeCapacity + (enemyTrigger.numberLivesLost + enemyTrigger.numberLivesLost);
            if (fireEffectCount < 1)
            {
                fireEffect.SetActive(true); //kafanın üstünde ölümünün habercisi olan ateş
            }

            if (_lifeCapacity < 1) // yaşam kapasitesi bittiyse
            {
                GetComponent<CapsuleCollider>().enabled = false;
                GetComponent<NavMeshAgent>().enabled = false;
                GetComponent<EnemyMove>().enabled = false;
                GetComponent<EnemyLevelStatus>().enabled = false;
                GetComponent<EnemyLife>().enabled = false;
                GetComponent<EnemyTrigger>().enabled = false;
                enemyAnimator.SetBool("isDie", true);
                if (enemyTriggerBullet.enabled)
                    enemyTriggerBullet.enabled = false;
                //  enemySound.Stop();
                fireEffect.SetActive(false);
                dieEffect.SetActive(true);
                isDie = true;
                coin.SetActive(true);
                StartCoroutine(EnemyDie());
            }
        }
    }


    IEnumerator EnemyDie()
    {
        yield return new WaitForSeconds(3);
        DieAnimEnd();
    }

    public void DieAnimEnd()
    {
        if (PlayerTrigger.isHealthRed)
        {
            Instantiate(heart, transform.position, transform.rotation);
        }

        ObjectPool.Instance.ReturnObjectToPool(gameObject);
        InitializeStart();
    }


    public void InitializeStart()
    {
        isDie = false;
        //  _numberBulletsHit = 0;
        playerRange.smallestDistance = Mathf.Infinity;
        playerRange.isEnemyNear = false;
//        particleEffect.SetActive(true);
        fireEffect.SetActive(false);
        dieEffect.SetActive(false);
        enemyAnimator.SetBool("isDie", false);
        GetComponent<CapsuleCollider>().enabled = true;
        GetComponent<NavMeshAgent>().enabled = true;
        GetComponent<EnemyMove>().enabled = true;
        GetComponent<EnemyLevelStatus>().enabled = true;
        GetComponent<EnemyLife>().enabled = true;
        GetComponent<EnemyTrigger>().enabled = true;

        if (enemyBorn != null && enemyCoin != null && enemyTriggerBullet != null && enemyWalk != null)
        {
            if (PlayerPrefs.GetInt("soundNum") == 1)
            {
                enemyBorn.enabled = true;
                enemyCoin.enabled = true;
                enemyTriggerBullet.enabled = true;
                enemyWalk.enabled = true;
            }
            else if (PlayerPrefs.GetInt("soundNum") == 0)
            {
                enemyBorn.enabled = false;
                enemyCoin.enabled = false;
                enemyTriggerBullet.enabled = false;
                enemyWalk.enabled = false;
            }
        }

        if (enemyWalk != null)
            enemyWalk.Play();
        coin.SetActive(false);

        if (_enemyLevelStatus.EnemyLevelReturn() == EnemyLevel.Lvl1Enemy)
        {
            _lifeCapacity = 8;
        }

        if (_enemyLevelStatus.EnemyLevelReturn() == EnemyLevel.Lvl2Enemy)
        {
            _lifeCapacity = 24;
        }

        if (_enemyLevelStatus.EnemyLevelReturn() == EnemyLevel.Lvl3Enemy)
        {
            _lifeCapacity = 48;
        }

        if (_enemyLevelStatus.EnemyLevelReturn() == EnemyLevel.Lvl4Enemy)
        {
            _lifeCapacity = 80;
        }
    }
}