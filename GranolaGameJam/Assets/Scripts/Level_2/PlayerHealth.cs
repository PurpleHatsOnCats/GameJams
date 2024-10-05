using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    private bool isHiding = false;

    private SpriteRenderer childSprite;

    [SerializeField]
    private GameObject energyBar;

    [SerializeField]
    private List<Sprite> energyBarSprites;
    private float energyBarDepletion = 0;
    private SpriteRenderer energyBarSprite;

    Animator animator;


    /// <summary>
    /// checks if the child is hiding or not
    /// </summary>
    public bool IsHiding
    {
        get { return isHiding; }
    }

    void Awake()
    {
        energyBarSprite = energyBar.GetComponent<SpriteRenderer>();
        childSprite = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //hiding and depleting energy can only happen if there are still energy pips remaining
        if(energyBarDepletion !> 150)
        {
            HandleHiding();
            LoseEnergy();
            animator.SetBool("IsHiding", isHiding);
        }
        else
        {
            //you lose
            energyBarSprite.sprite = energyBarSprites[14];
            SceneManager.LoadScene("Level_2");

        }



    }

    /// <summary>
    /// appropriately adjusts the energy bar sprite to reflect remaining energy
    /// </summary>
    public void LoseEnergy()
    {
        if(energyBarDepletion < 10)
        {
            energyBarSprite.sprite = energyBarSprites[1];
        }
        else if(energyBarDepletion < 20)
        {
            energyBarSprite.sprite = energyBarSprites[2];
        }
        else if (energyBarDepletion < 30)
        {
            energyBarSprite.sprite = energyBarSprites[3];

        }
        else if (energyBarDepletion < 40)
        {
            energyBarSprite.sprite = energyBarSprites[4];

        }
        else if (energyBarDepletion < 51)
        {
            energyBarSprite.sprite = energyBarSprites[5];

        }
        else if (energyBarDepletion < 62)
        {
            energyBarSprite.sprite = energyBarSprites[6];

        }
        else if (energyBarDepletion < 73)
        {
            energyBarSprite.sprite = energyBarSprites[7];
        }
        else if (energyBarDepletion < 84)
        {
            energyBarSprite.sprite = energyBarSprites[8];
        }
        else if (energyBarDepletion < 95)
        {
            energyBarSprite.sprite = energyBarSprites[9];

        }
        else if (energyBarDepletion < 106)
        {
            energyBarSprite.sprite = energyBarSprites[10];

        }
        else if (energyBarDepletion < 117)
        {
            energyBarSprite.sprite = energyBarSprites[11];
        }
        else if (energyBarDepletion < 128)
        {
            energyBarSprite.sprite = energyBarSprites[12];

        }
        else if (energyBarDepletion < 139)
        {
            energyBarSprite.sprite = energyBarSprites[13];
        }

    }

    /// <summary>
    /// mommy successfully catches the child
    /// </summary>
    public void Caught()
    {
        energyBarDepletion += 45;
    }

    /// <summary>
    /// checks if the space bar is being held
    /// appropriately hides child in response and deplete energy while hidden
    /// </summary>
    public void HandleHiding()
    {
        //if the player is holding space child is hiding
        if (Input.GetKey(KeyCode.Space))
        {
            isHiding = true;

            //energy is depleted while hiding
            energyBarDepletion += 4 * Time.deltaTime;
        }
        //not hiding
        else
        {
            isHiding = false;
        }
    }

 

}
