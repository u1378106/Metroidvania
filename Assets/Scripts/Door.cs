using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{

    DoorManager doorManager;

    private bool isNearDoor;

    private void Start()
    {
        doorManager = GameObject.FindObjectOfType<DoorManager>();
    }

    private void OnCollisionStay2D(Collision2D other)
    {      
        if (other.gameObject.tag.Equals("Player"))
        {
            isNearDoor = true;           
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        Debug.Log("player exit");
        isNearDoor = false;
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Q) && isNearDoor)
        {
            
            doorManager.UseKey();
            if (doorManager.keyCounter > 0)
            {
                isNearDoor = false;
                Destroy(this.gameObject);
            }
        }
    }
}