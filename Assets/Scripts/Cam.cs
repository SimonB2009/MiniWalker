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
        transform.Translate(new Vector2(player.movement, 0) * Time.deltaTime * player.speed);
    }
}
