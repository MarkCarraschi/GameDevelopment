using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
    class PhysicPlataformObject : MonoBehaviour{


        //Cord y = 4.010893

        
        public float min = 0f;
        public float max = 4.010893f;

        public float yCord; //log

        public void Start(){ //Positions of start 
            min = transform.position.y;// - 1.85f;
            max = transform.position.y + 4.010893f;
        }

        public void Update(){
                transform.position = new Vector3(transform.position.x, 
                    Mathf.PingPong(Time.time * 3, max - min) + min, 
                    transform.position.z);
            yCord = Mathf.PingPong(Time.time * 3, max - min);


            Debug.Log("MIN: " + min);
            Debug.Log("\nMAX: " + max);
        }


    }

}

