using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : BaseState
{
    private PlayerControllerStateMachine _sm;
    private float _horizontalInput;

    public Attack(PlayerControllerStateMachine stateMachine) : base("Attack", stateMachine)
    {
        _sm = stateMachine;
    }

    public override void Enter()
    {
        base.Enter();
        _horizontalInput = 0f;
    }

    public override void UpdateLogic()
    {
        base.UpdateLogic();
        _horizontalInput = Input.GetAxis("Horizontal");
        if (Mathf.Abs(_horizontalInput) > Mathf.Epsilon)
        {
            _sm.playerAnim.SetBool("isWalking", true);       
            stateMachine.ChangeState(_sm.movingState);       
        }

        if(Input.GetKeyDown(KeyCode.Space))
        {
            GameObject projectile = GameObject.Instantiate(_sm.abilitySet[0].ability, _sm.transform.position + new Vector3(2, 0, 0), Quaternion.Euler(0, 0, -90));
            //GameObject trail = Instantiate(abilityData.weaponTrailEffect, projectile.transform);
            projectile.GetComponent<Rigidbody2D>().AddForce(_sm.transform.right * 1000);
            _sm.playerAnim.SetBool("isAttacking", true);
        }
        else if (Input.GetKeyUp(KeyCode.Space))
        {
            _sm.playerAnim.SetBool("isAttacking", false);
        }
    }
}
