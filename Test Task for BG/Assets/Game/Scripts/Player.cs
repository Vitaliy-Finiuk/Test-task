using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    [SerializeField] private UnityEvent _eventOnWon;
    [SerializeField] private UnityEvent _eventOnDie;

    private Transform _greenZone;
    private Transform _deathZone;

    private void Start()
    {
        // _deathZone = FindObjectOfType<DeathZone>().gameObject.transform;
        _greenZone = FindObjectOfType<GreenZone>().gameObject.transform;
    }

    private void Update()
    {
        LevelComplete();
        Die();
    }

    private void Die(){
        float distance = Vector3.Distance(transform.position, _deathZone.position);
        if(distance < 1f){
            Destroy(gameObject);
            // _eventOnDie.Invoke();
        } 
    }

    private void LevelComplete(){
        float distance = Vector3.Distance(transform.position, _greenZone.position);
        if(distance < 1f){
            Debug.Log(distance);
            _eventOnWon.Invoke();
        }  
    } 
}
