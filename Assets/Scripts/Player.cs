using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Player : MonoBehaviour
{
    float speed = 8f;
    float jumpForce = 100f; //hoehe
    float selectnummberA = 0;
    float selectnummberD = 0;
    bool inAir = false;
    Rigidbody2D m_Rigidbody;
    private BoxCollider2D coll;
    private Animator anim;
    //public CharacterController2D controller;
    [SerializeField] private LayerMask jumpableGround;


    private void Start()
    {
        m_Rigidbody = GetComponent<Rigidbody2D>();
        coll = GetComponent<BoxCollider2D>();
        anim = GetComponent<Animator>();
        selectnummberA++;                   //turn test
        Rotate(1,selectnummberA); //left
        selectnummberD++;
        Rotate(0,selectnummberD); //right
    }

    private void Update()
    {   
        isGrounded();
        //MOVEMENT
        var movement = Input.GetAxis("Horizontal");
        transform.Translate(new Vector2(movement,0) * Time.deltaTime * speed);

        if (movement != 0) {
            anim.SetBool("running", true);
        } else {
            anim.SetBool("running", false);
        }

        if (inAir == true) {
            anim.SetBool("jumping", true);
        } else {
            anim.SetBool("jumping", false);
        }

        if (isGrounded() == true) {inAir = false;}

        if (Input.GetKey(KeyCode.Space)) {
            if (isGrounded() == true) {
                //animator.SetBool("jumping", true);
                m_Rigidbody.AddForce(new Vector2(0, jumpForce));
                inAir = true;
            }
        } 

        if (Input.GetKeyDown(KeyCode.A)) {
            //animator.SetBool("jumping", false);
            selectnummberA++;
            Rotate(1,selectnummberA); //left
        }   

        if (Input.GetKeyDown(KeyCode.D)) {
            //animator.SetBool("jumping", false);
            selectnummberD++;
            Rotate(0,selectnummberD); //right
        } 
        
    }

     void Rotate (float rotation, float selectnummber) { //0=right 1=left
       
        if (rotation == 0) { //rechtsa
            selectnummberA = 0;
            speed = 8f;
            if (selectnummber == 1) {
                transform.Rotate(0, 180, 0);
            } 
        }
        
        if (rotation == 1) { //links
            selectnummberD = 0;
            speed = -8f;
            if (selectnummber == 1) {
                transform.Rotate(0, 180, 0);
            } 
        }
     }

    public bool isGrounded() {
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0, Vector2.down, .1f, jumpableGround);
    }

}
