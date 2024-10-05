using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAttack : MonoBehaviour
{
    public GameObject ProjectilePrefab;
    public GameObject MeleePrefab;

    public float ProjectileDamage;

    public void ProjectileAttack()
    {
        GameObject projectile = Instantiate(ProjectilePrefab, transform.position, new Quaternion());
        projectile.GetComponent<ProjectileController>().Initiate(
            3, 
            gameObject.GetComponent<CharacterMovement>().Direction, 
            1,
            gameObject.tag == "Player");
    }
}
