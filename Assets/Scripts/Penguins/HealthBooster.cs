using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.TextCore;

public class HealthBooster : MonoBehaviour
{
    public GameObject _playerHealthbar;

    public PlayerTrigger playerTrigger;

    // public bool isHealtScale;
    private float _timer;
    public float speed;
    public GameObject player;

    private void Start()
    {
        _playerHealthbar = playerTrigger.healthBar;
    }
    private void Update()
    {
        float distance = Vector3.Distance(transform.position, player.transform.position);
        if (distance < .8f)
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

            else if (_playerHealthbar.transform.localScale.x >= .6f)
            {
                _playerHealthbar.transform.localScale = new Vector3(.6f, .07f, .02f);
            }
        }
        else
        {
            _timer = 0;
        }
    }
}