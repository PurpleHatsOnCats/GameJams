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

    public UnityEvent MoveUp;
    public UnityEvent MoveDown;
    public UnityEvent MoveLeft;
    public UnityEvent MoveRight;
    public UnityEvent Jump;
    public UnityEvent InteractDown;
    public UnityEvent InteractUp;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
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

    }
}
