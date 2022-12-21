using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Player : MonoBehaviour
{
    float speed = 8f;
    float jumpForce = 70f; //hoehe
    float selectnummberA = 0;
    float selectnummberD = 0;
    Rigidbody2D m_Rigidbody;
    //public Animator animator;
    //public CharacterController2D controller;


    private void Start()
    {
        m_Rigidbody = GetComponent<Rigidbody2D>();
        selectnummberA++;                   //turn test
        Rotate(1,selectnummberA); //left
        selectnummberD++;
        Rotate(0,selectnummberD); //right
    }

    private void Update()
    {   
        //MOVEMENT
        var movement = Input.GetAxis("Horizontal");
        transform.Translate(new Vector2(movement,0) * Time.deltaTime * speed);
        //m_Rigidbody.AddForce(new Vector2(movement * speed, 0));

        if (Input.GetKey(KeyCode.Space)) {
            //m_Rigidbody.AddForce(transform.up );
            m_Rigidbody.AddForce(new Vector2(0, jumpForce));
        } 

        if (Input.GetKeyDown(KeyCode.A)) {
            selectnummberA++;
            Rotate(1,selectnummberA); //left
        }   

        if (Input.GetKeyDown(KeyCode.D)) {
            selectnummberD++;
            Rotate(0,selectnummberD); //right
        } 
        
    }

     void Rotate (float rotation, float selectnummber) { //0=right 1=left
        /*Quaternion theRotation = transform.localRotation;
         
        if (rotation == 0) {
            theRotation.y = 178;
            rotation = 1;
        }
        if (rotation == 1) {
            theRotation.y = 0;
            rotation = 0;
        }

        transform.localRotation = theRotation;*/

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
}
