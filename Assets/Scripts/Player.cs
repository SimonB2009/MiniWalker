using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Player : MonoBehaviour
{
    public float speed = 8f;
    public float jumpForce = 100f; //hoehe
    public float selectnummberA = 0;
    public float selectnummberD = 0;
    public float positionx = 0;
    public float positiony = 0;
    public float movement;
    public bool inAir = false;
    Rigidbody2D m_Rigidbody;
    public BoxCollider2D coll;
    public Animator anim;
    public Joystick joystick;

    [SerializeField] public LayerMask jumpableGround;


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
        movement = joystick.Horizontal; //Input.GetAxis("Horizontal");
        transform.Translate(new Vector2(movement,0) * Time.deltaTime * speed);

        positionx = transform.position.x;
        positiony = transform.position.y;

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

        if (Input.GetKey(KeyCode.Space)) { //Input.GetKey(KeyCode.Space)
            if (isGrounded() == true) {
                //animator.SetBool("jumping", true);
                m_Rigidbody.AddForce(new Vector2(0, jumpForce));
                inAir = true;
            }
        } 

        if (movement <= -0.02) { //Input.GetKeyDown(KeyCode.A)
            selectnummberA++;
            Rotate(1,selectnummberA); //left   //Attention movement is missing
        }   

        if (movement >= 0.02) { //Input.GetKeyDown(KeyCode.D)
            //animator.SetBool("jumping", false);
            selectnummberD++;
            Rotate(0,selectnummberD); //right   //Attention movement is missing
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
