using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleSpawner : MonoBehaviour
{
    public Rigidbody2D apple;
    public GameObject appleObject;
    private IEnumerator looper;

    void Start()
    {
        apple = GetComponent<Rigidbody2D>();
        looper = spawner(Random.Range(.75f, 1.25f));
        StartCoroutine(looper);
    }

    private IEnumerator spawner(float waitSpawn)
    {
        while (true)
        {
            yield return new WaitForSeconds(waitSpawn);
            print("spawner " + Time.time);
            Instantiate(appleObject, new Vector2(Random.Range(-10.5f, 10.5f), 5.5f), Quaternion.identity);
        }
    }
}