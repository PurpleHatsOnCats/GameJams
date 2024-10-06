using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CharacterHealth : MonoBehaviour
{
    public float Health;

    private float _redTimer;
    public float P_Health
    {
        get
        {
            return Health;
        }
        set
        {
            Health = value;
            if(Health <= 0)
            {

                if (gameObject.tag == "Player")
                {
                    // TODO: restart level
                }
                else
                {
                    Destroy(gameObject);
                }
            }
        }
    }

    public void Update()
    {
        if(_redTimer > 0)
        {
            _redTimer -= Time.deltaTime;
        }
        else if(_redTimer < 0)
        {
            _redTimer = 0;
            Color color = GetComponent<SpriteRenderer>().color;
            color = new Color(1, 1, 1);
            GetComponent<SpriteRenderer>().color = color;
        }
    }
    /// <summary>
    /// Decreases health by a specified amount
    /// </summary>
    /// <param name="amount"></param>
    public void TakeDamage(float amount)
    {
        P_Health -= amount;
        if(gameObject.tag == "Player")
        {
            GetComponent<CharacterMovement>().StunTime = 1.5f;
        }
        
        _redTimer = 0.3f;
        Color color = GetComponent<SpriteRenderer>().color;
        color = new Color(1, 0.7f, 0.7f);
        GetComponent<SpriteRenderer>().color = color;
        
    }
}
