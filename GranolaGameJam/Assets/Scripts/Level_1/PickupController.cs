using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.Events;

public class PickupController : MonoBehaviour
{
    public int ItemID;
    public float PickupRange;
    public GameObject Player;
    public bool InRange;
    public IntEvent ItemPickup;
    public UnityEvent Collected;

    // Update is called once per frame
    void Update()
    {
        Vector2 playerPosition = Player.transform.position;
        Vector2 itemPosition = transform.position;
        InRange = (playerPosition - itemPosition).magnitude <= PickupRange;
    }
    public void AttemptPickup()
    {
        if (InRange)
        {
            ItemPickup.Invoke(ItemID);
            Collected.Invoke();
            Destroy(gameObject);
        }
    }
}