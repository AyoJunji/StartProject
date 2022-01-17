using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class ScoreTracker_Scene2 : MonoBehaviour
{
    public static int totalScore;

    public AudioSource audioData;
    public AudioClip victorySound;
    public AudioClip losingSound;
    
    public GameObject winnersText;
    public GameObject losersText;

    void Start()
    {
        totalScore = PlayerController.scoreTracker;

        if(totalScore < 5)
        {
            losersText.SetActive(true);
            audioData.PlayOneShot(losingSound);
            Invoke("RestartMainScene", 5f);
        }

        if (totalScore >= 5)
        {
            winnersText.SetActive(true);
            audioData.PlayOneShot(victorySound);
            Invoke("RestartMainScene", 5f);
        }
    }

    void RestartMainScene()
    {
        SceneManager.LoadScene("MainScene");
    }
}
