using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using UnityEngine;
using System.Collections;

namespace Assets.Scripts.Player
{
    class CameraFollow : MonoBehaviour{

        //Components
        private Vector2 velocity;
        public float smoothTimeY;
        public float smoothTimeX;

        public GameObject player;
        public GameObject lifeBarSystem;
        
        void Start(){
            player = GameObject.FindGameObjectWithTag("Player");
            lifeBarSystem = GameObject.FindGameObjectWithTag("LifeBar");
            lifeBarSystem.transform.position = new Vector3(player.transform.position.x, player.transform.position.y, 10);
        }

        void FixedUpdate(){
            float posX = Mathf.SmoothDamp(transform.position.x, player.transform.position.x, ref velocity.x, smoothTimeX);
            float posY = Mathf.SmoothDamp(transform.position.y, player.transform.position.y, ref velocity.y, smoothTimeY);
            transform.position = new Vector3(posX, posY, transform.position.z);
            //lifeBarSystem.transform.position = new Vector3(lifeBarSystem.transform.position.x, lifeBarSystem.transform.position.y, 10);
            lifeBarSystem.transform.position = new Vector3(posX, 5, 10);
        }

    }
}
