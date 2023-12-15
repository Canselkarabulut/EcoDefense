using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMove : MonoBehaviour
{
    public Transform player;
    public NavMeshAgent myNavMeshAgent;
    void Update()
    {
        SetDestinationPosition();
    }
    void SetDestinationPosition()
    {
        myNavMeshAgent.SetDestination(player.position);
    }
}
