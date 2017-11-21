using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour {

    [SerializeField]
    private LayerMask whatBeGround; //Define what layers will be considered ground. Select Options
    [SerializeField]
    private Transform groundCheck; //Define where in what position to check ground. DragEmpty Object

    private  static Rigidbody2D rBody; //To access character RigidBody Properties
    private  static Animator anim; //To access variable we'll need in animation
    
    private bool jump; //For if Jump button is used
    private bool walk; //For if Walk button is used
    private bool attack;
    private bool run;
    private bool facingRight = true;

    [SerializeField]
    private bool grounded = false;//To check if on ground. Initially false

    private float direction; //Get + or - signum depending if the negative or positive button is used
    private float maxSpeed = 3; //Max velocity speed

    private float groundRadius = 0.25f;


	// Use this for initialization
	void Awake ()
    {
        rBody = GetComponent<Rigidbody2D>(); // Initialize rBody and access the 2D Rigidbody properties.
        anim = GetComponent<Animator>();
	}

    // Update for Physics
    private void Update()
    {
        grounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatBeGround); //Create a circle collider (where to check, radius of circle, what layer) Returns true or false if colliding with another object. 
        anim.SetBool("Ground", grounded);//Set the varible Ground to the results of grounded

        WalkRun();
        Jump();
        Attack();

    }



    private void WalkRun()
    {
        walk = Input.GetButton("Horizontal"); //If walk button is held
        run = Input.GetButton("Run"); //If run button is held
        direction = Input.GetAxis("Horizontal") * maxSpeed; //Get the direction and multiply speed to that direction

        anim.SetBool("Running", false);//Reset the Run animation

        if (walk)
        {
            rBody.velocity = new Vector3(direction, rBody.velocity.y, 0); //Walk Character by changing velocity (xVelocity, current yVelocity, 0)
            anim.SetBool("Walking", true); //Set animation to walking

            if (run)
            {
                rBody.velocity = new Vector3(direction * 2, rBody.velocity.y, 0); //Increase x.velocity
                anim.SetBool("Running", true); //Set animation to Running
            }
        }
        else
        {
            anim.SetBool("Walking", false); //Set animation to false thus to Idle
            anim.SetBool("Running", false);
        }


        Flip(direction); //Flipe Player according to the Horizontal axis


    }

    private void Jump()
    {
        jump = Input.GetButtonDown("Vertical"); //If walk button is held. Vertical to use "up" and "down" keys

        if (grounded && jump)
        {
            rBody.velocity = new Vector3(rBody.velocity.x, (maxSpeed * 2.5f), 0); //Jump Character (current xVelocity, yVelocity, 0)
            anim.SetBool("Jumping", true);
        }
        else
        {
            anim.SetBool("Jumping", false);
        }

    }

    private void Attack()
    {
        attack = Input.GetButton("Fire1");

        if (attack)
            anim.SetBool("Attacking", true);
        else
            anim.SetBool("Attacking", false);
    }

    private void Flip(float xVelocity)
    {
        if (xVelocity > 0 && !facingRight)
        {
            facingRight = true; //current bool = opposite bool
            Vector3 theScale = transform.localScale;
            theScale.x *= -1;
            transform.localScale = theScale;
        }
       else if (xVelocity < 0 && facingRight)
        {
            facingRight = false; //current bool = opposite bool
            Vector3 theScale = transform.localScale;
            theScale.x *= -1;
            transform.localScale = theScale;
        }
    }
}
