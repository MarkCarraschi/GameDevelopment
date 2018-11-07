using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Scores{
    public int score;
    public string name;
}

public class MenuGUI : MonoBehaviour{

    string name = "";
    string score = "";
    List<Scores> highScore;

    void Start(){
        highScore = new List<Scores>();
    }
        
    void Update(){

    }

    void ButtonClicked(GameObject obj){
        print("OBJECT NAME: " + obj);
    }

}
