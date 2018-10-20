using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Assets.Scripts;

public class PlayerController : MonoBehaviour {

    //Components
    public Rigidbody2D rb; //the component of this videos has depreced
    public GameObject Player;
    public float maxSpeed = 10f;

    //Variables
    bool facingRight = true;
    bool grounded = true;
    float jumpPower = 5;
    Animator anim;

    PlayerHealth healtCharacter = new PlayerHealth();
    int damageSpike = 1;

    private void OnCollisionEnter2D(Collision2D collision){
        
        if (collision.gameObject.CompareTag("Spike")){
            DamageCalculation(damageSpike);
            Debug.Log("SPIKE DAMAGE");
        }

        if (collision.gameObject.CompareTag("Coin")){
            ScorePlayer.scorePoints += 1;
            Destroy(collision.gameObject);
            Debug.Log("SCORE POINT");
        }
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
            //anim.SetTrigger("Jump");
            
        }

        if(Input.GetKey(KeyCode.Space) && ground){
            this.grounded = false;
            rb.AddForce(Vector3.up * 300);// transform.up*jumpPower);
            anim.SetTrigger("Jump");
            //Debug.Log("Valor: " + transform.up * jumpPower);
        }

    }

    public void DamageCalculation(int damage){
        PlayerHealth.health -= 1;
    }

	void Start () {
        anim = GetComponent<Animator>(); //Definition of component to start
        //GameObject lifeG =    GameObject.Find("heart_3");
        //lifeG.SetActive(false);
    }
	
	void Update () {

        float move = Input.GetAxis("Horizontal");
        anim.SetBool("Jump", false);

        anim.SetFloat("Speed", Mathf.Abs(move));
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(move * maxSpeed, rb.velocity.y);

        if (move > 0 && !facingRight)
            Flip();
        else if (move < 0 && facingRight)
            Flip();
        
        //Commands and controller
        JumpFunction(grounded);
	}
}