using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemyController : MonoBehaviour
{
    public UnityEvent Attack;
    public UnityEvent Move;

    private bool _frozen;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
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
