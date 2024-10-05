using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyManager : MonoBehaviour
{
    //represents the state the mommy is in
    private enum MommyStates
    {
        gone,
        present,
        aboutToAttack,
        attacking,
        successfulAttack
    }

    [SerializeField]
    private List<GameObject> mommyLocations;
    private SpriteRenderer activeMommySprite;
    private MommyStates mommyStates;

    [SerializeField]
    private PlayerHealth player;

    private float timer = 0;

    //amount of time mommy must wait before attacking again
    private float timeInBetweenAttacks = 5;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        //will check if Mommy was in the previous state for long enough to move on to the next state
        //mommy has arrived
        if (mommyStates == MommyStates.gone && timer > timeInBetweenAttacks)
        {
            //selects the window, closet or door Mommy randomly
            activeMommySprite = mommyLocations[Random.Range(0, 3)].GetComponent<SpriteRenderer>();

            //Mommy is in location sprite
            activeMommySprite.color = Color.blue;
            mommyStates = MommyStates.present;
        }
        //after looking around for 3 seconds she checks closer for the kill
        else if(mommyStates == MommyStates.present && timer > timeInBetweenAttacks + 3)
        {
            //Mommy sprite for when she is about to attack
            activeMommySprite.color = Color.yellow;
            mommyStates = MommyStates.aboutToAttack;
        }
        //she goes in for the kid
        else if(mommyStates == MommyStates.aboutToAttack && timer > timeInBetweenAttacks + 3.5)
        {
            //Mommy sprite is attacking
            activeMommySprite.color = Color.red;
            mommyStates = MommyStates.attacking;

        }
        //when mommy goes in the kid wasn't hiding
        else if(mommyStates == MommyStates.successfulAttack)
        {
            activeMommySprite.color = Color.green;
            timer = 0;

        }
        //after 1.5 seconds of attack mommy is unsuccessful and leaves
        else if(timer > timeInBetweenAttacks + 5)
        {
            //Mommy goes back to normal
            activeMommySprite.color = Color.white;
            mommyStates = MommyStates.gone;

            timer = 0;

            //if mommy hasn't attacked this attack phase she attacks
            
            Attack();
            

            //increases the speed of mommy attacks
            if(timeInBetweenAttacks > 3)
            {
                timeInBetweenAttacks--;
            }
        }

    }

    /// <summary>
    /// Mommy checks if the player is hiding
    /// if they aren't health(a device) is taken
    /// </summary>
    public void Attack()
    {
        if (!player.IsHiding)
        {
            player.Health--;
            mommyStates = MommyStates.successfulAttack;
        }
    }


}
