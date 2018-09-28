using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerEnimie : MonoBehaviour {

    //Components
    public Rigidbody2D rb; //the component of this videos has depreced
    public GameObject Player;
    public float maxSpeed = 10f;
    bool facingRight = true;
    int jumphash = Animator.StringToHash("Jump");
    //Animation references
    Animator anim;

    //Flip funtion
    void Flip(){
        facingRight = !facingRight; //or facingRight == false
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

    void JumpFunction(){

        if (Input.GetKey(KeyCode.Space)){ //Press Space button to jump
            transform.position = new Vector3(transform.position.x,
                Mathf.PingPong(Time.time *2, 1), transform.position.z);
            anim.SetTrigger(jumphash);
        }

    }

	void Start () {
        //rb.GetComponent<Rigidbody>();
        anim = GetComponent<Animator>(); //Definition of component to start
	}
	
	
	void Update () {

        float move = Input.GetAxis("Horizontal");

        anim.SetFloat("Speed", Mathf.Abs(move));

        rb = GetComponent<Rigidbody2D>();

        rb.velocity = new Vector2(move * maxSpeed, rb.velocity.y);

        if (move > 0 && !facingRight)
            Flip();
        else if (move < 0 && facingRight)
            Flip();

        //Another functions
        JumpFunction();
	}
}
