using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AutoReload_scene : MonoBehaviour
{
    public float delay = 15;
    public string NewLevel = "Scene01_Titlescreen";
    void Start()
    {
        StartCoroutine(LoadLevelAfterDelay(delay));
    }

    IEnumerator LoadLevelAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(NewLevel);
    }
}