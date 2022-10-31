using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityHandler : MonoBehaviour
{

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag.Equals("Player"))
        {
            if (this.gameObject.name.Equals("KunaiAbility"))
            {               
                other.gameObject.GetComponent<PlayerControllerStateMachine>().abilitySet.Add(Resources.Load("Data/Kunai") as AbilityData);
                other.gameObject.GetComponent<PlayerControllerStateMachine>().isKunaiAcquired = true;
            }

            else if (this.gameObject.name.Equals("GrappleHookAbility"))
            {
                other.gameObject.GetComponent<PlayerControllerStateMachine>().abilitySet.Add(Resources.Load("Data/Grapple") as AbilityData);
                other.gameObject.GetComponent<PlayerControllerStateMachine>().isGrappleAcquired = true;
            }

            else if (this.gameObject.name.Equals("DashAbility"))
            {
                other.gameObject.GetComponent<PlayerControllerStateMachine>().abilitySet.Add(Resources.Load("Data/Dash") as AbilityData);
                other.gameObject.GetComponent<PlayerControllerStateMachine>().isDashAcquired = true;
            }
            AudioManager.instance.Play("Acquire");
            other.gameObject.GetComponent<PlayerControllerStateMachine>().AcquireEffect();
            Destroy(this.gameObject);
        }
    }
}
