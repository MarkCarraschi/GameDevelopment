using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Assets.Scripts;

public class Menu : MonoBehaviour {

    InputField name;
    ScorePlayer sc = new ScorePlayer();

    public void PlayGame(){
        SceneManager.LoadScene(3);
        Time.timeScale = 1f;
    }

    public void QuitGame(){
        Application.Quit();
    }
    
    public void PlayerRanking(){
        SceneManager.LoadScene(5);
        Time.timeScale = 1f;
    }

    public void ReturnToMenu(){
        SceneManager.LoadScene(0);
        Time.timeScale = 1f;
    }

    public void setDefault(){
        sc.setScore();

    }
}
