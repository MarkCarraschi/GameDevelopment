using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;
 // Import library previous directory

public class EnemyController : MonoBehaviour{

    //Components of function FLIP
    bool facingRight = true;

    Rigidbody2D rb_enimie;
    Animator anim;
    Transform target; //Player position
    public float velocity = 1f;

    //Mechanic of game
    public int damagePlayer;
    private bool collisionFlag = false;

    public BoxCollider2D platform;
    private int counter = 0;

    private void OnCollisionEnter2D(Collision2D collision){
        GameObject gObject = collision.gameObject;
        Debug.Log("Collided with: " + gObject);
        collisionFlag = true;
    }

    //Flip --> change orientation of character
    void Flip(){
        facingRight = !facingRight; //or facingRight == false
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

    //Initialize Enemy 
    void Start () {
        //Instance of components 
        anim = GetComponent<Animator>();
        rb_enimie = GetComponent<Rigidbody2D>();
        target = GetComponent<Transform>();
        
    }

    private void Update(){
        MoveEnemy();
    }
    
    public void MoveEnemy(){ //Movement of the enemy

        int x = 0; //The enemy move only on x 

        //ZigZag moviment

        transform.position = new Vector3(
            Mathf.PingPong(Time.time, platform.size.x),
            transform.position.y,
            transform.position.z);
        //Debug.Log("Valor box X: " + platform.size.x);
        anim.SetFloat("Speed", Mathf.Abs(platform.size.x));
        
        if (transform.position.x < 1 || transform.position.x > 6){
            //transform.position = new Vector3(Mathf.PingPong(Time.time,1), transform.position.y, transform.position.z);
            
            //rb_enimie.velocity = Vector3.zero;
            anim.SetFloat("Speed", Mathf.Abs(0));
  

            if (counter == 0 && (transform.position.x < 0.2 || transform.position.x > 7.8)) {
                Flip();
                transform.position = new Vector3(
            0,
            transform.position.y,
            transform.position.z);
                anim.SetFloat("Speed", Mathf.Abs(0));
                counter++;
            }

        }
        else counter = 0;
    }
}