using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;

    //public DynamicJoystick dynamicJoystick;
    public FloatingJoystick floatingJoystick;
    public Rigidbody rb;
    [SerializeField] Animator anim;
    private PlayerRange playerRange;

    private void Start()
    {
        playerRange = gameObject.GetComponent<PlayerRange>();
    }

    private void Update()
    {
        if (floatingJoystick != null)
        {
            Vector3 direction = Vector3.forward * floatingJoystick.Vertical + Vector3.right * floatingJoystick.Horizontal;
      
            rb.AddForce(direction * speed * Time.fixedDeltaTime, ForceMode.VelocityChange);

        
            rb.velocity = new Vector3(floatingJoystick.Horizontal * speed,transform.position.y, floatingJoystick.Vertical * speed);
       
        
            if (floatingJoystick.Horizontal != 0 || floatingJoystick.Vertical != 0)
            {
                anim.SetBool("isRun", true);

                if (playerRange.enemys.transform.childCount > 0)
                {
                    playerRange.NearestEnemy();
                    if (playerRange.LookAtEnemy())
                    {
                        transform.LookAt(playerRange.NearestEnemy().transform);
                        var boxIndicator = playerRange.NearestEnemy().GetComponent<Target>().NeedBoxIndicator;
                        boxIndicator = true;

                    }
                    else
                    {
                        transform.rotation = Quaternion.LookRotation(rb.velocity);
                        var boxIndicator = playerRange.NearestEnemy().GetComponent<Target>().NeedBoxIndicator;
                        boxIndicator = false;
                     
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