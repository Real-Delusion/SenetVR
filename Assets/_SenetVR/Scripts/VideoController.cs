using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class VideoController : MonoBehaviour {
    VideoPlayer videoPlayer;
    // Start is called before the first frame update
    void Start () {
        videoPlayer = this.GetComponent<VideoPlayer> ();
    }

    // Update is called once per frame
    void Update () {
        if (videoPlayer.frame == (long) videoPlayer.frameCount - 1) {
            // && videoPlayer.isPlaying == false
            GameManager.LoadSceneAsync ("MainScene");
        }
    }
}