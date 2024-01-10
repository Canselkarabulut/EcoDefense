using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class HealthBooster : MonoBehaviour
{
    public GameObject _playerHealthbar;
    public PlayerTrigger playerTrigger;
   // public bool isHealtScale;
    private float _timer;
    public float speed;

    private void Start()
    {
        _playerHealthbar = playerTrigger.healthBar;
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.TryGetComponent(out PlayerController playerController))
        {
            _timer += Time.deltaTime;
            if (_playerHealthbar.transform.localScale.x < .6f)
            {
                _playerHealthbar.transform.localScale += new Vector3(_timer * speed, 0, 0);

                _playerHealthbar.GetComponent<Renderer>().material = playerTrigger.healthbarGreen;
                if (_playerHealthbar.transform.localScale.x < .35)
                {
                    _playerHealthbar.GetComponent<Renderer>().material = playerTrigger.healthbarOrange;
                    if (_playerHealthbar.transform.localScale.x < .2)
                    {
                        _playerHealthbar.GetComponent<Renderer>().material = playerTrigger.healthbarRed;
                    }
                }
            }
        }
    }
}