using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moving : BaseState
{
    private PlayerControllerStateMachine _sm;
    private float _horizontalInput;

    public Moving(PlayerControllerStateMachine stateMachine) : base("Moving", stateMachine)
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
        if (Mathf.Abs(_horizontalInput) < Mathf.Epsilon)
            stateMachine.ChangeState(_sm.idleState);

        if(Input.GetKeyDown(KeyCode.LeftShift) && _sm.isDashAcquired)
        {
            stateMachine.ChangeState(_sm.dashingState);
        }

        if (Input.GetKeyDown(KeyCode.Mouse0) && _sm.isGrappleAcquired)
            stateMachine.ChangeState(_sm.grappleState);

        if (Input.GetKeyDown(KeyCode.Mouse2))
        {
            stateMachine.ChangeState(_sm.groundPoundState);
        }
    }

    public override void UpdatePhysics()
    {
        base.UpdatePhysics();
        Vector2 vel = _sm.GetComponent<Rigidbody2D>().velocity;
        vel.x = _horizontalInput * _sm.speed;
        _sm.GetComponent<Rigidbody2D>().velocity = vel;

        _sm.playerAnim.SetBool("isWalking", true);

        if (_sm.isFacingRight && vel.x < 0 || !_sm.isFacingRight && vel.x > 0)
            Flip();
    }

    void Flip()
    {
        _sm.isFacingRight = !_sm.isFacingRight;
        _sm.transform.localScale = new Vector2(_sm.transform.localScale.x * -1, _sm.transform.localScale.y);
    }
}