using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathTrap : MonoBehaviour
{
    public GameObject gameOverScreen;
    private void OnCollisionEnter2D(Collision2D other)
    {
        
        if(other.gameObject.tag == "Player" )
        {
            gameOverScreen.SetActive(true);
            Destroy(other.gameObject);
        }
        else if(other.gameObject.tag == "Fire")
        {
            Destroy(other.gameObject);
        }
    }
}
