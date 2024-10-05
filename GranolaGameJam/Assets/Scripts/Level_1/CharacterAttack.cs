using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAttack : MonoBehaviour
{
    public GameObject ProjectilePrefab;
    public GameObject MeleePrefab;

    public float ProjectileDamage = 1;
    public float MeleeDamage = 2;

    /// <summary>
    /// Create a projectile object that moves the direction the player is facing
    /// </summary>
    public void ProjectileAttack()
    {
        GameObject projectileObject = Instantiate(ProjectilePrefab, transform.position, new Quaternion());
        projectileObject.GetComponent<ProjectileController>().Initiate(
            3, // speed
            gameObject.GetComponent<CharacterMovement>().Direction, 
            ProjectileDamage,
            4, // distance
            gameObject.tag == "Player");
    }
    /// <summary>
    /// Create a melee object that moves the direction the player is facing
    /// </summary>
    public void MeleeAttack()
    {
        GameObject meleeObject = Instantiate(MeleePrefab, transform.position, new Quaternion());
        meleeObject.GetComponent<ProjectileController>().Initiate(
            3, // speed
            gameObject.GetComponent<CharacterMovement>().Direction,
            MeleeDamage,
            2, // distance
            gameObject.tag == "Player");
    }
}
