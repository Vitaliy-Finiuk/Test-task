using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerMover : MonoBehaviour
{
    private Transform _target;
    private NavMeshAgent _navMeshAgent;
    private void Start() {
        _navMeshAgent =  GetComponent<NavMeshAgent>();
        _target = FindObjectOfType<GreenZone>().gameObject.transform;
    }
    private void Update()
    {
        Movement();
    }

    private void Movement(){
        _navMeshAgent.destination = _target.position;
    }
}
