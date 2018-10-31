
using UnityEngine;
using UnityEditor;
using System.Collections;

public class ControlEnemy : MonoBehaviour{

    public Rigidbody2D rb;
    public SpriteRenderer sr;
    Animator anim;

    public float speed = 2;
    
    void Start(){
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        sr.flipX = true;
    }

    void FixedUpdate(){
        rb.velocity = new Vector2(speed,0);
        
        anim.SetFloat("Speed", speed);

    }

    void OnCollisionEnter2D(Collision2D collision){
        if (collision.gameObject.CompareTag("Flipping")){
            //Debug.Log("Entrance on conditional");
            sr.flipX = true;
            Vector3 theScale = transform.localScale;
            theScale.x *= -1;
            transform.localScale = theScale;
            speed = -speed;
        }
    }
}