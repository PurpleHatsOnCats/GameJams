using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Video;

public class VidController : MonoBehaviour
{
    [SerializeField] private string videoFileName;
    private VideoPlayer videoPlayer;
    [HideInInspector]public bool started = false;
    public UnityEvent VideoDone;

    // Start is called before the first frame update
    void Start()
    {
        videoPlayer = GetComponent<VideoPlayer>();
        videoPlayer.Prepare();
    }
    private void Update()
    {
        if (started && !videoPlayer.isPlaying)
        {
            started = false;
            //VideoDone.Invoke();
            Debug.Log("Video Done");
        }
    }

    public void PlayVideo()
    { 
        if (videoPlayer) 
        {
            // Set up display object
            videoPlayer.targetMaterialRenderer.enabled = true;
            Transform displayTransform = videoPlayer.targetMaterialRenderer.gameObject.transform;
            Vector3 newScale = displayTransform.localScale;
            newScale.x = videoPlayer.width * newScale.y / videoPlayer.height;
            displayTransform.localScale = newScale;

            // Start video
            string videoPath = System.IO.Path.Combine(Application.streamingAssetsPath, videoFileName);
            Debug.Log(videoPath);
            videoPlayer.url = videoPath;
            videoPlayer.Play();
            started = true;
        }
    }
}
