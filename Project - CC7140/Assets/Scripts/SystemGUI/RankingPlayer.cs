using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class RankingPlayer : MonoBehaviour{

    public Text scoreText;
    public Text playerText;

    public void Start(){
        scoreText.text = PlayerPrefs.GetInt("HighScore", 0).ToString();
        playerText.text = "Player";
    }

    public void EndScore(string name, int values){

        if (values > PlayerPrefs.GetInt("HighScore", 0))
        {
            PlayerPrefs.SetInt("HighScore", values);
            scoreText.text = values.ToString();
            playerText.text = name;
        }

    }

}