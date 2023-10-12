using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyerclass : MonoBehaviour
{
    //like start() and update() methods, onTrigerEnter2D is a unity method is called by unity automatically at a specific point - in this case, when something enters the trigger attatched to this game object
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //if Game object has collided with trigger, trigger is tagged with cleanup
        if (collision.gameObject.tag == "CleanUp")
        {
            //then we can use this method to destroy it
            Destroy(collision.gameObject);
        }
    }
}
