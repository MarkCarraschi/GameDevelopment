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

        public float horizontalMin = 6.5f;
        public float horizontalMax = 5.5f;
        public float verticalMin = 6f;
        public float verticalMax = 6;

        public Vector3 originPosition;
        public GameObject myGround;

        void Start(){
            originPosition = myGround.transform.position;//transform.position;
            //myGround.transform.position;
            Spawn();
        }

        void Spawn(){
            for(int i = 0; i < 6; i++){

                /// <summary>
                /// This code represents the original
                /// In this game we change this block because it's not necessary apply cordinates y
                /// </summary>
                //Vector3 randomPosition = originPosition +
                //    new Vector3(UnityEngine.Random.Range(horizontalMin, horizontalMax),
                //                UnityEngine.Random.Range(verticalMin, verticalMax),10);
                //Instantiate(platform, randomPosition, Quaternion.identity);

                if (i == 3){
                    Vector3 randomPosition = originPosition 
                        + new Vector3(UnityEngine.Random.Range(horizontalMin, horizontalMax),0, 0);
                    Instantiate(DogAndPlatform, randomPosition, Quaternion.identity);
                    originPosition = randomPosition;
                    Debug.Log("\noriginPosition: " + originPosition);
                }
                else{
                    Vector3 randomPosition = originPosition +
                    new Vector3(UnityEngine.Random.Range(horizontalMin, horizontalMax),0, 0);
                    Instantiate(platform, randomPosition, Quaternion.identity);
                    originPosition = randomPosition;

                //    //Debug.Log("\noriginPosition: " + originPosition);
                }


            }
        }

    }
}
