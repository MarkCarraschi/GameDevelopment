using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;
using Assets.Scripts;
using UnityEngine.SceneManagement;

namespace Assets.Scripts
{
    public class PlayerHealth : MonoBehaviour{

        public static int health = 3; // Initial life
        public int numOfHearts;

        public Image[] hearts;
        public Sprite fullHeart;
        public Sprite emptyHeart;

        RankingPlayer scrPlayer = new RankingPlayer();

        private void Awake(){
            health = 3;
        }

        private void Update(){

            if (health > numOfHearts) health = numOfHearts;

            for (int i = 0; i < hearts.Length; i++){

                if (i < health) hearts[i].sprite = fullHeart;
                else hearts[i].sprite = emptyHeart;

                if (i < numOfHearts) hearts[i].enabled = true;
                else hearts[i].enabled = false;
            }           
            
            if(health == 0){
                scrPlayer.SaveHighScore("NAME",1);
                SceneManager.LoadScene(2);
            }
        }

        public void setHealthDamage(int damage){
            health = health - damage;
        }

    }
}
