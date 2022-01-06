using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    
    [SerializeField] private bool _pauseGame;
    [SerializeField] private GameObject _pauseGameMenu; 


    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape)){

        if (_pauseGame)
        {
            Resume();
        }else
        {
            Pause();
        }
        }
    }


    public void Resume(){
        _pauseGameMenu.SetActive(false);
        Time.timeScale = 1f;
        _pauseGame = false;
    }

    public void Pause(){
        _pauseGameMenu.SetActive(true);
        Time.timeScale = 0f;
        _pauseGame = true;
    }
}
