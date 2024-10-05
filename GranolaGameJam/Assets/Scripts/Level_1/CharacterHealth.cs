using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CharacterHealth : MonoBehaviour
{
    public float Health;

    /// <summary>
    /// Decreases health by a specified amount
    /// </summary>
    /// <param name="amount"></param>
    public void TakeDamage(float amount)
    {
        Health -= amount;
    }
}
