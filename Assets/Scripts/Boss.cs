using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    [SerializeField]
    private GameObject boss, key, door, doorRef;

    Vector3 doorRefPos;

    public bool isBossDead = false;

    // Start is called before the first frame update
    void Start()
    {
        doorRefPos = doorRef.transform.position;
    }

    // Update is called once per frame
    public void FinalKey()
    {    
         GameObject finalKey = GameObject.Instantiate(key, boss.transform.position, Quaternion.identity);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag.Equals("Player"))
        {
            GameObject doorLock = GameObject.Instantiate(door, doorRefPos, Quaternion.identity);
            this.gameObject.GetComponent<BoxCollider2D>().enabled = false;
        }
    }
}
