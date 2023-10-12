using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControll : MonoBehaviour
{
    //Create a public reference to the player - we will assign this useing the Unity editor
    public GameObject player;

    // Update is called once per frame
    void Update()
    {
        //Change our position relative to the players position
        transform.position = new Vector3(player.transform.position.x, transform.position.y, transform.position.z);
    }
}
