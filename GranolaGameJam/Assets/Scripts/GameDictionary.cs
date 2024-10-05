using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameDictionary
{
    public static Dictionary<FaceDirection, Vector2> moveDirections = new Dictionary<FaceDirection, Vector2>
    {
        { FaceDirection.Right, new Vector2(1,0)},
        { FaceDirection.Up, new Vector2(0,1)},
        { FaceDirection.Left, new Vector2(-1,0)},
        { FaceDirection.Down, new Vector2(0,-1)}
    };
}
public enum FaceDirection
{
    Right,
    Up,
    Left,
    Down
}