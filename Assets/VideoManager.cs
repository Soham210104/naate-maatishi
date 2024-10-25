using UnityEngine;
using UnityEngine.Video;
using UnityEngine.UI;
public class VideoManager : MonoBehaviour
{
    public VideoPlayer videoPlayer;       // Assign your VideoPlayer component here
    public GameObject videoDisplay;       // The GameObject showing the video (with RawImage)
    public GameObject woodenFloor;        // The RawImage GameObject for WoodenFloor
    public GameObject player;

    void Start()
    {
        if (videoPlayer == null || videoDisplay == null || woodenFloor == null)
        {
            Debug.LogError("VideoPlayer, VideoDisplay, or WoodenFloor GameObject not assigned!");
            return;
        }

        // Initially hide the WoodenFloor RawImage
        woodenFloor.SetActive(false);
        player.SetActive(false);
        // Subscribe to the loopPointReached event to detect when the video ends
        videoPlayer.loopPointReached += OnVideoEnd;
    }

    void OnVideoEnd(VideoPlayer vp)
    {
        // Disable the video display GameObject
        videoDisplay.SetActive(false);
        player.SetActive(true);
        // Enable the WoodenFloor RawImage GameObject
        woodenFloor.SetActive(true);
    }

    void OnDestroy()
    {
        // Unsubscribe from the event when the object is destroyed
        videoPlayer.loopPointReached -= OnVideoEnd;
    }
}
