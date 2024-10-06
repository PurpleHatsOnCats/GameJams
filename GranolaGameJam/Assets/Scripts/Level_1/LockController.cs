using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockController : MonoBehaviour
{
    public int KeysNeeded;
    public int CurrentKeys;

    /// <summary>
    /// Increments lock progress
    /// </summary>
    public void Unlock()
    {
        CurrentKeys++;
        if(CurrentKeys >= KeysNeeded)
        {
            Destroy(gameObject);
        }
    }
}
