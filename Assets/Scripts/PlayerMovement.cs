using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Speed & movement vars
    [SerializeField] private float speed;    
    private float horizontal, vertical;    

    private Vector2 playerVectMovement;
    private Vector2 destination;

    // Raycast Vars
    [SerializeField] private float distRaycast;
    [SerializeField] private LayerMask layerNotWalkable;

    // GO Components
    private Animator animator;

    // Boolean flags
    private bool walking;

    void Awake()
    {   
        // Set the initial destination
        destination = transform.position;
        walking = false;

        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {          
        HeroMovement();
        HeroAnimation();
    }

    void InputPlayer()
    {
        horizontal = Input.GetAxisRaw("Horizontal"); // GetAxisRaw() Does not get intermediate values between 1 and -1
        vertical = Input.GetAxisRaw("Vertical");
    }

    void HeroMovement()
    {
        if (!walking)
        {
            walking = true;

            //horizontal -1 0 1
            InputPlayer();

            if (horizontal != 0 && !Physics2D.Raycast(transform.position, horizontal * Vector2.right, distRaycast, layerNotWalkable))
            {
                destination = (Vector2)transform.position + (horizontal * Vector2.right); 
            }
            else if (vertical != 0 && !Physics2D.Raycast(transform.position, vertical * Vector2.up, distRaycast, layerNotWalkable))
            {
                destination = (Vector2)transform.position + (vertical * Vector2.up); 
            }
        }
        else
        {
            // 1st Argument : origin
            // 2nd Argument : destination
            // 3rd Argument : Give Distance = Speed * time
            transform.position = Vector2.MoveTowards(transform.position,destination,speed*Time.deltaTime);
            walking = false;
        }
    }

    private void HeroAnimation()
    {
        animator.SetFloat("VelocityX", horizontal);
        animator.SetFloat("VelocityY", vertical);
    }
}
