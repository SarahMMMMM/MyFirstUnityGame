using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Movement : MonoBehaviour
{


    [Header("References")]
    public Transform _camera;
    private Rigidbody rb;


    [Header("Configurations")]
    public float speed, rotSpeed, jumpSpeed;
    private float rotX, rotY;


    [Header("Runtime")]
    Vector3 newVelocity;
    bool isGrounded = false;
    bool isJumping = false;

    
    
    
    private Vector3 offset;
    private Vector3 moveDelta;


    private void Awake()
    {
        offset = _camera.position - transform.position;
        rb = GetComponent<Rigidbody>();
    }

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        Rotate();
        Move();

        if(Input.GetKeyDown(KeyCode.Space)) 
        {
            Debug.Log("Jump!");
            isJumping = true;
        }
    }





    private void Move()
    {
        newVelocity = Vector3.up * rb.velocity.y;
        //float speed = Input.GetKey(KeyCode.LeftShift) ? runSpeed : walkSpeed;
        newVelocity.x = Input.GetAxis("Horizontal") * speed;
        newVelocity.z = Input.GetAxis("Vertical") * speed;
    }

    private void FixedUpdate()
    {
        // movement with arrow keys
        rb.velocity = transform.TransformDirection(newVelocity);
        
        if (isJumping)
        {
            GetComponent<Rigidbody>().AddForce(Vector3.up * 5, ForceMode.VelocityChange);   //this is a method
            isJumping = false;
        }
    }

    private void Rotate()
    {
        rotY += Input.GetAxisRaw("Mouse X") * rotSpeed * Time.deltaTime;
        rotX -= Input.GetAxisRaw("Mouse Y") * rotSpeed * Time.deltaTime;

        rotX = Mathf.Clamp(rotX, -90f, 50f);

        transform.rotation = Quaternion.Euler(0f, rotY, 0f);
        _camera.rotation = Quaternion.Euler(rotX, rotY, 0f);
    }

   
}