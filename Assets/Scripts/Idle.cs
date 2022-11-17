using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Idle : BaseState
{
    private PlayerControllerStateMachine _sm;
    private float _horizontalInput;
    private float _verticalInput;

    public Idle(PlayerControllerStateMachine stateMachine) : base("Idle", stateMachine)
    {
        _sm = stateMachine;
    }

    public override void Enter()
    {
        base.Enter();
        _horizontalInput = 0f;
        _verticalInput = 0f;
    }

    public override void UpdateLogic()
    {
        base.UpdateLogic();
      
        _horizontalInput = Input.GetAxis("Horizontal");
        if (Mathf.Abs(_horizontalInput) > Mathf.Epsilon)       
            stateMachine.ChangeState(_sm.movingState);

        _verticalInput = Input.GetAxis("Vertical");
        if (Mathf.Abs(_verticalInput) > Mathf.Epsilon)
            stateMachine.ChangeState(_sm.jumpingState);


        if (Input.GetKeyDown(KeyCode.Mouse0) && _sm.isGrappleAcquired)
            stateMachine.ChangeState(_sm.grappleState);

        if (Input.GetKeyDown(KeyCode.Space) && _sm.isKunaiAcquired)
        {
            stateMachine.ChangeState(_sm.attackState);
        }

        if (Input.GetKeyDown(KeyCode.Mouse2) &&_sm.isPoundAcquired && !_sm.isGrounded)
        {
            stateMachine.ChangeState(_sm.groundPoundState);
        }

        _sm.playerAnim.SetBool("isWalking", false);
    }
}