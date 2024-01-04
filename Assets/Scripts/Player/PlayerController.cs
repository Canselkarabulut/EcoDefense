using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;

    public DynamicJoystick dynamicJoystick;
    public Rigidbody rb;
    [SerializeField] Animator anim;
    private PlayerRange playerRange;

    private void Start()
    {
        playerRange = gameObject.GetComponent<PlayerRange>();
    }

    private void Update()
    {
        if (dynamicJoystick != null)
        {
            Vector3 direction = Vector3.forward * dynamicJoystick.Vertical + Vector3.right * dynamicJoystick.Horizontal;
      
            rb.AddForce(direction * speed * Time.fixedDeltaTime, ForceMode.VelocityChange);

        
            rb.velocity = new Vector3(dynamicJoystick.Horizontal * speed,transform.position.y, dynamicJoystick.Vertical * speed);
       
        
            if (dynamicJoystick.Horizontal != 0 || dynamicJoystick.Vertical != 0)
            {
                anim.SetBool("isRun", true);

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
                anim.SetBool("isRun", false);
            }
        }
      
    
    }
}