using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rg;
    public float speed = 10.0f;
    public float speedH = 2.0f;
    public float speedV = 2.0f;

    private float yaw = 0.0f;
    private float pitch = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        rg = GetComponent<Rigidbody>();
        rg.freezeRotation = true;
    }

    // Update is called once per frame
    void Update()
    {
        yaw += speedH * Input.GetAxis("Mouse X");
        pitch -= speedV * Input.GetAxis("Mouse Y");

        transform.eulerAngles = new Vector3(pitch, yaw, 0.0f);
        move();
    }

    void move()
    {
        Vector3 totalMovement = Vector3.zero;

        if (Input.GetKey(KeyCode.W))
        {
            totalMovement += transform.forward;
        }
        if (Input.GetKey(KeyCode.A))
        {
            totalMovement -= transform.right;
        }
        if (Input.GetKey(KeyCode.D))
        {
            totalMovement += transform.right;
        }
        if (Input.GetKey(KeyCode.S))
        {
            totalMovement -= transform.forward;
        }

        // To ensure same speed on the diagonal, we ensure its magnitude here instead of earlier
        rg.MovePosition(transform.position + totalMovement.normalized * speed * Time.deltaTime);
    }
}
