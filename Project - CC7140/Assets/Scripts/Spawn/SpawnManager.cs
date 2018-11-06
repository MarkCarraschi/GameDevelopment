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
        public GameObject SkyPrefabFragment;
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
        public Vector3 originPositionFragmentSky;
        public Vector3 originPositionMountain;
        public Vector3 originPositionCoinDog;
        public Vector3 originPositionCoin;

        private int counterMountain = 0;
        private int counterSky = 0; 


        void Start(){

            originPosition = DogAndPlatform.transform.position;
            originPositionPlataform = platformObject.transform.position;

            //Sky
            originPositionSky = SkyPrefab.transform.position;
            originPositionFragmentSky = SkyPrefabFragment.transform.position;

            originPositionMountain = MountainPrefab.transform.position;

            //Coins
            originPositionCoinDog = CoinPrefabDogTransform.transform.position;
            originPositionCoin = CoinPrefab.transform.position;

            Spawn();
        }


        void SpawnEnviroment(){


            //Não teve geito :/
            //Foi necessário demarcar o cenário

            //GAMBIS
            if (counterSky < 18){
                Vector3 randomPositionPrefabSky = originPositionSky
                         + new Vector3(7.0f, 0, 3);
                Instantiate(SkyPrefab, randomPositionPrefabSky, Quaternion.identity);
                originPositionSky = randomPositionPrefabSky;
                counterSky = counterSky + 1;
            }
             else if ( counterSky == 18)
            {
                //Tratamento do fragmento
                Vector3 PositionPrefabFragmentSky =  new Vector3(269.75f, 3.15f, 60);
                Instantiate(SkyPrefabFragment, PositionPrefabFragmentSky, Quaternion.identity);
                counterSky = counterSky + 1;
            }

            //GAMBIS
            if(counterMountain < 18){
                Vector3 randomPositionPrefabMountain = originPositionMountain
                     + new Vector3(7.0f, 0, 2);
                
                Instantiate(MountainPrefab, randomPositionPrefabMountain, Quaternion.identity);
                originPositionMountain = randomPositionPrefabMountain;
                counterMountain = counterMountain + 1;
              
            }

            if (counterMountain == 18){
                Vector3 PositionPrefabMountain =  new Vector3(108.3f, 1.98f, 40);
                Instantiate(MountainPrefab, PositionPrefabMountain, Quaternion.identity);
                originPositionMountain = PositionPrefabMountain;
                counterMountain = counterMountain + 1;
            }
        }

        void Spawn(){

            for (int i = 0; i < maxPlatform; i++){

                if (i % 3 == 0){
                    SpawnEnviroment();
                    Vector3 randomPosition = originPosition
                        + new Vector3(7.0f, 0, 0);
                    Instantiate(platformSpike, randomPosition, Quaternion.identity);
                    originPosition = randomPosition;
                }
                else if (i % 5 == 0){
                    SpawnEnviroment();
                    Vector3 randomPosition = originPosition
                        + new Vector3(7.0f, 0, 0);
                    Instantiate(DogAndPlatform, randomPosition, Quaternion.identity);
                    originPosition = randomPosition;
                    
                    //Prefab Coins on Dog Platform
                    Vector3 randomPositionCoinDog = originPositionCoinDog
                        + new Vector3(7.0f, 0, 0);
                    Instantiate(CoinPrefabDogTransform, randomPositionCoinDog, Quaternion.identity);
                    originPositionCoinDog = randomPositionCoinDog;
                }
                else{
                    SpawnEnviroment();
                    Vector3 randomPosition = originPosition +
                    new Vector3(7.0f, 0, 0);
                    Instantiate(platformObject, randomPosition, Quaternion.identity);
                    originPosition = randomPosition;

                    Vector3 randomPositionCoinDog = originPositionCoinDog
                       + new Vector3(7.0f, 0, 0);
                   
                    Instantiate(CoinPrefabDogTransform, randomPositionCoinDog, Quaternion.identity);
                    originPositionCoinDog = randomPositionCoinDog;
                
                    if (i == 13){
                        Vector3 positionCrystal = new Vector3(131.88f, 1.3f, 1);
                        Instantiate(EndPhase, positionCrystal, Quaternion.identity);
                        EndPhase.GetComponent<Renderer>().enabled = true;
                    }
                }
            }
        }

    }
}
