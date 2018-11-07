using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using UnityEngine;
using System.Collections;

public class RankingPlayer : MonoBehaviour{

    private static RankingPlayer scorePlayer;
    private const int LeaderBoardLenght = 10;

    private void Start(){
        
    }

    private void Update(){
        
    }

    public void SaveHighScore(string name, int score){

        List<Scores> HighScores = new List<Scores>();

        int i = 1;

        while (i <= LeaderBoardLenght && PlayerPrefs.HasKey("HighScore" + i + "score")){
            Scores temp = new Scores();
            temp.score = PlayerPrefs.GetInt("HighScore" + i + "score");
            temp.name = PlayerPrefs.GetString("HighScore" + i + "name");
            HighScores.Add(temp);
            i++;
        }

        if(HighScores.Count == 0){
            Scores scr = new Scores();
            scr.name = name;
            scr.score = score;
            HighScores.Add(scr);
        } else {

            for( i = 1 ; i <= HighScores.Count && i <= LeaderBoardLenght; i++) //Loop for upload all 
            {

                if(score > HighScores [ i - 1].score)
                {
                    Scores scr = new Scores();
                    scr.name = name;
                    scr.score = score;
                    HighScores.Insert(i - 1, scr);
                    break;
                }

                if(i == HighScores.Count && i < LeaderBoardLenght)
                {
                    Scores scr = new Scores();
                    scr.name = name;
                    scr.score = score;
                    HighScores.Add(scr);
                    break;
                }
            }

        }

        //
        i = 1;
        while (i<=LeaderBoardLenght && i <= HighScores.Count){
            PlayerPrefs.SetString("HighScore" + i + "name", HighScores[i - 1].name);
            PlayerPrefs.SetInt("HighScore" + i + "score", HighScores[i - 1].score);
            i++;
        }

    }
}