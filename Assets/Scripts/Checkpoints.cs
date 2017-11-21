using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Checkpoints : MonoBehaviour {

    [SerializeField]
    private Transform respawner;

    [SerializeField]
    private Transform cameraRespawn;

    [SerializeField]
    private Score score;

    private static Vector3 respawnPoint;
    private bool checkPointReached;

    private static int oldScore;

    private void Awake()
    {
        cameraRespawn.position = respawnPoint;
        score.setScore(oldScore);
        respawner.position = respawnPoint;
    }


    //Restart at last checkpoint with old info
    private void LateUpdate()
    {
        if (Input.GetKeyDown("r"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    //Get all needed info at arriving at checkpoint
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player" && checkPointReached == false)
        {
            checkPointReached = true;

            respawnPoint = transform.position;
            oldScore = score.getScore();

        }
    }

    public void nextLevelReset(Vector3 newOrigin)
    {
        respawnPoint = newOrigin;
        oldScore = score.getScore();
    }

}
