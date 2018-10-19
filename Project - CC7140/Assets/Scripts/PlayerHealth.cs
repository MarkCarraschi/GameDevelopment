﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using UnityEngine;
using UnityEngine.UI;
using System.Collections;

namespace Assets.Scripts
{
    class PlayerHealth : MonoBehaviour{

        public static int health = 3; // Initial life
        public int numOfHearts;

        public Image[] hearts;
        public Sprite fullHeart;
        public Sprite emptyHeart;

        private void OnTriggerEnter2D(Collider2D collision){
            if (collision.tag == "spike_c")
                Debug.Log("FODASSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSE");
        }

        private void Start(){
                        
        }

        private void Update(){

            if (health > numOfHearts) health = numOfHearts;

            for (int i = 0; i < hearts.Length; i++){

                if (i < health) hearts[i].sprite = fullHeart;
                else hearts[i].sprite = emptyHeart;

                if (i < numOfHearts) hearts[i].enabled = true;
                else hearts[i].enabled = false;
            }              
        }
    }
}
