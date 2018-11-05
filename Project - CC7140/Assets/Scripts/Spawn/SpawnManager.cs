using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

/// <summary>
/// Manager of Stage Game
/// </summary>

namespace Assets.Scripts.ObjectsScene
{
    class SpawnManager : MonoBehaviour{

        public int maxPlatform = 15;

        public GameObject platformObject;
        public GameObject platformSpike;
        public GameObject DogAndPlatform;
     
        //Scene manipulation
        public GameObject MountainPrefab;
        public GameObject SkyPrefab;
        public GameObject CoinPrefab;
        public GameObject CoinPrefabDogTransform;
        public GameObject EndPhase;

        public float horizontalMin = 30.5991f;
        public float horizontalMax = 30.5992f;
        public float verticalMin = 6f;
        public float verticalMax = 6;

        public Vector3 originPosition;
        public Vector3 originPositionPlataform;
        public Vector3 originPositionSky;
        public Vector3 originPositionMountain;
        public Vector3 originPositionCoinDog;
        public Vector3 originPositionCoin;


        void Start(){
            originPosition = DogAndPlatform.transform.position;
            originPositionPlataform = platformObject.transform.position;
            originPositionSky = SkyPrefab.transform.position;
            originPositionMountain = MountainPrefab.transform.position;

            //Coins
            originPositionCoinDog = CoinPrefabDogTransform.transform.position;
            originPositionCoin = CoinPrefab.transform.position;

            //Hide GameObject
            EndPhase.GetComponent<Renderer>().enabled = false;

            Spawn();
        }

        void Spawn(){
            for (int i = 0; i < maxPlatform; i++){
               
                //    new Vector3(UnityEngine.Random.Range(horizontalMin, horizontalMax),
                
                
                Vector3 randomPositionPrefabSky = originPositionSky
                          + new Vector3(7.0f, 0, 3);
                Instantiate(SkyPrefab, randomPositionPrefabSky, Quaternion.identity);
                originPositionSky = randomPositionPrefabSky;

                Vector3 randomPositionPrefabMountain = originPositionMountain
                         + new Vector3(UnityEngine.Random.Range(horizontalMin, horizontalMax), 0, 2);
                Instantiate(MountainPrefab, randomPositionPrefabMountain, Quaternion.identity);
                originPositionMountain = randomPositionPrefabMountain;

                if (i % 3 == 0){

                    Vector3 randomPosition = originPosition
                        + new Vector3(7.0f, 0, 0);
                    Instantiate(platformSpike, randomPosition, Quaternion.identity);
                    originPosition = randomPosition;
                                     
                }
                else if (i % 5 == 0 ){
                    //Debug.Log("\nOrigin Position Dog: i[" + i + "]: " + originPosition);
                    Vector3 randomPosition = originPosition
                        + new Vector3(7.0f, 0, 0);
                    Instantiate(DogAndPlatform, randomPosition, Quaternion.identity);
                    originPosition = randomPosition;
                    //Debug.Log("\nRandom Position Dog: i[" + i + "]: " + randomPosition);

                    //Prefab System Coin
                    //Vector3 randomPositionCoin = originPositionCoin
                    //    + new Vector3(7.0f, 0, 0);
                    //Instantiate(CoinPrefab, randomPositionCoin, Quaternion.identity);
                    //originPositionCoin = randomPositionCoin;

                    //Prefab Coins on Dog Platform
                    Vector3 randomPositionCoinDog = originPositionCoinDog
                        + new Vector3(7.0f, 0, 0);
                    Debug.Log("Valor do originPositionCoinDog: " + originPositionCoinDog);
                    Instantiate(CoinPrefabDogTransform, randomPositionCoinDog, Quaternion.identity);
                    originPositionCoinDog = randomPositionCoinDog;
                    Debug.Log("Valor do randomPositionCoinDog: " + randomPositionCoinDog);
                }
                else{
                    
                    Vector3 randomPosition = originPosition +
                    new Vector3(7.0f, 0, 0);
                    Instantiate(platformObject, randomPosition, Quaternion.identity);
                    originPosition = randomPosition;

                    Vector3 randomPositionCoinDog = originPositionCoinDog
                       + new Vector3(7.0f, 0, 0);
                    Debug.Log("Valor do originPositionCoinDog: " + originPositionCoinDog);
                    Instantiate(CoinPrefabDogTransform, randomPositionCoinDog, Quaternion.identity);
                    originPositionCoinDog = randomPositionCoinDog;
                    Debug.Log("Valor do randomPositionCoinDog: " + randomPositionCoinDog);

                    //Debug.Log("ELSE");

                    if(i == 13){

                        Vector3 positionCrystal = new Vector3(76.88f,-0.14f,1);
                        Instantiate(EndPhase, positionCrystal , Quaternion.identity);
                        EndPhase.GetComponent<Renderer>().enabled = true;
                    }

                }
            }
        }

    }
}
