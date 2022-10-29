using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireSpawner : MonoBehaviour
{
    [SerializeField]
    private Transform parentSpawnPoint;

    [SerializeField]
    private GameObject fire;

    [SerializeField]
    private Rigidbody2D fire_rb;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnFire", 2, 2);   
    }

    private void SpawnFire()
    {
       GameObject fireObj = Instantiate(fire, parentSpawnPoint.position, Quaternion.Euler(180, 0, 0), parentSpawnPoint);
        fire_rb = fireObj.GetComponent<Rigidbody2D>();
        fire_rb.AddForce(transform.up * -10);
    }
}
