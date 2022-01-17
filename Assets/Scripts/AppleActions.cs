using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AppleActions : MonoBehaviour
{
    public Renderer rend;
    public GameObject appleCollected;
    AudioSource audioData;
    public AudioClip impact;

    void Start()
    {
        rend = GetComponent<Renderer>();
        rend.enabled = true;
        audioData = GetComponent<AudioSource>();
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        PlayerController player = other.collider.GetComponent<PlayerController>();
        audioData.PlayOneShot(impact);

        if(player != null)
        {
            Instantiate(appleCollected, transform.position, appleCollected.transform.rotation);
            player.SetScoreText(1);
        }

        rend.enabled = false;
        Destroy(gameObject, .25f);
    }
}