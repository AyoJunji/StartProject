using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D rb;
    private float speed = 2f;
    public static int scoreTracker;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        scoreTracker = 0;
    }

    void Update()
    {
        Mathf.Clamp(scoreTracker, 0, 5);
    }

    void FixedUpdate()
    {
        ReadInputs();
    }

    void ReadInputs()
    {
      var xInp = Input.GetAxisRaw("Horizontal");
      rb.AddForce(new Vector2(xInp * speed, 0), ForceMode2D.Impulse);
    }

    public void SetScoreText(int score)
    {
        scoreTracker += score;
        TextMeshProUGUI scoreText = GameObject.Find("ApplesText").GetComponent<TextMeshProUGUI>();
        scoreText.text = "Apples: " + scoreTracker.ToString() + "/5";
    }
}