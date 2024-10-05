using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollision : MonoBehaviour
{
    public float PhysicalDamage = 1;

    /// <summary>
    /// Destroys object and damages character when collided 
    /// </summary>
    /// <param name="collision"></param>
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<CharacterHealth>().TakeDamage(PhysicalDamage);
        }
    }
}
