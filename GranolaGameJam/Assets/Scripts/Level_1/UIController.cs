using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{
    private float Health;
    private bool StickUnlocked;
    private bool RockUnlocked;

    // Update is called once per frame
    void Update()
    {
        
    }
    /// <summary>
    /// Unlocks a specific weapon
    /// </summary>
    /// <param name="identifier"></param>
    public void UnlockWeapon(int identifier)
    {
        switch (identifier)
        {
            case 1:
                StickUnlocked = true;
                break;
            case 2:
                RockUnlocked = true;
                break;
            default:
                Debug.Log("Not a valid weapon");
                break;
        }
    }
}
