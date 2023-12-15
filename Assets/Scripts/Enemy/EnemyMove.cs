using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMove : MonoBehaviour
{
    private Transform _player;
    private NavMeshAgent myNavMeshAgent;

    private void Awake()
    {
        _player = GameObject.Find("Body").transform;
        myNavMeshAgent = GetComponent<NavMeshAgent>();
    }
    void Update()
    {
        SetDestinationPosition();
    }
    void SetDestinationPosition()
    {
        myNavMeshAgent.SetDestination(_player.position);
    }
}
