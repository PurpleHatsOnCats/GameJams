using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAttack : MonoBehaviour
{
    public GameObject ProjectilePrefab;
    public Sprite ProjectileSprite;
    public Sprite MeleeSprite;
    
    public float ProjectileDamage = 1;
    public float MeleeDamage = 2;
    public float Speed = 6;
    public float ProjectileDistance = 8;
    public float MeleeDistance = 2;

    private GameObject[] _projectiles;

    /// <summary>
    /// Create a projectile object that moves the direction the player is facing
    /// </summary>
    public void ProjectileAttack()
    {
        Debug.Log("Projectile method called");

        GameObject projectileObject = Instantiate(ProjectilePrefab, transform.position, new Quaternion());
        projectileObject.GetComponent<ProjectileController>().Initiate(
            Speed,
            gameObject.GetComponent<CharacterMovement>().Direction, 
            ProjectileDamage,
            ProjectileDistance, 
            gameObject.tag == "Player");
        projectileObject.GetComponent<SpriteRenderer>().sprite = ProjectileSprite;
    }
    /// <summary>
    /// Create a melee object that moves the direction the player is facing
    /// </summary>
    public void MeleeAttack()
    {
        GameObject meleeObject = Instantiate(ProjectilePrefab, transform.position, new Quaternion());
        meleeObject.GetComponent<ProjectileController>().Initiate(
            Speed,
            gameObject.GetComponent<CharacterMovement>().Direction,
            MeleeDamage,
            MeleeDistance,
            gameObject.tag == "Player");
        meleeObject.GetComponent<SpriteRenderer>().sprite = MeleeSprite;
    }
    /// <summary>
    /// Freezes all projectiles
    /// </summary>
    /// <param name="frozen"></param>
    public void FreezeProjectiles(bool frozen)
    {
        for(int i = 0; i < _projectiles.Length; i++)
        {
            _projectiles[i].GetComponent<CharacterMovement>().Freeze(frozen);
        }
    }
}
