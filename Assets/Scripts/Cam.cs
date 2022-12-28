using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Cam : MonoBehaviour
{
    public Player player;

    private void Start()
    {

    }

    private void Update()
    {   
        transform.position = player.transform.position;
        transform.Translate(new Vector3(4,0,-10) * 1);
    }
}
