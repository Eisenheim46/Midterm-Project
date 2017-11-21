using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//Create a smooth camera tracking of the player
public class CameraControls : MonoBehaviour {

    [SerializeField]
    private Transform player;

    private Vector2 velocity;
    private float ySmoothTime = 0.05f;
    private float xSmoothTime = 0.05f;

	void LateUpdate () //To track after Player has moved. Prevents Character Lagging.
    {
        float Xpos = Mathf.SmoothDamp(transform.position.x, player.transform.position.x + 2, ref velocity.x, xSmoothTime);
        float Ypos = Mathf.SmoothDamp(transform.position.y, player.transform.position.y, ref velocity.y, ySmoothTime);

        transform.position = new Vector3(Xpos, Ypos, -10);
    }
}
