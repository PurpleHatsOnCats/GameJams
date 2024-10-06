using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{
    public SpriteRenderer Healthbar;
    public SpriteRenderer StickIcon;
    public SpriteRenderer RockIcon;
    public GameObject Player;

    public Sprite[] HealthBars;

    
    public float Health
    {
        set
        {
            _health = (int)Mathf.Min(3, value);
            if(_health < 0)
            {
                _health = 0;
            }
        }
    }
    private int _health;
    private bool StickUnlocked;
    private bool RockUnlocked;

    public void Start()
    {
        StickIcon.enabled = false;
        RockIcon.enabled = false;
    }


    // Update is called once per frame
    void Update()
    {
        Health = Player.GetComponent<CharacterHealth>().Health;

        Healthbar.sprite = HealthBars[_health];
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
                StickIcon.enabled = true;
                break;
            case 2:
                RockUnlocked = true;
                RockIcon.enabled = true;
                break;
            default:
                Debug.Log("Not a valid weapon");
                break;
        }
    }
}
