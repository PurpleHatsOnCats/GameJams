using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public float MoveSpeed = 3;
    public FaceDirection Direction;

    public void Move(FaceDirection direction)
    {
        if (direction != FaceDirection.Stop) 
        {
            Direction = direction;
            Debug.Log("Move Method Called"); 
        }

        GetComponent<Rigidbody2D>().velocity = GameDictionary.moveDirections[direction] * MoveSpeed;
        
    }
}

