using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Cam : MonoBehaviour
{
    public Player player;

    private void Start()
    {
        //player = GameObject.Find("Player").GetComponent<Player>();
    }

    private void Update()
    {   
        float speed = player.speed;
        float movement = player.movement;
        transform.Translate(new Vector2(movement, 0) * Time.deltaTime * speed);
    }
}
