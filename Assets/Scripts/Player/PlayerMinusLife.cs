using System.Collections;
using System.Collections.Generic;
using Enum;
using TMPro;
using UnityEngine;

public class PlayerMinusLife : MonoBehaviour
{
    private Transform _camera;

    private void Start()
    {
        _camera = Camera.main.transform;
    }

    void LateUpdate()
    {
        transform.LookAt(transform.position + _camera.forward);
    }
    
    public void PlayerMinusLifeClose()
    {
        transform.gameObject.SetActive(false);
    }
}
