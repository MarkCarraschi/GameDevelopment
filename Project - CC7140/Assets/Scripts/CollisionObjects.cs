using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using UnityEngine;

namespace Assets.Scripts
{
    class CollisionObjects : MonoBehaviour{

        private void OnCollisionEnter2D(Collision2D collision){
            GameObject gObject = collision.gameObject;
            Debug.Log("Collided with: " + gObject);
        }

        private void OnCollisionStay(Collision collision){
            GameObject gObject = collision.gameObject;
            Debug.Log("Collided stay with: " + gObject);
        }

        private void OnTriggerEnter2D(Collider2D collision){
            GameObject gObject = collision.gameObject;
            Debug.Log("Triggered with: " + gObject);
        }


    }
}
