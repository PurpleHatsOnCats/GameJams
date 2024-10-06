using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{
    //fields
    [SerializeField]
    private int levelToLoad;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene($"Level_{levelToLoad}");

            counter += 3;

            if (counter >= 9) 
            {
                counter = 3;
            }
        }
    }
}
