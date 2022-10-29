using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityHandler : MonoBehaviour
{
    public GameObject acquireEffect;

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag.Equals("Player"))
        {
            if (this.gameObject.name.Equals("KunaiAbility"))
                other.gameObject.GetComponent<PlayerControllerStateMachine>().abilitySet.Add(Resources.Load("Data/Kunai") as AbilityData);

            if (this.gameObject.name.Equals("GrappleHookAbility"))
                other.gameObject.GetComponent<PlayerControllerStateMachine>().abilitySet.Add(Resources.Load("Data/Grapple") as AbilityData);

            if (this.gameObject.name.Equals("DashAbility"))
                other.gameObject.GetComponent<PlayerControllerStateMachine>().abilitySet.Add(Resources.Load("Data/Dash") as AbilityData);

            GameObject acquiredEffect = GameObject.Instantiate(acquireEffect, other.transform.position, Quaternion.identity);
            StartCoroutine(DestroyAbility(acquiredEffect));
        }
    }

    IEnumerator DestroyAbility(GameObject acquiredEffect)
    {
        yield return new WaitForSeconds(3f);

        Destroy(acquiredEffect);
        Destroy(this.gameObject);
        
    }
}
