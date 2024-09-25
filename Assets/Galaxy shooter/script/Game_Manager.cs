using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Game_Manager : MonoBehaviour
{
    public bool _isGameover = true  ;
    private SpawnManager spawnManager;
    [SerializeField]
    private GameObject _pause, startgame,hd1,hd2;
    GameObject menupause;


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R) && _isGameover) 
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        if (Input.GetKeyDown(KeyCode.P)   )
        {   

            _pause.SetActive(true);
            Time.timeScale = 0; 
        }

        if (_isGameover) 
        {
            if(Input.GetKeyDown(KeyCode.Space) ) 
                {
                spawnManager = GameObject.Find("SpawnManager").GetComponent<SpawnManager>();
                if (spawnManager != null) 
                        { 
                            spawnManager.spawn(); 
                        }
                _isGameover=false;
                startgame.SetActive(false);
                hd1.SetActive(false);
                hd2.SetActive(false);

                } 
        }
        
    }
    public void Resume()
    {
        _pause.SetActive(false);
        Time.timeScale = 1;

    }
    public void Load1playerScene()
    {
        SceneManager.LoadScene("1 player");
    }
    public void Load2playerScene()
    {
        SceneManager.LoadScene("2 player");
    }
    public void SetGameOver()
    {
        _isGameover = true;
    }

      
    
}
