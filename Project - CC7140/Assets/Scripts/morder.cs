using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class morder : MonoBehaviour {
    float positionX;
    // Use this for initialization
    void Start () {
        positionX = 2.76f;
    }
	
	// Update is called once per frame
	void Update () {

        while(positionX>1.0f)
        {
            transform.position = new Vector3(positionX, transform.position.y, transform.position.z);
            positionX = positionX - 0.0001f;
            
        }
	}
}
