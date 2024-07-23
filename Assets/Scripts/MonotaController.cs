using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonotaController : MonoBehaviour
{
    public float speed = 10.0f;
    public Camera playerCamera;
    bool isGround = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //ADÉLÅ[éÊìæ
        float horizontal = Input.GetAxis("Horizontal");

        // Get the direction the camera is facing
        Vector3 right = playerCamera.transform.right;

        right.y = 0f;

        right.Normalize();

        // Calculate the direction based on the input
        Vector3 direction = right * horizontal;

        // Move the player
        transform.Translate(direction * speed * Time.deltaTime, Space.World);

        if(Input.GetKeyDown(KeyCode.W))
        {
            Junp();
        }
    }

    public void Junp()
    {
        
    }
}
