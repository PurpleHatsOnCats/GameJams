using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public float MoveSpeed;

    public void Move(Vector2 direction)
    {
        GetComponent<Rigidbody2D>().velocity = direction * MoveSpeed;
    }
}
