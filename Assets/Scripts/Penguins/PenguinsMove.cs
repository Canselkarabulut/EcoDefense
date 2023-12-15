using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PenguinsMove : MonoBehaviour
{
    public GameObject penguinTargets;
    public NavMeshAgent myNavMeshAgent;
    private int _targetCount;
    private int _selectedTargetPointNum;
    private Transform _selectedPointTransform;
    private float _dist;

    private void Start()
    {
        _targetCount = penguinTargets.transform.childCount;
        RandomTarget();
    }
    void Update()
    {
        _dist = Vector3.Distance(transform.position, _selectedPointTransform.position);
    }
    IEnumerator Target()
    {
        yield return new WaitUntil(() => _dist < 0.7f);
        RandomTarget();
    }
    void RandomTarget()
    {
        _selectedTargetPointNum = Random.Range(0, _targetCount);
        _selectedPointTransform = penguinTargets.transform.GetChild(_selectedTargetPointNum);
        SetDestinationPosition();
    }
    void SetDestinationPosition()
    {
        myNavMeshAgent.SetDestination(_selectedPointTransform.position);
        StartCoroutine(Target());
    }
}