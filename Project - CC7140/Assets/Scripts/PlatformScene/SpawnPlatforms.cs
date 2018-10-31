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
    class SpawnPlatforms : MonoBehaviour{

        public int maxPlatform = 15;

        public GameObject platformObject;
        public GameObject platformSpike;
        public GameObject DogAndPlatform;

        //Scene manipulation
        public GameObject MountainPrefab;
        public GameObject SkyPrefab;

        public float horizontalMin = 30.5991f;
        public float horizontalMax = 30.5992f;
        public float verticalMin = 6f;
        public float verticalMax = 6;

        public Vector3 originPosition;
        public Vector3 originPositionPlataform;
        
        void Start(){
            originPosition = DogAndPlatform.transform.position;//transform.position;
            originPositionPlataform = platformObject.transform.position;
            Spawn();
        }

        void Spawn(){
            for (int i = 0; i < maxPlatform; i++){
               
                //Origin Sample 
                //Vector3 randomPosition = originPosition +
                //    new Vector3(UnityEngine.Random.Range(horizontalMin, horizontalMax),
                //                UnityEngine.Random.Range(verticalMin, verticalMax),10);
                //Instantiate(platform, randomPosition, Quaternion.identity);

                //Vector3 randomPositionPrefab = originPosition
                //          + new Vector3(UnityEngine.Random.Range(horizontalMin, horizontalMax), 0, 0);
                //Instantiate(SkyPrefab, randomPositionPrefab, Quaternion.identity);
                //originPosition = randomPositionPrefab;

                if (i % 3 == 0){

                    Debug.Log("\nOrigin Position SPIKE: i[" + i +"]: "+ originPosition);

                    Vector3 randomPosition = originPosition
                        + new Vector3(7.0f, 0, 0);
                    Instantiate(platformSpike, randomPosition, Quaternion.identity);
                    originPosition = randomPosition;

                    //Ajustar coordenadas Z para que o alinhamento fique correto

                    //Vector3 randomPositionPrefab = randomPosition
                    //          + new Vector3(UnityEngine.Random.Range(horizontalMin, horizontalMax), 0, 0);
                    //Instantiate(SkyPrefab, randomPositionPrefab, Quaternion.identity);
                    //originPosition = randomPositionPrefab;
                    Debug.Log("\nRandom Position SPIKE: i[" + i + "]: " + randomPosition);
                }
                else if (i % 5 == 0 ){

                    Debug.Log("\nOrigin Position Dog: i[" + i + "]: " + originPosition);
                    Vector3 randomPosition = originPosition
                        + new Vector3(7.0f, 0, 0);
                    Instantiate(DogAndPlatform, randomPosition, Quaternion.identity);
                    originPosition = randomPosition;
                    Debug.Log("\nRandom Position Dog: i[" + i + "]: " + randomPosition);
                }
                //else if (i % 2 == 0 ){
                //    Debug.Log("\nOrigin Position Dog: i[" + i + "]: " + originPosition);

                //    Vector3 randomPosition = originPosition
                //        + new Vector3(7.0f, 0, 0);
                //    Instantiate(platformObject, randomPosition, Quaternion.identity);
                //    originPosition = randomPosition;

                //    Debug.Log("\nRandom Position Dog: i[" + i + "]: " + randomPosition);
                //}
                else{

                    Debug.Log("\nOrigin Position Object : i[" + i + "]: " + originPosition);

                    Vector3 randomPosition = originPosition +
                    new Vector3(7.0f, 0, 0);
                    Instantiate(platformObject, randomPosition, Quaternion.identity);
                    originPosition = randomPosition;
                    
                    Debug.Log("\nRandom Position Object : i[" + i + "]: " + randomPosition);
                }


            }
        }

    }
}
