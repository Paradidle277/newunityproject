using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    GameObject player; //Reference to the player so we can track its position
    Renderer rend; //Reference to the Renderer so we can modify its texture

    float playerStartPos; //Float used to track the startig position of the player
    public float speed = 0.5f; //how fast to scroll change for each layer

    private void Start()
    {
        player = GameObject.Find("Player");
        rend = GetComponent<Renderer>();
        playerStartPos = (player.transform.position.x - playerStartPos) * speed;

        rend.material.SetTextureOffset("_MainText", new Vector2(offset, 0f));
    }
}
