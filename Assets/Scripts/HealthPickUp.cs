using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickUp : MonoBehaviour
{

    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag.Equals("Player"))
        {
            other.gameObject.GetComponent<PlayerHealth>().heart1.fillAmount = 1;
            other.gameObject.GetComponent<PlayerHealth>().heart2.fillAmount = 1;
            other.gameObject.GetComponent<PlayerHealth>().heart3.fillAmount = 1;

            AudioManager.instance.Play("Acquire");

            other.gameObject.GetComponent<PlayerControllerStateMachine>().AcquireHeartEffect();
            Destroy(this.gameObject);
        }
    }
}
