using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CharacterHealth : MonoBehaviour
{
    public float Health;

    private float P_Health
    {
        get
        {
            return Health;
        }
        set
        {
            Health = value;
            if(Health <= 0)
            {

                if (gameObject.tag == "Player")
                {
                    // TODO: restart level
                }
                else
                {
                    Destroy(gameObject);
                }
            }
        }
    }

    /// <summary>
    /// Decreases health by a specified amount
    /// </summary>
    /// <param name="amount"></param>
    public void TakeDamage(float amount)
    {
        P_Health -= amount;
    }
}
