using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public float MoveSpeed;
    public FaceDirection Direction;

    public void Move(FaceDirection direction)
    {
        GetComponent<Rigidbody2D>().velocity = GameDictionary.moveDirections[direction] * MoveSpeed;
        Direction = direction;
    }
}

