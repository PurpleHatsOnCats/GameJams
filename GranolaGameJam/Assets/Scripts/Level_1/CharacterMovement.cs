using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public float MoveSpeed = 3;
    public FaceDirection Direction;

    private Animator _animator;
    private bool _frozen;
    private bool _movementFrozen;
    private Vector2 _lastVelocity;

    public void Start()
    {
        _animator = GetComponent<Animator>();
        if(_animator == null)
        {
            Debug.Log("Could not find Animator");
        }
    }

    public void Move(FaceDirection direction)
    {
        if (!_movementFrozen)
        {
            if (direction != FaceDirection.Stop)
            {
                Direction = direction;
                if (_animator != null)
                {
                    _animator.SetInteger("Direction", (int)direction);
                    _animator.SetTrigger("TrWalk");
                }
            }
            GetComponent<Rigidbody2D>().velocity = GameDictionary.moveDirections[direction] * MoveSpeed;
        }
        
    }
    /// <summary>
    /// Freezes movement
    /// </summary>
    /// <param name="frozen"></param>
    public void Freeze(bool frozen)
    {
        _frozen = frozen;
        GetComponent<BoxCollider2D>().enabled = !frozen;
        FreezeMovement(_frozen);
    }
    public void FreezeMovement(bool frozen)
    {
        _movementFrozen = frozen || _frozen;
        if (GetComponent<Rigidbody2D>().isKinematic == frozen)
        {
            if (_movementFrozen)
            {
                _lastVelocity = GetComponent<Rigidbody2D>().velocity;
                GetComponent<Rigidbody2D>().velocity = new Vector2(0,0);
            }
            else
            {
                GetComponent<Rigidbody2D>().velocity = _lastVelocity;
            }
            GetComponent<Rigidbody2D>().isKinematic = !(frozen || _frozen);
        }
    }
}

