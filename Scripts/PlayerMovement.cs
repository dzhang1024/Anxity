using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Threading;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Rigidbody2D rb; 
    Vector2 movement;
    Vector2 mousePos;
    public Transform firePoint; 
    public Animator animate;
    public Camera cam; 
    // Update is called once per frame
    void Update()
    {
        //Input updates here 
        
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        animate.SetFloat("Horizontal", movement.x);
        animate.SetFloat("Vertical", movement.y);
        animate.SetFloat("Speed", movement.sqrMagnitude);
        

        if (Input.GetAxisRaw("Horizontal") == 1 || Input.GetAxisRaw("Horizontal") == -1 || Input.GetAxisRaw("Vertical") == 1 || Input.GetAxisRaw("Vertical") == -1)
        {
            animate.SetFloat("LastMoveX", Input.GetAxisRaw("Horizontal"));
            animate.SetFloat("LastMoveY", Input.GetAxisRaw("Vertical"));
            firePoint.position = rb.position + movement; 
        }
        if (Input.GetAxisRaw("Horizontal") == 1)
        {
            firePoint.rotation = Quaternion.Euler(0, 0, -90f); ;
        }
        else if (Input.GetAxisRaw("Horizontal") == -1)
        {
            firePoint.rotation = Quaternion.Euler(0, 0, 90f); ;
        }
        else if (Input.GetAxisRaw("Vertical") == 1)
        {
            firePoint.rotation = Quaternion.Euler(0, 0, 360); ;
        }
        else if (Input.GetAxisRaw("Vertical") == -1)
        {
            firePoint.rotation = Quaternion.Euler(0, 0, 180f); ;
        }
    }

    void FixedUpdate()
    {
        //Movement updates here 
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        //Vector2 lookDirection = mousePos - rb.position;
        //float angle = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg - 90f;
        //rb.rotation = angle; 
    }

}
