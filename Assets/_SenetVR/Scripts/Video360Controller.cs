using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class Video360Controller : MonoBehaviour {

    public VideoPlayer videoPlayer;
    // Start is called before the first frame update
    void Start () {
        videoPlayer.loopPointReached += EndReached;
    }

    void EndReached (UnityEngine.Video.VideoPlayer vp) {
        GameManager.instance.levelManager.goMainScreen ();
    }
}