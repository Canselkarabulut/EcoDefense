using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialHands : MonoBehaviour
{
    public Transform pointA;
    public Transform pointB;
    public float duration = 2f; // Hareket süresi
    public bool isHandDistance=false;
    private void Update()
    {
        if (!isHandDistance)
        {
            transform.position = Vector3.Lerp(transform.position, pointB.transform.position, duration * Time.deltaTime);
            if (Vector3.Distance(transform.position,pointB.transform.position)<=2f)
            {
                isHandDistance = true;
            }
        }
        if (isHandDistance)
        {
            transform.position = Vector3.Lerp(transform.position, pointA.transform.position, duration * Time.deltaTime);
            if (Vector3.Distance(transform.position,pointA.transform.position)<=2f)
            {
                isHandDistance = false;
            }
        }
      
   
    }
}
