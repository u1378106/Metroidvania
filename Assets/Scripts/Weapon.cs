using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    public int Damage;
    public int cooldownTime;

    public abstract void Activate();


    protected void Attack(GameObject weaponTrailEffect, GameObject player)
    {
        Debug.Log("Attacking....!");

        GameObject projectile = Instantiate(this.gameObject, player.transform.position, Quaternion.identity);
        GameObject trail = Instantiate(weaponTrailEffect, projectile.transform);
        projectile.GetComponent<Rigidbody>().AddForce(player.transform.forward * 1000);
    }

    protected void MegaAttack(GameObject weaponTrailEffect, GameObject player)
    {
        Debug.Log("Mega Attack....!");

        GameObject projectile = Instantiate(this.gameObject, player.transform.position, Quaternion.identity);
        GameObject trail = Instantiate(weaponTrailEffect, projectile.transform);
        projectile.GetComponent<Rigidbody>().AddForce(player.transform.forward * 1000);
    }

    protected void Stun(GameObject weaponTrailEffect, GameObject player)
    {
        Debug.Log("Stunned....!");

        GameObject projectile = Instantiate(this.gameObject, player.transform.position, Quaternion.identity);
        GameObject trail = Instantiate(weaponTrailEffect, projectile.transform);
        projectile.GetComponent<Rigidbody>().AddForce(player.transform.forward * 1000);
    }

    protected void Freeze(GameObject weaponTrailEffect, GameObject player)
    {
        Debug.Log("Freeze....!");

        GameObject projectile = Instantiate(this.gameObject, player.transform.position, Quaternion.identity);
        GameObject trail = Instantiate(weaponTrailEffect, projectile.transform);
        projectile.GetComponent<Rigidbody>().AddForce(player.transform.forward * 1000);
    }
}
