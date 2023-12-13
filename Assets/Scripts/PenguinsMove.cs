using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PenguinsMove : MonoBehaviour
{
    public float speed=5;
    void Update()
    {
        transform.position += new Vector3(0, 0, 1*Time.deltaTime*speed);
    }
}
