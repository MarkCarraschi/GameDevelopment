using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerEnimie : MonoBehaviour {

    //Components
    public Rigidbody2D rb; //the component of this videos has depreced
    public GameObject Player;
    public float maxSpeed = 10f;
    bool facingRight = true;

    //Animation references
    Animator anim;

    //Flip funtion
    void Flip(){
        facingRight = !facingRight; //or facingRight == false
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }


	void Start () {
        //rb.GetComponent<Rigidbody>();
        anim = GetComponent<Animator>(); //Definition of component to start
	}
	
	
	void FixedUpdate () {

        float move = Input.GetAxis("Horizontal");

        anim.SetFloat("Speed", Mathf.Abs(move));

        rb = GetComponent<Rigidbody2D>();

        rb.velocity = new Vector2(move * maxSpeed, rb.velocity.y);

        if (move > 0 && !facingRight)
            Flip();
        else if (move < 0 && facingRight)
            Flip();
	}
}
