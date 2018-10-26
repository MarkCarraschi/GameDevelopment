using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using UnityEngine;

namespace Assets.Scripts.Player
{
    class CameraFollow : MonoBehaviour{

        public Transform target;

        public float smoothSpeed = 0.125f;
        public Vector3 offset;

        private void Awake(){
            Vector3 desiredPosition = target.position + offset;
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
            transform.position = smoothedPosition;

            transform.LookAt(target);
        }

    }
}
