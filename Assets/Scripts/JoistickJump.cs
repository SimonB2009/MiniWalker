using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoistickJump : MonoBehaviour
{
    
    public bool jump;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool readJoistick() {
        return jump = false; //false=nein true=ja
    }
}
