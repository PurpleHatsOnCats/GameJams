using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public static class GameDictionary
{
    public static CameraManager camera = Camera.main.GetComponent<CameraManager>();
    public static Dictionary<FaceDirection, Vector2> moveDirections = new Dictionary<FaceDirection, Vector2>
    {
        { FaceDirection.Right, new Vector2(1,0)},
        { FaceDirection.Up, new Vector2(0,1)},
        { FaceDirection.Left, new Vector2(-1,0)},
        { FaceDirection.Down, new Vector2(0,-1)},
        { FaceDirection.Stop, new Vector2(0,0)}
    };
    public static bool InGameArea(Vector2 position)
    {
        Debug.Log("Rectangle: " + new Rect(camera.CurrentArea * camera.LevelSize - camera.LevelSize / 2, camera.LevelSize));
        return new Rect(camera.CurrentArea * camera.LevelSize - camera.LevelSize/2, camera.LevelSize).Contains(position);
    }
}
public enum FaceDirection
{
    Right = 1,
    Up = 2,
    Left = 3,
    Down = 4,
    Stop = 0
}
[Serializable]
public class IntEvent : UnityEvent<int>
{

}
[Serializable]
public class DirectionEvent : UnityEvent<FaceDirection>
{

}