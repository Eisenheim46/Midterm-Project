using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Destructables : MonoBehaviour {

    //Manage Collision
    private Animator anim; //To check if player is attacking
    private bool isAttacking;
    
    //Manage Score
    [SerializeField]
    private Text scoreText; //To access the score script to handle score

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        isAttacking = anim.GetBool("Attacking");

        if (collision.gameObject.tag == "Destructable" && isAttacking)
        {
            collision.GetComponent<SpriteRenderer>().enabled = false;
            collision.GetComponent<BoxCollider2D>().enabled = false;

            collision.GetComponent<AudioSource>().Play();
            
            scoreText.GetComponent<Score>().addScore();//add a score of one
            Destroy(collision.gameObject, 4f); //Destroy that game object
        }

    }


}
