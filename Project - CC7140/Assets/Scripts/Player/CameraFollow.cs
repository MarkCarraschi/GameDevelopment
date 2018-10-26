using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using UnityEngine;
using System.Collections;

namespace Assets.Scripts.Player
{
    class CameraFollow : MonoBehaviour{

        //public Transform target;

        //public float smoothspeed = 0.125f;
        //public Vector3 offset;

        //private void awake()
        //{
        //    Vector3 desiredposition = target.position + offset;
        //    Vector3 smoothedposition = Vector3.Lerp(transform.position, desiredposition, smoothspeed);
        //    transform.position = smoothedposition;

        //    transform.LookAt(target);
        //}

        //public float dampTime = 0.15f;
        //private Vector3 velocity = Vector3.zero;
        //public Transform target;
        //Camera cameraObject;

        //void Start(){
        //    cameraObject = GetComponent<Camera>();
        //}

        //void Update(){

        //    if (target){
        //        Vector3 point = cameraObject.WorldToViewportPoint(target.position);
        //        Vector3 delta = target.position - cameraObject.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, point.z));
        //        Vector3 destination = transform.position + delta;
        //        transform.position = Vector3.SmoothDamp(transform.position, destination, ref velocity, dampTime);
        //    }

        //}

        //Components
        private Vector2 velocity;
        public float smoothTimeY;
        public float smoothTimeX;

        public GameObject player;

        void Start(){
            player = GameObject.FindGameObjectWithTag("Player");
        }

        void FixedUpdate(){
            float posX = Mathf.SmoothDamp(transform.position.x, player.transform.position.x, ref velocity.x, smoothTimeX);
            float posY = Mathf.SmoothDamp(transform.position.y, player.transform.position.y, ref velocity.y, smoothTimeY);
            transform.position = new Vector3(posX, posY, transform.position.z);
        }

    }
}
