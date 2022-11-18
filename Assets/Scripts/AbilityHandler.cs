using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityHandler : MonoBehaviour
{
    private GameObject player;

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag.Equals("Player"))
        {
            player = other.gameObject;
            if (this.gameObject.name.Equals("KunaiAbility"))
            {
                player.GetComponent<PlayerControllerStateMachine>().abilitySet.Add(Resources.Load("Data/Kunai") as AbilityData);
                player.GetComponent<PlayerControllerStateMachine>().isKunaiAcquired = true;
            }

            else if (this.gameObject.name.Equals("GrappleHookAbility"))
            {
                player.GetComponent<PlayerControllerStateMachine>().abilitySet.Add(Resources.Load("Data/Grapple") as AbilityData);
                player.GetComponent<PlayerControllerStateMachine>().isGrappleAcquired = true;
            }

            else if (this.gameObject.name.Equals("DashAbility"))
            {
                player.GetComponent<PlayerControllerStateMachine>().abilitySet.Add(Resources.Load("Data/Dash") as AbilityData);
                player.GetComponent<PlayerControllerStateMachine>().isDashAcquired = true;
            }
            else if (this.gameObject.name.Equals("GroundPound"))
            {
                player.GetComponent<PlayerControllerStateMachine>().abilitySet.Add(Resources.Load("Data/Pound") as AbilityData);
                player.GetComponent<PlayerControllerStateMachine>().isPoundAcquired = true;
            }
            AudioManager.instance.Play("Acquire");
            player.GetComponent<PlayerControllerStateMachine>().AcquireEffect();
            Destroy(this.gameObject);
        }
    }

}
