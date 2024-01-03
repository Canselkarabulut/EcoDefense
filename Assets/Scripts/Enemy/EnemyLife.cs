using System;
using System.Collections;
using System.Collections.Generic;
using Enum;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.AI;

public class EnemyLife : MonoBehaviour
{
    private EnemyLevelStatus _enemyLevelStatus;
    private int _lifeCapacity;
    private int _numberBulletsTouchedi=0;
    public PlayerRange playerRange;
    public GameObject particleEffect;
    public GameObject fireEffect;
    public GameObject dieEffect;

    public Animator enemyAnimator;

    public bool isDie;
    //private ParticleSystem _smokePaticleCount;
    private void Awake()
    {
        _enemyLevelStatus = this.gameObject.GetComponent<EnemyLevelStatus>();
        playerRange = GameObject.Find("Body").GetComponent<PlayerRange>();
    //    _smokePaticleCount = particleEffect.GetComponent<ParticleSystem>();
    }

    private void Start()
    {
       
        if (_enemyLevelStatus.EnemyLevelReturn() == EnemyLevel.Lvl1Enemy)
        {
            _lifeCapacity = 4;
        }
        if (_enemyLevelStatus.EnemyLevelReturn() == EnemyLevel.Lvl2Enemy)
        {
            _lifeCapacity = 6;
        }
        if (_enemyLevelStatus.EnemyLevelReturn() == EnemyLevel.Lvl3Enemy)
        {
            _lifeCapacity = 8;
        }
        if (_enemyLevelStatus.EnemyLevelReturn() == EnemyLevel.Lvl4Enemy)
        {
            _lifeCapacity = 10;
        }

        InitializeStart();

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Bullet bullet))
        {
           
            if (_numberBulletsTouchedi == _lifeCapacity - 2)
            {
                particleEffect.SetActive(false);
                fireEffect.SetActive(true);
            }
            if (_numberBulletsTouchedi == _lifeCapacity-1)
            {
                GetComponent<NavMeshAgent>().enabled = false;
                GetComponent<CapsuleCollider>().enabled = false;
               GetComponent<EnemyMove>().enabled = false;
                GetComponent<EnemyLevelStatus>().enabled = false;
                GetComponent<EnemyLife>().enabled = false;
                GetComponent<EnemyTrigger>().enabled = false;
                enemyAnimator.SetBool("isDie",true);
                StartCoroutine(EnemyDie());
                fireEffect.SetActive(false);
                dieEffect.SetActive(true);
                isDie = true;
            }
            else
            {
                _numberBulletsTouchedi++;
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
        ObjectPool.Instance.ReturnObjectToPool(gameObject);
        //texte ekle ölenleri
       
        InitializeStart();
    }
    
    public void InitializeStart()
    {
        isDie = false;
        _numberBulletsTouchedi = 0;
        playerRange.smallestDistance = Mathf.Infinity;
        playerRange.isEnemyNear = false;
        particleEffect.SetActive(true);
        fireEffect.SetActive(false);
        dieEffect.SetActive(false);
        enemyAnimator.SetBool("isDie",false);
        GetComponent<NavMeshAgent>().enabled = true;
        GetComponent<CapsuleCollider>().enabled = true;
        GetComponent<EnemyMove>().enabled = true;
        GetComponent<EnemyLevelStatus>().enabled = true;
        GetComponent<EnemyLife>().enabled = true;
        GetComponent<EnemyTrigger>().enabled = true;
    }
}
