using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using UnityEngine;
using UnityEngine.UI;


namespace Assets.Scripts
{
    public class ScorePlayer : MonoBehaviour{

        public static int scorePoints;
        Text text;

        void Awake(){
            text = GetComponent<Text>();
            scorePoints = 0;
        }

        void Update(){
            text.text = "Score " + scorePoints;
        }

    }
}
