using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public DynamicJoystick dynamicJoystick;
    public Rigidbody rb;

    [SerializeField] Animator _anim;

    // private List<GameObject> listRangeEnemy;
    private PlayerRange playerRange;

    private void Start()
    {
        //    listRangeEnemy = gameObject.GetComponentInChildren<RangeControl>().rangeEnemyList;
        playerRange = gameObject.GetComponent<PlayerRange>();
        _smallestDistance = Mathf.Infinity;
    }

    public void FixedUpdate()
    {
        Vector3 direction = Vector3.forward * dynamicJoystick.Vertical + Vector3.right * dynamicJoystick.Horizontal;
        rb.AddForce(direction * speed * Time.fixedDeltaTime, ForceMode.VelocityChange);
    }

    private float _smallestDistance;
    private float distance;
    private Vector3 enemyPositionY;
    private void Update()
    {
        rb.velocity = new Vector3(dynamicJoystick.Horizontal * speed, rb.velocity.y, dynamicJoystick.Vertical * speed);
        
        if (dynamicJoystick.Horizontal != 0 || dynamicJoystick.Vertical != 0)
        {
            _anim.SetBool("isRun", true);
            
            if (playerRange.enemys.transform.childCount > 0)
            {
                playerRange.NearestEnemy();
                if (playerRange.LookAtEnemy())
                {
                    transform.LookAt(playerRange.NearestEnemy().transform);
                }
                else
                {
                    transform.rotation = Quaternion.LookRotation(rb.velocity);
                }
            }
            else
            {
                transform.rotation = Quaternion.LookRotation(rb.velocity);
            }
        }
        else
        {
            _anim.SetBool("isRun", false);
        }
    }
}