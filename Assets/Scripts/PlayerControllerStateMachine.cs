using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerStateMachine : StateMachine
{
    [HideInInspector]
    public Idle idleState;

    [HideInInspector]
    public Moving movingState;

    [HideInInspector]
    public Jumping jumpingState;

    [HideInInspector]
    public Grappling grappleState;

    [HideInInspector]
    public Dashing dashingState;

    [HideInInspector]
    public GroundPound groundPoundState;

    [HideInInspector]
    public Attack attackState;

    public Rigidbody2D rb;

    public float speed = 4f;

    public float gpCooldownTime = 10f;

    [HideInInspector]
    public bool isGrounded = false;

    [HideInInspector]
    public Animator playerAnim;

    public bool isFacingRight = true;

    public GameObject acquireEffect, heartAcquireEffect;
    
    public List<AbilityData> abilitySet = new List<AbilityData>();

    public bool isGrappleAcquired, isDashAcquired, isKunaiAcquired, isPoundAcquired;

    [HideInInspector]
    public bool isGPCooldown = false;

    private void Awake()
    {
        playerAnim = this.GetComponent<Animator>();

        idleState = new Idle(this);
        movingState = new Moving(this);
        grappleState = new Grappling(this);
        dashingState = new Dashing(this);
        groundPoundState = new GroundPound(this);
        attackState = new Attack(this);
        jumpingState = new Jumping(this);
    }

    protected override BaseState GetInitialState()
    {
        return idleState;
    }

    private void OnCollisionStay2D(Collision2D other)
    {
        
        Debug.Log("current collision stay : " + other.gameObject.name);
        if (other.gameObject.tag == "Ground")
        {
            isGrounded = true;
            Debug.Log("isGrounded : " + isGrounded);
        }
        if(other.gameObject.tag == "Spike")
        {
            this.gameObject.GetComponent<PlayerHealth>().OnAttackSpike();
        }
      
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.tag == "Ground")
        {
            isGrounded = false;
            Debug.Log("isGrounded : " + isGrounded);
        }
        if (other.gameObject.tag == "Spike")
        {
            this.gameObject.GetComponent<PlayerHealth>().isAttackingSpike = false;
        }
    }

    public void AcquireEffect()
    {
        GameObject acquiredEffect = GameObject.Instantiate(acquireEffect, this.gameObject.transform.position - new Vector3(0, 1.2f, 0), Quaternion.identity, this.transform);
        StartCoroutine(StartAcquireEffect(acquiredEffect));
    }

    IEnumerator StartAcquireEffect(GameObject acquiredEffect)
    {
        yield return new WaitForSeconds(3f);

        Destroy(acquiredEffect);
    }

    public void AcquireHeartEffect()
    {
        GameObject acquiredEffect = GameObject.Instantiate(heartAcquireEffect, this.gameObject.transform.position - new Vector3(0, 0, 0), Quaternion.identity, this.transform);
        StartCoroutine(StartHeartAcquireEffect(acquiredEffect));
    }

    IEnumerator StartHeartAcquireEffect(GameObject acquiredEffect)
    {
        yield return new WaitForSeconds(3f);

        Destroy(acquiredEffect);
    }


}