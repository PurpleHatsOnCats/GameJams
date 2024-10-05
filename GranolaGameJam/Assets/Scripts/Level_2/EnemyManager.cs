using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyManager : MonoBehaviour
{
    private enum MommyStates
    {
        gone,
        present,
        aboutToAttack,
        attacking
    }

    [SerializeField]
    private List<GameObject> mommyLocations;
    private SpriteRenderer activeMommySprite;
   private MommyStates mommyStates;

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
        if (mommyStates == MommyStates.gone && timer > timeInBetweenAttacks)
        {
            //selects the window, closet or door Mommy randomly
            activeMommySprite = mommyLocations[Random.Range(0, 3)].GetComponent<SpriteRenderer>();

            //Mommy is in location sprite
            activeMommySprite.color = Color.blue;
            mommyStates = MommyStates.present;
        }
        else if(mommyStates == MommyStates.present && timer > timeInBetweenAttacks + 3)
        {
            //Mommy sprite for when she is about to attack
            activeMommySprite.color = Color.yellow;
            mommyStates = MommyStates.aboutToAttack;
        }
        else if(mommyStates == MommyStates.aboutToAttack && timer > timeInBetweenAttacks + 4)
        {
            //Mommy sprite is attacking
            activeMommySprite.color = Color.red;
            mommyStates = MommyStates.attacking;

        }
        else if(timer > timeInBetweenAttacks + 5)
        {
            //Mommy goes back to normal
            activeMommySprite.color = Color.white;
            mommyStates = MommyStates.gone;

            timer = 0;

            //increases the speed of mommy attacks
            if(timeInBetweenAttacks > 3)
            {
                timeInBetweenAttacks--;
            }
        }

    }


}
