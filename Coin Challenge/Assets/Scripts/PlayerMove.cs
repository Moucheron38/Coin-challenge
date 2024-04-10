using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{

    [SerializeField] float forwardSpeed = 1;
    [SerializeField] float strafeSpeed = 1;
    [SerializeField] Camera cam;
    [SerializeField] Animator animator;
    private float dampRotationSpeed;
    private float camAlignSpeed = 0.05f;
    public Rigidbody rb;
    public bool isOnTheGround = true;
    Vector3 inputDir = Vector3.zero;



   

    void Update()
    {
        inputDir.Set(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        inputDir = inputDir.normalized;

        if (Input.GetButtonDown("Jump") && isOnTheGround)
        {
            rb.AddForce(new Vector3(0, 5, 0), ForceMode.Impulse);
            isOnTheGround = false;
        }
            
    }

    private void FixedUpdate()
    {
        if (inputDir.magnitude > 0.1f) Move();
        UpdateAnimation(inputDir);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ground") isOnTheGround = true;
    }

    private void Move()
    {
        //Calculer la direction Forward
        Vector3 forwardDir = transform.forward * inputDir.z;
        forwardDir.Normalize();
        forwardDir *= forwardSpeed;

        //Calculer le strafe
        Vector3 strafeDir = Vector3.Cross(Vector3.up, transform.forward) * inputDir.x;
        strafeDir.Normalize();
        strafeDir *= strafeSpeed;

        // Combine les deux Vecteurs
        Vector3 finalDir = forwardDir + strafeDir;


        rb.MovePosition(transform.position + (finalDir * Time.deltaTime));

        //Rotate Player to Camera Direction
        float targetRotation = cam.transform.eulerAngles.y;
        float playerAngleDamp = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetRotation, ref dampRotationSpeed, camAlignSpeed);
        transform.rotation = Quaternion.Euler(0, playerAngleDamp, 0);
        
    }

    void UpdateAnimation(Vector3 dir)
    {
        animator.SetFloat("ForwardSpeed", dir.z);
        animator.SetFloat("StrafeSpeed", dir.x);
    }

    

}
