using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jumping : BaseState
{
    private PlayerControllerStateMachine _sm;
    private float _verticalInput;

    public Jumping(PlayerControllerStateMachine stateMachine) : base("Jumping", stateMachine)
    {
        _sm = stateMachine;
    }

    public override void Enter()
    {
        base.Enter();
        _verticalInput = 0f;
    }

    public override void UpdateLogic()
    {
        base.UpdateLogic();
        _verticalInput = Input.GetAxis("Vertical");
        if (Mathf.Abs(_verticalInput) < Mathf.Epsilon)
            stateMachine.ChangeState(_sm.movingState);
    }

    public override void UpdatePhysics()
    {
        base.UpdatePhysics();

        if (Input.GetKeyDown(KeyCode.W))
        {
            _sm.GetComponent<Rigidbody2D>().AddForce(Vector2.up * 500);
        }

    }
}