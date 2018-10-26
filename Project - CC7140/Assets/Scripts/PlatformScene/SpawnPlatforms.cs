using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using UnityEngine;


    /// <summary>
    /// This code will be generate a stage of game
    /// </summary>

namespace Assets.Scripts.ObjectsScene
{
    class SpawnPlatforms : MonoBehaviour{

        public int maxPlatform = 20;

        public GameObject platform;
        public GameObject DogAndPlatform;

        public float horizontalMin = 7.5f;
        public float horizontalMax = 2f;
        public float verticalMin = 6f;
        public float verticalMax = 6;

        private Vector3 originPosition;


        void Start(){
            originPosition = transform.position;
            Spawn();
        }

        void Spawn(){
            for(int i = 0; i < maxPlatform; i++){
                //Vector3 randomPosition = originPosition +
                //    new Vector3(UnityEngine.Random.Range(horizontalMin, horizontalMax),
                //                UnityEngine.Random.Range(verticalMin, verticalMax),10);
                //Instantiate(platform, randomPosition, Quaternion.identity);

                if( i % 3 == 0  ){

                    Vector3 randomPosition = originPosition +
                    new Vector3(UnityEngine.Random.Range(horizontalMin, horizontalMax),
                                0, 0);
                    Instantiate(DogAndPlatform, randomPosition, Quaternion.identity);
                    originPosition = randomPosition;                
                }
                else{

                    Vector3 randomPosition = originPosition +
                    new Vector3(UnityEngine.Random.Range(horizontalMin, horizontalMax),
                                0, 0);
                    Instantiate(platform, randomPosition, Quaternion.identity);

                    originPosition = randomPosition;
                }


            }
        }

    }
}
