using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemyController : MonoBehaviour
{
    public EnemyType Type;

    public UnityEvent Attack;
    public DirectionEvent Move;

    private bool _frozen;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<CharacterMovement>().Move(FaceDirection.Stop);
    }
    /// <summary>
    /// Freeze movement and projectiles, stops AI
    /// </summary>
    /// <param name="frozen"></param>
    public void Freeze(bool frozen)
    {
        GetComponent<CharacterMovement>().Freeze(frozen);
        GetComponent<CharacterAttack>().FreezeProjectiles(frozen);
    }
}

public enum EnemyType
{
    Melee,
    Ranged,
    Boss
}
