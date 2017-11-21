using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnTombs : MonoBehaviour {

    [SerializeField]
    private GameObject original;

    private GameObject clone;

    void LateUpdate()
    {
        if (Time.fixedTime % 2 == 1)
        {
            clone = (Instantiate(original, transform.position, Quaternion.identity) as GameObject);
        }
    }

}
