using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuddleController : MonoBehaviour
{
    //variable to determine what kind of puddle
    //collision(trigger) to restart the game.
    //  collisions is based on whoever is able to walk in it 

    //fields
    //variables to determine the kind of puddles there are.
    string waterPuddle = "waterTile";
    string lavaPuddle = "lavaTile";


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void OnCollisionEnter2D(Collision2D collision)
    {
        //determine if the collision is with the right player.
    }
}
