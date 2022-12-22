using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoistickMove : MonoBehaviour
{
    public bool direction;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool readJoistick() {
        return direction = true; //false=left true=right
    }
}
