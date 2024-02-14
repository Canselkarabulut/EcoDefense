using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class HealthbarWiev : MonoBehaviour
{
    // ReSharper disable once InconsistentNaming
    private Transform _camera;
    private void Start()
    {
        _camera = Camera.main.transform;
    }

    void LateUpdate()
    {
        transform.LookAt(transform.position + _camera.forward);
        if (transform.localScale.x < .2f)
        {
            PlayerTrigger.isHealthRed = true;
        }
        else
        {
            PlayerTrigger.isHealthRed = false;
        }
    }
    
}
