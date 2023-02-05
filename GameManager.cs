using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private bool _isGameOver = false;

    public void GameOver()
    {
        _isGameOver = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(_isGameOver && Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene(0);
        }
    }
}
