using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public float MoveSpeed = 3;
    public FaceDirection Direction;
    private bool _frozen;
    private Vector2 _lastVelocity;

    public void Move(FaceDirection direction)
    {
        if (direction != FaceDirection.Stop) 
        {
            Direction = direction;
        }

        GetComponent<Rigidbody2D>().velocity = GameDictionary.moveDirections[direction] * MoveSpeed;
        
    }
    /// <summary>
    /// Freezes movement
    /// </summary>
    /// <param name="frozen"></param>
    public void Freeze(bool frozen)
    {
        _frozen = frozen;
        GetComponent<Rigidbody2D>().isKinematic = _frozen;
        GetComponent<BoxCollider2D>().enabled = frozen;
        if (_frozen)
        {
            _lastVelocity = GetComponent<Rigidbody2D>().velocity;
        }
        else
        {
            GetComponent<Rigidbody2D>().velocity = _lastVelocity;
        }
    }
}

