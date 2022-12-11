using UnityEngine;

public class Movement2d : MonoBehaviour
{
    public float speed = 20f;
    public float jumpForce = 1f;
    private Vector3 moveDir;

    private Rigidbody2D _rigidbody;

    private void Start()
    {
        
    }

    private void Update()
    {
        var movement = Input.GetAxis("Horizontal");
        transform.position += new Vector3(movement,0,0) * Time.deltaTime * speed;

        if (Input.GetKey(KeyCode.S)) {
            transform.position += new Vector3(0, jumpForce).normalized;
        }
    }
}
