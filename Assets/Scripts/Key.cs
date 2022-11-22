using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    DoorManager doorManager;

    private void Start()
    {
        doorManager = GameObject.FindObjectOfType<DoorManager>();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag.Equals("Player"))
        {
            doorManager.OnKeyAcquired();
            Destroy(this.gameObject);
        }
    }
}
