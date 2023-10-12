using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    //Create a public array of objects to spawn, we will fill this up useing the unity editor
    public GameObject[] objectsToSpawn;

    float timeToNextSpawn; //Tracks the time since we last spawned something
    float timeSinceLastSpawn = 0.0f; //tracks the time since we last spawned something

    public float minSpawnTime = 0.5f; //minimum amount of time between spawning objects
    public float maxSpawnTime = 3.0f; //maximum amount of time between spawning objects

    void Start()
    {
        //Random.Range returns a random float between two values
        timeToNextSpawn = Random.Range(minSpawnTime, maxSpawnTime);
    }

    void Update()
    {
        //add Time.delataTime returns the amount of time passed since the last frame.
        //this will create a float that counts up in seconds
        timeSinceLastSpawn = timeToNextSpawn + Time.deltaTime;

        //if we've counted past the amount of time weve needed to wait...
        if (timeSinceLastSpawn > timeToNextSpawn)
        {
            //use random.range to pick a number between 0 and the ammount of items on our object list
            int selection = Random.Range(0, objectsToSpawn.Length);

            //initiate spawns a GameObject - in this case we tell it to spawn a GameObject from our ObjectsToSpawn list
            //The second peramater in the brackets tells it where to spawn, so we've entered the position of the spawner.
            //The third parameter is for rotation, and Quaternion.identity means no rotation
            Instantiate(objectsToSpawn[selection], transform.position, Quaternion.identity);

            //after spawning, we select s new random time for the next spawn and set our timer back to zero
            timeToNextSpawn = Random.Range(minSpawnTime, maxSpawnTime);
            timeSinceLastSpawn = 0.0f;
        }
    }
}
