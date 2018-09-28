using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
    class PhysicPlataformObject : MonoBehaviour{


        //Cord y = 4.010893

        
        public float min = -4.01f;
        public float max = 4.010893f;

        public float yCord; //log


        void OnCollisionEnter(Collision collision){
            GameObject otherObj = collision.gameObject;
            Debug.Log("Collided with: " + otherObj);
        }

        void OnTriggerEnter(Collider collider){
            GameObject otherObj = collider.gameObject;
            Debug.Log("Triggered with: " + otherObj);
        }
        
        public void Start(){ //Positions of start 
            min = transform.position.y - 2.05f;
            max = transform.position.y + 4.010893f;
        }

        public void Update(){
                transform.position = new Vector3(transform.position.x, 
                    Mathf.PingPong(Time.time * 3, max - min) + min, 
                    transform.position.z);
            yCord = Mathf.PingPong(Time.time * 3, max - min);

            
            

            
           
        }


    }

}

