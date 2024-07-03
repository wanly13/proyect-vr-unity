using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class VideoEndHandler : MonoBehaviour
{
    public VideoPlayer videoPlayer;
    //public string nextSceneName;
    public GameObject tutorialCanvas;


    void Start()
    {
        //tutorialCanvas.SetActive(false);
        videoPlayer.loopPointReached += OnVideoEnd;
    }

    void OnVideoEnd(VideoPlayer vp)
    {
        gameObject.SetActive(false);
            if (tutorialCanvas != null)
            {
                Debug.LogWarning("Abre of canvas.");
                tutorialCanvas.SetActive(true);
            }
            else
            {
                Debug.LogWarning("No se ha asignado el canvas del tutorial en el inspector.");
            }

    }
   
}
