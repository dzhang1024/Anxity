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
        
        //Makes sure player is facing the direction of the direction he walked in 
        if (Input.GetAxisRaw("Horizontal") == 1 || Input.GetAxisRaw("Horizontal") == -1 || Input.GetAxisRaw("Vertical") == 1 || Input.GetAxisRaw("Vertical") == -1)
        {
            animate.SetFloat("LastMoveX", Input.GetAxisRaw("Horizontal"));
            animate.SetFloat("LastMoveY", Input.GetAxisRaw("Vertical"));
            //makes sure to move the firing point of the weapon to be in front of the player
            //TODO: Even though this is constant it is slightly off the middle 
            firePoint.position = rb.position + movement; 
        }
        /**Rotates the firing point so that when the projectile fires it goes straight in the position
        the player was facing**/
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
    }

}
