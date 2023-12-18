using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public DynamicJoystick dynamicJoystick;
    public Rigidbody rb;
    [SerializeField] Animator _anim;

    public void FixedUpdate()
    {
        Vector3 direction = Vector3.forward * dynamicJoystick.Vertical + Vector3.right * dynamicJoystick.Horizontal;
        rb.AddForce(direction * speed * Time.fixedDeltaTime, ForceMode.VelocityChange);
    }

    private void Update()
    {
        rb.velocity = new Vector3(dynamicJoystick.Horizontal * speed, rb.velocity.y, dynamicJoystick.Vertical * speed);

        if (dynamicJoystick.Horizontal != 0 || dynamicJoystick.Vertical != 0)
        {
            _anim.SetBool("isRun", true);
            if (gameObject.GetComponentInChildren<RangeControl>().rangeEnemyList.Count > 0)
            {
                var a = gameObject.GetComponentInChildren<RangeControl>().rangeEnemyList;
                foreach (var b in a)
                {
                    //b her eleman
                    // ben ve b arasındaki mesafeyi ölç 
                }
                //alanımdaki yani listenin tüm elemanklarını dön
                //bana en yakın olanı tut

                //ona doğru dön
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