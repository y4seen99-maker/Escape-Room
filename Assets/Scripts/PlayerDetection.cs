using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDetection : MonoBehaviour

{

    public static bool found = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "PlayerBody")
        {
            found = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        found = false;
    }


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
