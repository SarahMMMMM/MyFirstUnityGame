using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Movement : MonoBehaviour
{
    public Transform _camera;
    public float speed, rotSpeed;
    private float rotX, rotY;
    private Rigidbody rb;
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
      //  Move();
    }

    private void FixedUpdate()
    {
        // movement with arrow keys
        Vector3 newVelocity = Vector3.up * rb.velocity.y;
        //float speed = Input.GetKey(KeyCode.LeftShift) ? runSpeed : walkSpeed;
        newVelocity.x = Input.GetAxis("Horizontal") * speed;
        newVelocity.z = Input.GetAxis("Vertical") * speed;
        rb.velocity = transform.TransformDirection(newVelocity);
    }

    private void Rotate()
    {
        rotY += Input.GetAxisRaw("Mouse X") * rotSpeed * Time.deltaTime;
        rotX -= Input.GetAxisRaw("Mouse Y") * rotSpeed * Time.deltaTime;

        rotX = Mathf.Clamp(rotX, -90f, 50f);

        transform.rotation = Quaternion.Euler(0f, rotY, 0f);
        _camera.rotation = Quaternion.Euler(rotX, rotY, 0f);
    }

    /* void Move()
    {
        
        _camera.position = transform.position + offset;

        moveDelta = transform.forward * Input.GetAxisRaw("Vertical") + transform.right * Input.GetAxisRaw("Horizontal");
        rb.velocity = moveDelta.normalized * speed;
    
        } */
}