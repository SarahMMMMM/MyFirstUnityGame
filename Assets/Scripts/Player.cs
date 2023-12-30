using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Player : MonoBehaviour
{
    private bool jumpKeyPressed;
    private float horizontalInput;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            jumpKeyPressed = true;
        }

        //horizontalInput = Input.GetAxis("horizontal");

    }

    //Fixed Update is called once every physics update
    private void FixedUpdate()
    {
        if (jumpKeyPressed)
        {
            GetComponent<Rigidbody>().AddForce(Vector3.up * 5, ForceMode.VelocityChange);   //this is a method
            jumpKeyPressed = false;        
        }

        //GetComponent<Rigidbody>().velocity = new Vector3(horizontalInput, 0, 0);
    }
}
