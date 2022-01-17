using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class Timer : MonoBehaviour
{
    AudioSource audioData;
    public AudioClip victorySound;
    public AudioClip losingSound;

    float timeLeft;
    public static int totalScore;

    void Start()
    {
        audioData = GetComponent<AudioSource>();
        audioData.PlayDelayed(3f);
        timeLeft = 13.0f;
    }

    void Update()
    {
        timeLeft -= Time.deltaTime;

        TextMeshProUGUI timeText = GameObject.Find("TimeText").GetComponent<TextMeshProUGUI>();
        Mathf.Clamp(timeLeft, 0, timeLeft);
        timeText.text = "Time- " + Mathf.Round(timeLeft).ToString();

        totalScore = PlayerController.scoreTracker;
        
        CheckWinCondition();
    }

    void CheckWinCondition()
    {

        if (timeLeft <= 0 && totalScore < 5)
        {
           audioData.PlayOneShot(losingSound);
           Invoke("EndState", 1f);
        }

        if (timeLeft <= 0 && totalScore >= 5)
        {
           audioData.PlayOneShot(victorySound);
           Invoke("EndState", 1f);
        }
    }

    void EndState()
    {
        SceneManager.LoadScene("EndScene");
    }
}