using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PuddleController : MonoBehaviour
{
    //variable to determine what kind of puddle
    //collision(trigger) to restart the game.
    //  collisions is based on whoever is able to walk in it 

    //fields
    //variables to determine the kind of puddles there are.
    public enum PuddleType
    {
        fire,
        water
    }

    private PuddleType puddleType;

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
        if(collision.gameObject.tag == "Player" && puddleType == PuddleType.water)
        {
            Destroy(gameObject);
            SceneManager.LoadScene("Level_3");
        }
        if(collision.gameObject.tag == "Girlfriend" && puddleType == PuddleType.fire)
        {
            Destroy(gameObject);
            SceneManager.LoadScene("Level_3");
        }

    }
}
