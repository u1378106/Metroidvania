using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundPoundDetect : MonoBehaviour
{
    PlayerControllerStateMachine _sm;

    private void Start()
    {
        _sm = GameObject.FindObjectOfType<PlayerControllerStateMachine>();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag.Equals("Player") && !_sm.isGrounded && _sm.isPoundAcquired)
        {          
            this.gameObject.transform.GetComponentInParent<Zombie>().TakeDamage(100);
            Destroy(this.gameObject);
        }
    }
}
