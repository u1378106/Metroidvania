using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathTrap : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log("collided!");
        if(other.gameObject.tag == "Player" || other.gameObject.tag == "Fire")
        {
            Destroy(other.gameObject);
        }
    }
}
