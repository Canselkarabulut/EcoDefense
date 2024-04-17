using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public FloatingJoystick floatingJoystick;

    [SerializeField]public Animator anim;
    private PlayerRange playerRange;
    public AudioSource walkSound;

    private void Start()
    {
        playerRange = gameObject.GetComponent<PlayerRange>();
    }

    private void Update()
    {
        if (floatingJoystick != null)
        {
            Vector3 direction = Vector3.forward * floatingJoystick.Vertical +
                                Vector3.right * floatingJoystick.Horizontal;
            transform.Translate(direction * speed * Time.deltaTime, Space.World);
            if (floatingJoystick.Horizontal != 0 || floatingJoystick.Vertical != 0)
            {
                anim.SetBool("isRun", true);
                if (walkSound.enabled && !walkSound.isPlaying)
                {
                    walkSound.Play();
                }

                if (playerRange.enemys.transform.childCount > 0)
                {
                    playerRange.NearestEnemy();
                    if (playerRange.LookAtEnemy())
                    {
                        transform.LookAt(playerRange.NearestEnemy().transform);
                    }
                    else
                    {
                        transform.rotation = Quaternion.LookRotation(direction);
                    }
                }
                else
                {
                    transform.rotation = Quaternion.LookRotation(direction);
                }
            }
            else
            {
                anim.SetBool("isRun", false);
                if (walkSound.enabled)
                {
                    walkSound.Stop();
                }

                if (playerRange.enemys.transform.childCount > 0)
                {
                    playerRange.NearestEnemy();
                    if (playerRange.LookAtEnemy())
                    {
                        transform.LookAt(playerRange.NearestEnemy().transform);
                    }
                }
            }
        }
    }
}
