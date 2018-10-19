using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;

using Assets.Scripts; // Import library previous directory

public class EnemyController : MonoBehaviour{

    //Components of function FLIP
    bool facingRight = true;

    //Test
    bool endLine = false;

    Rigidbody2D rb_enimie;
    Animator anim;
    Transform target; //Player position
    public float velocity = 1f;

    //Mechanic of game
    public int damagePlayer;
    private bool collisionFlag = false;

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
        rb_enimie.transform.position = new Vector3(
            GameObject.Find("Doberman").transform.position.x,
            GameObject.Find("Doberman").transform.position.y,
            GameObject.Find("Doberman").transform.position.z);

        //Debug.Log("Coordenadas x" + GameObject.Find("Doberman").transform.position.x);

    }

    private void Update(){
        MoveEnemy();

        //if (collisionFlag == true)
            //Debug.Log("Damage !!!!! ");

    }

    private void FixedUpdate(){
        //if (endLine) Flip();
    }

    public void MoveEnemy(){ //Movement of the enemy

        int x = 7; //The enemy move only on x 

        //ZigZag moviment

        transform.position = new Vector3(
            Mathf.PingPong(Time.time, x),
            transform.position.y,
            transform.position.z);

        anim.SetFloat("Speed", Mathf.Abs(x));
        
        if (transform.position.x < 1 ){     //|| transform.position.x > 6){
            //transform.position = new Vector3(Mathf.PingPong(Time.time,1), transform.position.y, transform.position.z);
            
            rb_enimie.velocity = Vector3.zero;
            anim.SetFloat("Speed", Mathf.Abs(0));
            endLine = true;
            //if (facingRight) facingRight = false;

        }

    }
}
