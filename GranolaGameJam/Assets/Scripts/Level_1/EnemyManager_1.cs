using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager_1 : MonoBehaviour
{
    public GameObject[] enemies;

    public void FreezeAll(bool frozen)
    {
        for(int i = 0; i < enemies.Length; i++)
        {
            enemies[i].GetComponent<EnemyController>().Freeze(frozen);
        }
    }
}
