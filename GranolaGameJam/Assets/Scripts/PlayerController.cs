using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerController : MonoBehaviour
{
    public KeyCode UpKey;
    public KeyCode DownKey;
    public KeyCode LeftKey;
    public KeyCode RightKey;
    public KeyCode InteractKey;
    public int AttackOneButton;
    public int AttackTwoButton;

    public UnityEvent MoveUp;
    public UnityEvent MoveDown;
    public UnityEvent MoveLeft;
    public UnityEvent MoveRight;
    public UnityEvent Jump;
    public UnityEvent InteractDown;
    public UnityEvent InteractUp;
    public UnityEvent AttackOne;
    public UnityEvent AttackTwo;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Check for keyboard input
        if (Input.GetKey(UpKey))
        {
            MoveUp.Invoke();
        }
        if (Input.GetKey(DownKey))
        {
            MoveDown.Invoke();
        }
        if (Input.GetKey(LeftKey))
        {
            MoveLeft.Invoke();
        }
        if (Input.GetKey(RightKey))
        {
            MoveRight.Invoke();
        }
        if (Input.GetKeyDown(InteractKey))
        {
            InteractDown.Invoke();
        }
        if (Input.GetKeyUp(InteractKey))
        {
            InteractUp.Invoke();
        }
        if (Input.GetKeyDown(UpKey))
        {
            Jump.Invoke();
        }

        // Check for mouse input
        if (Input.GetMouseButtonDown(AttackOneButton))
        {
            AttackOne.Invoke();
        }
        if (Input.GetMouseButtonDown(AttackOneButton))
        {
            AttackTwo.Invoke();
        }
    }
}
