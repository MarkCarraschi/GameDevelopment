using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

namespace Assets.Scripts
{
    class SpawnCoins : MonoBehaviour{

        //Declare components
        public Transform[] coinSpawns;
        public GameObject coin;

        void Start(){
            Spawn();
        }

        //Generate coins
        void Spawn(){

            for(int i = 0; i < coinSpawns.Length; i++){
                int coinFlip = UnityEngine.Random.Range(0, 2);
                    if(coinFlip > 0){
                        Instantiate(coin, coinSpawns[i].position, Quaternion.identity);
                    }
            }
    
        }

    }
}
