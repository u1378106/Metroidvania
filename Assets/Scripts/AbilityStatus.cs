using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityStatus : MonoBehaviour
{
    PlayerControllerStateMachine _sm;

    // Start is called before the first frame update
    void Start()
    {
        _sm = GameObject.FindObjectOfType<PlayerControllerStateMachine>();
    }

    // Update is called once per frame
    void Update()
    {  
            if (_sm.isGPCooldown)
            {
            Debug.Log("cooldown time : " + _sm.gpCooldownTime);
            _sm.gpCooldownTime -= Time.deltaTime;
            if (_sm.gpCooldownTime < 0)
                {                   
                    _sm.isGPCooldown = false;
                    _sm.gpCooldownTime = 10.0f;
                }
            }        
    }
}
