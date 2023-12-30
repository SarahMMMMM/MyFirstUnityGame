using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    [Header("References")]
    public Rigidbody rb;
    public Transform head;
    public Camera camera;


    [Header("Configurations")]
    public float walkSpeed;
    public float runSpeed;

    // Start is called before the first frame update
    
    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        //horizontal rotation
        transform.Rotate(Vector3.up * Input.GetAxis("Mouse X") * 2f);
    }


    private void FixedUpdate()
    {
        // movement with arrow keys
        Vector3 newVelocity = Vector3.up * rb.velocity.y;
        float speed = Input.GetKey(KeyCode.LeftShift) ? runSpeed : walkSpeed;
        newVelocity.x = Input.GetAxis("Horizontal") * speed;
        newVelocity.z = Input.GetAxis("Vertical") * speed;
        rb.velocity = transform.TransformDirection(newVelocity);
    }

    
    private void LateUpdate()
    {
        //vertical rotation
        Vector3 e = new Vector3(0, 0, 0);
        e.x -= Input.GetAxis("Mouse Y") * 2f;
        e.x = RestrictAngle(e.x, -85f, 85f);
        head.eulerAngles = e;
    }

    //clamp vertical head rotation
    public static float RestrictAngle(float angle, float angleMin, float angleMax)
    {
        if (angle > 180)
            angle -= 360;
        else if (angle < -180)
            angle += 360;

        if (angle > angleMax)
            angle = angleMax;
        if (angle < angleMin)
            angle = angleMin;
    
        return angle;
    }
    
}
