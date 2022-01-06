using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefabCreator : MonoBehaviour
{
    [SerializeField] private GameObject _victoryEffect;
    [SerializeField] private Transform _spawn;

    public void VictoryEffect(){
        Instantiate(_victoryEffect, _spawn.position, _spawn.rotation);
    }

}
