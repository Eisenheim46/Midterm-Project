using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class DamageControls : MonoBehaviour {

    [SerializeField]
    private Animator anim;
    [SerializeField]
    private Text damageText;

    private static int damage = 5;

    public bool hitOnce = false;
    public bool isDead = false;


    private void Start()
    {
        hitOnce = false;
        isDead = false;
    }

    private void Update()
    {
        if (Time.fixedTime % 3 == 1 && isDead == true)
        {
            damage = 5;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player" && hitOnce == false)
        {
            damage -= 1;
            

            if (damage <= 0)
            {
                damage = 0;
                anim.SetBool("Dead", true);
                isDead = true;
            }

            damageText.text = "Health: " + damage;
            hitOnce = true;
        }
        else
        {
            hitOnce = true;
        }
    }
}
