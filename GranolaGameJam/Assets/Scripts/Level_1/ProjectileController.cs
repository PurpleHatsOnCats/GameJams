using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileController : MonoBehaviour
{
    public float damage;
    public bool playerFriendly;

    /// <summary>
    /// Set initial velocity and variables
    /// </summary>
    /// <param name="speed"></param>
    /// <param name="direction"></param>
    /// <param name="damage"></param>
    /// <param name="playerFriendly"></param>
    public void Initiate(float speed, FaceDirection direction, float damage, bool playerFriendly)
    {
        GetComponent<Rigidbody2D>().velocity = speed * GameDictionary.moveDirections[direction];
        this.damage = damage;
        this.playerFriendly = playerFriendly;
    }
    /// <summary>
    /// Destroys object and damages character when collided 
    /// </summary>
    /// <param name="collision"></param>
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Enemy" && playerFriendly)
        {
            collision.gameObject.GetComponent<CharacterHealth>().TakeDamage(damage);
        }
        else if (collision.gameObject.tag == "Player" && !playerFriendly)
        {
            collision.gameObject.GetComponent<CharacterHealth>().TakeDamage(damage);
        }
        Destroy(gameObject);
    }
}
