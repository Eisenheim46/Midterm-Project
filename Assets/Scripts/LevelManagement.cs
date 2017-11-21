using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class LevelManagement : MonoBehaviour {

    [SerializeField]
    private int nextSceneIndex;

    [SerializeField]
    private Checkpoints reset;

    [SerializeField]
    private Vector3 nextOrigin;


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            reset.nextLevelReset(nextOrigin);
            SceneManager.LoadScene(nextSceneIndex);
        }
    }


}
