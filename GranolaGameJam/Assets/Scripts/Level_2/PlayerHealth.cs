using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    private int health = 3;
    private bool isHiding = false;

    private SpriteRenderer childSprite;

    [SerializeField]
    private List<GameObject> energyBarObject;
    private float energyBarDepletion = 0;
    private int pipToDelete = 0;

    /// <summary>
    /// checks if the child is hiding or not
    /// </summary>
    public bool IsHiding
    {
        get { return isHiding; }
    }

    /// <summary>
    /// checks the health of the child and allows it to be altered
    /// </summary>
    public int Health
    {
        get { return health; }
        set { health = value; }
    }

    void Awake()
    {
        childSprite = GetComponent<SpriteRenderer>();
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //hiding and depleting energy can only happen if there are still energy pips remaining
        if(pipToDelete != 5)
        {
            HandleHiding();
            DepletePips();
        }
        else
        {
            //not hiding state
            childSprite.color = Color.cyan;
            isHiding = false;
        }




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
            childSprite.color = Color.gray;
            isHiding = true;

            //energy is depleted while hiding
            energyBarDepletion += 2 * Time.deltaTime;
        }
        //not hiding
        else
        {
            childSprite.color = Color.cyan;
            isHiding = false;
        }
    }

    /// <summary>
    /// destroys energy pips
    /// </summary>
    public void DepletePips()
    {
        //after every 4 seconds of hiding a pip is taken away
        if(energyBarDepletion > 8)
        {
            //destroys furthest remaining energy pip
            Destroy(energyBarObject[pipToDelete]);            
            pipToDelete++;

            //resets depletion counter
            energyBarDepletion = 0;
        }
        //when a pip only has 1 second of life left it turns yellow
        else if(energyBarDepletion > 6)
        {
            energyBarObject[pipToDelete].GetComponent<SpriteRenderer>().color = Color.yellow;
        }
    }

}
