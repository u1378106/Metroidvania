using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestroy : MonoBehaviour
{
    AudioManager audioManager;
    public GameObject gameOverScreen;

    private void Start()
    {
        audioManager = GameObject.FindObjectOfType<AudioManager>();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "Player")
        {
           GameObject.Instantiate(gameOverScreen);
            Destroy(other.gameObject);
        }
        
    }
}
