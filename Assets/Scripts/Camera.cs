using UnityEngine;

public class Camera : MonoBehaviour
{
    float speed = 8f;
    float jumpForce = 50f; //hoehe
    Rigidbody2D m_Rigidbody;


    private void Start()
    {
        m_Rigidbody = GetComponent<Rigidbody2D>();
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
        
    }
}
