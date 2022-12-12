using UnityEngine;

public class Movement2d : MonoBehaviour
{
    float speed = 8f;
    float jumpForce = 20f; //hoehe
    float velocity;
    float jumpY;

    private Rigidbody2D _rigidbody;

    private void Start()
    {
        
    }

    private void Update()
    {
        var movement = Input.GetAxis("Horizontal");
        transform.position += new Vector3(movement,0,0) * Time.deltaTime * speed;

        if (Input.GetKey(KeyCode.Space)) {
            velocity = jumpForce;
            jumpY = transform.position.y;
        }
        if (jumpY == transform.position.y) {
            transform.Translate(new Vector3(0, velocity, 0) * Time.deltaTime);
        }  
    }
}
