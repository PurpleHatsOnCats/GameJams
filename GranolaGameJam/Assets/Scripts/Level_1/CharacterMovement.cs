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
    [HideInInspector]
    public float StunTime;
    private float _stunDistanceLeft;
    private Vector2 _lastPosition;

    public void Start()
    {
        _animator = GetComponent<Animator>();
        if (_animator != null)
        {
            _animator.SetFloat("XInput", GameDictionary.moveDirections[Direction].x);
            _animator.SetFloat("YInput", GameDictionary.moveDirections[Direction].y);
        }
    }
            
    public void Update()
    {
        if(StunTime > 0)
        {
            if(StunTime % 0.4f > 0.2f)
            {
                Color color = GetComponent<SpriteRenderer>().color;
                color.a = 0.5f;
                GetComponent<SpriteRenderer>().color = color;
            }
            else
            {
                Color color = GetComponent<SpriteRenderer>().color;
                color.a = 1f;
                GetComponent<SpriteRenderer>().color = color;
            }

            StunTime -= Time.deltaTime;
            if (_stunDistanceLeft > 0)
            {
                _stunDistanceLeft -= (_lastPosition - (Vector2)transform.position).magnitude;
                _lastPosition = transform.position;
            }
            else if (_stunDistanceLeft <= 0 && gameObject.tag != "Player")
            {
                GetComponent<Rigidbody2D>().velocity = Vector3.zero;
            }
        }
        else if(StunTime < 0)
        {
            StunTime = 0;
            _stunDistanceLeft = 0;

            Color color = GetComponent<SpriteRenderer>().color;
            color.a = 1f;
            GetComponent<SpriteRenderer>().color = color;
        }
    }

    public void Move(FaceDirection direction)
    {
        if (!_movementFrozen)
        {
            if (direction != FaceDirection.Stop)
            {
                Direction = direction;
                GetComponent<SpriteRenderer>().flipX = direction == FaceDirection.Right;
                
                if (_animator != null)
                {
                    _animator.SetFloat("XInput", GameDictionary.moveDirections[direction].x);
                    _animator.SetFloat("YInput", GameDictionary.moveDirections[direction].y);
                    _animator.SetTrigger("TrWalk");
                }
            }
            GetComponent<Rigidbody2D>().velocity = GameDictionary.moveDirections[direction] * MoveSpeed;
        }
        if (_animator != null)
        {
            _animator.SetFloat("Speed", GetComponent<Rigidbody2D>().velocity.magnitude);
        }
    }
    /// <summary>
    /// Freezes movement
    /// </summary>
    /// <param name="frozen"></param>
    public void Freeze(bool frozen)
    {
        _frozen = frozen;
        GetComponent<BoxCollider2D>().enabled = !_frozen;
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
    public void RecieveKnockback(Vector2 velocity, float distance, float time)
    {
        GetComponent<Rigidbody2D>().velocity = velocity;
        StunTime = time;
        _stunDistanceLeft = distance;
    }
}

