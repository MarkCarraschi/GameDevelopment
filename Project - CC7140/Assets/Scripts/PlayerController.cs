using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    //Components
    public Rigidbody2D rb; //the component of this videos has depreced
    public GameObject Player;
    public float maxSpeed = 10f;

    //Variables
    bool facingRight = true;
    bool grounded = true;
    float jumpPower = 5;
    //int jumphash = Animator.StringToHash("Jump");
    Animator anim;

    void OnCollisionEnter2D(Collision2D collision){
        GameObject otherObj = collision.gameObject;
        Debug.Log("Collided with: " + otherObj);
    }

    void OnCollisionStay2D(Collision2D collision){
        GameObject otherObj = collision.gameObject;
        Debug.Log("Collided stay in : " + otherObj);
    }

    void OnTriggerEnter2D(Collider2D collider){
        GameObject otherObj = collider.gameObject;
        Debug.Log("Triggered with: " + otherObj);
    }

    //Flip --> change orientation of character
    void Flip(){
        facingRight = !facingRight; //or facingRight == false
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

    void JumpFunction(bool ground){

        if (!ground && rb.velocity.y == 0){ //Press Space button to jump
            //transform.position = new Vector3(transform.position.x,
            //    Mathf.PingPong(Time.time *2, 1), transform.position.z);
            //anim.SetTrigger(jumphash);
            this.grounded = true;
            //anim.SetBool("Jump", true);
            
        }

        if(Input.GetKey(KeyCode.Space) && ground){
            this.grounded = false;
            rb.AddForce(Vector3.up * 300);// transform.up*jumpPower);
            Debug.Log("Valor: " + transform.up * jumpPower);
        }

    }

	void Start () {
        anim = GetComponent<Animator>(); //Definition of component to start
	}
	
	
	void Update () {

        float move = Input.GetAxis("Horizontal");
        anim.SetBool("Jump", false);

        anim.SetFloat("Speed", Mathf.Abs(move));
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(move * maxSpeed, rb.velocity.y);

        Debug.Log("Valor do RB VELOCITY POR FRAME"+rb.velocity.y);

        if (move > 0 && !facingRight)
            Flip();
        else if (move < 0 && facingRight)
            Flip();
        
        //Commands and controller
        JumpFunction(grounded);
	}
}