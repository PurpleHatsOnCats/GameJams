using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement_3 : MonoBehaviour
{

    //information for jumping
    Vector3 leapDirection = new Vector3(0,0,0);
    float jumpForce = 200f;

    float speed = 3f;

    bool hasJump;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        SideMovements();
    }

    /// <summary>
    /// Move left and right if a specific key is pressed.
    /// </summary>
    public void SideMovements()
    {
        //position and direction
        Vector3 playerPosition = gameObject.transform.position;
        Vector3 playerDirection = Vector3.zero;
        
        //Right movement
        if (Input.GetKey(KeyCode.D))
        {
            //change direction
            playerDirection = new Vector3(1,0,0);

        }
        //left movement
        else if (Input.GetKey(KeyCode.A))
        {
            playerDirection = new Vector3(-1, 0, 0);
        }

        //velocity
        Vector3 velocity = playerDirection * speed;
        velocity *= Time.deltaTime;
        playerPosition += velocity;

        //set to character
        gameObject.transform.position = playerPosition;
    }


    /// <summary>
    /// move the character in a upwards direction
    /// </summary>
    public void Jump()
    {
        if (hasJump) 
        {
            leapDirection.y += 2;

            Vector3 jumpVelocity = leapDirection.normalized * jumpForce;

            gameObject.GetComponent<Rigidbody2D>().AddForce(jumpVelocity);

            leapDirection.y = 0;
            hasJump = false;
        }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground" && collision.gameObject.transform.position.y < gameObject.transform.position.y)
        {
            hasJump = true;
        }
    }
}
