using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Camera targetCamera;
    Animator animator;
    private Rigidbody rg;
    public float speed = 10.0f;

    // Start is called before the first frame update
    void Start()
    {
        rg = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        rg.freezeRotation = true;
    }

    // Update is called once per frame
    void Update()
    {
        transform.rotation = Quaternion.Euler(transform.eulerAngles.x, targetCamera.transform.eulerAngles.y, transform.eulerAngles.z);
        if (!Input.anyKey)
        {
            animator.SetBool("isWalking", false);
        }
    }

    void FixedUpdate()
    {
        move();
    }

    void move()
    {
        float speedMultiplier = 1f;
        Vector3 totalMovement = Vector3.zero;

        if (Input.GetKey(KeyCode.W))
        {
            animator.SetBool("isWalking", true);
            totalMovement += transform.forward;
        }
        if (Input.GetKey(KeyCode.A))
        {
            animator.SetBool("isWalking", true);
            totalMovement -= transform.right;
        }
        if (Input.GetKey(KeyCode.S))
        {
            animator.SetBool("isWalking", true);
            totalMovement -= transform.forward;
        }
        if (Input.GetKey(KeyCode.D))
        {
            animator.SetBool("isWalking", true);
            totalMovement += transform.right;
        }
        if (Input.GetKey(KeyCode.LeftShift))
        {
            animator.SetBool("isRunning", true);
            speedMultiplier = 1.5f;
        }
        else
        {
            animator.SetBool("isRunning", false);
        }

        if (!Input.anyKey)
        {
            animator.SetBool("isWalking", false);
        }

        // To ensure same speed on the diagonal, we ensure its magnitude here instead of earlier
        rg.MovePosition(transform.position + totalMovement.normalized * speed * speedMultiplier * Time.deltaTime);
    }
}
