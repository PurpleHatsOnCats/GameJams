using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerReciever : MonoBehaviour
{
    [SerializeField]
    private GameObject correspondingPuddle;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if(correspondingPuddle != null)
        {
            correspondingPuddle.transform.position = new Vector3
                (correspondingPuddle.transform.position.x, correspondingPuddle.transform.position.y - 2);
            Destroy(correspondingPuddle, 1);
        }

    }

}
