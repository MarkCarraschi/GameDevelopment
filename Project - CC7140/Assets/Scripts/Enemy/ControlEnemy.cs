
using UnityEngine;
using UnityEditor;
using System.Collections;



public class ControlEnemy : MonoBehaviour{

    public Rigidbody2D rb;
    public SpriteRenderer sr;

    public float speed = 2;
    
    void Start(){
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
    }

    void FixedUpdate(){
        rb.velocity = new Vector2(speed,0);
    }

    void OnCollisionEnter2D(Collision2D collision){
        if (collision.gameObject.CompareTag("Flipping")){
            Debug.Log("Entrance on conditional");
            sr.flipX = true;
            speed = -speed;
        }
    }
}