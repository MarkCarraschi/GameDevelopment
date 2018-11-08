using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour {

    public InputField name;
    PlayerController pc = new PlayerController();

    public void PlayGame(){
        string namePlayer = name.text.ToString();
        pc.namePerson = namePlayer;
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
}
