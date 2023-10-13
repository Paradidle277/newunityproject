using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject groundChecker;
    public LayerMask whatIsGround;
    public float jumpForce;
    Animator anim;

    float maxSpeed = 8.0f;
    bool isOnGround = false;

    //create reference to rigidBody2D so we can manipulate it
    Rigidbody2D playerObject;
    // Start is called before the first frame update
    void Start()
    {
        playerObject = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //create a 'float' that will be equal to the players input
        //float movementValueX = Input.GetAxis("Horizontal");
        float movementValueX = 1.0f;

        //Change the Xvelocity of the rigidBody2D to be equal to the movement value
        playerObject.velocity = new Vector2(movementValueX * maxSpeed, playerObject.velocity.y);

        //Check to see if the ground check object is touching the ground
        isOnGround = Physics2D.OverlapCircle(groundChecker.transform.position, 1.0f, whatIsGround);

        {
            if (Input.GetKey(KeyCode.LeftShift))
            {
                maxSpeed = 10.0f;
            }
            else
            {
                maxSpeed = 5.0f;
            }

            //create a 'float' tht will be equal to the players horizontal input
            //float movementValueX = Input.GetAxis("Horizontal");

            //Set movementValueX to 1.0f, so that we always run foreward and no longer care about player input

            if ((isOnGround == true) && (Input.GetAxis("Jump") > 0.0f))
            {
                playerObject.AddForce(Vector2.up * jumpForce);
                anim.SetBool("IsOnGround", false);
            }
            Animator anim;

            void Start()
            {
                anim = GetComponent<Animator>();
            }

            void Update()
            {
                anim.SetFloat("speed", Mathf.Abs(movementValueX));
                anim.SetBool("IsOnGround", false);
            }
        }
    }

}