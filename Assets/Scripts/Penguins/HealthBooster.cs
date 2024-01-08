using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBooster : MonoBehaviour
{
    public GameObject _playerHealthbar;
    public PlayerTrigger playerTrigger;
    private bool isHealtScale;
    private float _timer;
    public float speed;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out PlayerController playerController))
        {
            _playerHealthbar = playerController.GetComponentInChildren<PlayerTrigger>().healthBar;
            isHealtScale = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent(out PlayerController playerController))
        {
            isHealtScale = false;
        }
    }

    private void Update()
    {
        _timer += Time.deltaTime;

        if (isHealtScale)
        {
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