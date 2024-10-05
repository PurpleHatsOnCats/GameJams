using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileController : MonoBehaviour
{
    [HideInInspector]
    public float Damage;
    [HideInInspector]
    public bool PlayerFriendly;
    [HideInInspector]
    public float MaxDistance;

    private float _distanceTraveled;
    private Vector2 _lastPosition;

    private void Update()
    {
        Vector2 currentPosition = transform.position;
        _distanceTraveled += (currentPosition - _lastPosition).magnitude;

        if(_distanceTraveled > MaxDistance) // NOTE: this does not extrapolate, so it can technically go beyond the max distance
        {
            Destroy(gameObject);
        }

        _lastPosition = transform.position;
    }

    /// <summary>
    /// Set initial velocity and variables
    /// </summary>
    /// <param name="speed"></param>
    /// <param name="direction"></param>
    /// <param name="damage"></param>
    /// <param name="playerFriendly"></param>
    public void Initiate(float speed, FaceDirection direction, float damage, float distance, bool playerFriendly)
    {
        gameObject.GetComponent<CharacterMovement>().MoveSpeed = speed;
        gameObject.GetComponent<CharacterMovement>().Move(direction);

        Damage = damage;
        PlayerFriendly = playerFriendly;
        MaxDistance = distance;

        _lastPosition = transform.position;

    }
    /// <summary>
    /// Destroys object and damages character when collided 
    /// </summary>
    /// <param name="collision"></param>
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Enemy" && PlayerFriendly)
        {
            collision.gameObject.GetComponent<CharacterHealth>().TakeDamage(Damage);
            Destroy(gameObject);
        }
        else if (collision.gameObject.tag == "Player" && !PlayerFriendly)
        {
            collision.gameObject.GetComponent<CharacterHealth>().TakeDamage(Damage);
            Destroy(gameObject);
        }
        else if (collision.gameObject.tag == "Wall")
        {
            Destroy(gameObject);
        }
    }

}
