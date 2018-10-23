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
        public float horizontalMin = 7.5f;
        public float horizontalMax = 14f;
        public float verticalMin = 6f;
        public float verticalMax = 6;

        private Vector2 originPosition;

        void Start(){
            originPosition = transform.position;
            Spawn();
        }

        void Spawn(){
            for(int i = 0; i < maxPlatform; i++){
                Vector2 randomPosition = originPosition +
                    new Vector2(UnityEngine.Random.Range(horizontalMin, horizontalMax),
                                UnityEngine.Random.Range(verticalMin, verticalMax));
            }
        }

    }
}
