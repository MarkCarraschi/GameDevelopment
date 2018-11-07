using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour {

    InputField name;

    public void PlayGame(){
        SceneManager.LoadScene(3);
        Time.timeScale = 1f;
    }

    public void QuitGame(){
        //Debug.Log("Finalizou");
        Application.Quit();
    }
    
    public void PlayerLoad(){
        //name = GetComponent<InputField>();
        //Ranking.nomeNPlayer = name.text;
    }

    public void ReturnToMenu(){
        SceneManager.LoadScene(0);
        Time.timeScale = 1f;
    }
}
