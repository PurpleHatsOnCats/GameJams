using UnityEngine;

public class CharacterAttack : MonoBehaviour
{
    public GameObject ProjectilePrefab;
    public Sprite ProjectileSprite;
    public Sprite MeleeSprite;
    
    public float ProjectileDamage = 1;
    public float MeleeDamage = 2;
    public float ProjectileSpeed = 10;
    public float MeleeSpeed = 6;
    public float Cooldown = 0.7f;
    public float ProjectileDistance = 8;
    public float MeleeDistance = 2;

    private GameObject[] _projectiles;
    private float AttackCooldown;
    private Animator _animator;

    public void Start()
    {
        _animator = GetComponent<Animator>();
    }
    private void Update()
    {
        if(AttackCooldown > 0)
        {
            AttackCooldown -= Time.deltaTime;
            GetComponent<CharacterMovement>().FreezeMovement(true);
            if (AttackCooldown <= 0)
            {
                GetComponent<CharacterMovement>().FreezeMovement(false);
            }
        }
        if(AttackCooldown < 0)
        {
            AttackCooldown = 0;
        }
    }

    /// <summary>
    /// Create a projectile object that moves the direction the player is facing
    /// </summary>
    public void ProjectileAttack()
    {
        if(AttackCooldown == 0)
        {
            // Spawn projectile
            GameObject projectileObject = Instantiate(
                ProjectilePrefab, 
                transform.position + (Vector3)GameDictionary.moveDirections[gameObject.GetComponent<CharacterMovement>().Direction]*0.5f, 
                new Quaternion());
            projectileObject.GetComponent<SpriteRenderer>().sprite = ProjectileSprite;
            projectileObject.GetComponent<ProjectileController>().Initiate(
                ProjectileSpeed,
                gameObject.GetComponent<CharacterMovement>().Direction,
                ProjectileDamage,
                ProjectileDistance,
                gameObject.tag == "Player");

            // Set Cooldown
            AttackCooldown = Cooldown;

            if (_animator != null)
            {
                _animator.SetTrigger("TrAttack");
            }  
        }
    }
    /// <summary>
    /// Create a melee object that moves the direction the player is facing
    /// </summary>
    public void MeleeAttack()
    {
        if (AttackCooldown == 0)
        {
            // Spawn projectile
            GameObject meleeObject = Instantiate(
                ProjectilePrefab,
                transform.position + (Vector3)GameDictionary.moveDirections[gameObject.GetComponent<CharacterMovement>().Direction] * 0.5f,
                new Quaternion());
            meleeObject.GetComponent<SpriteRenderer>().sprite = MeleeSprite;
            meleeObject.GetComponent<ProjectileController>().Initiate(
                MeleeSpeed,
                gameObject.GetComponent<CharacterMovement>().Direction,
                MeleeDamage,
                MeleeDistance,
                gameObject.tag == "Player");

            // Set Cooldown
            AttackCooldown = Cooldown;

            if (_animator != null)
            {
                _animator.SetTrigger("TrAttack");
            }
        }
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
