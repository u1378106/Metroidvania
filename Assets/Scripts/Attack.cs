using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : BaseState
{
    private PlayerControllerStateMachine _sm;
    private float _horizontalInput;
    private float _verticalInput;

    public Attack(PlayerControllerStateMachine stateMachine) : base("Attack", stateMachine)
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
        {
            _sm.playerAnim.SetBool("isWalking", true);       
            stateMachine.ChangeState(_sm.movingState);       
        }

        _verticalInput = Input.GetAxis("Vertical");
        if (Mathf.Abs(_verticalInput) > Mathf.Epsilon)
            stateMachine.ChangeState(_sm.jumpingState);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            AudioManager.instance.Play("Shoot");
            if (_sm.isFacingRight)
            {
                GameObject projectile = GameObject.Instantiate(_sm.abilitySet[0].ability, _sm.transform.position + new Vector3(2, 0, 0), Quaternion.Euler(0, 0, -90));
                projectile.GetComponent<Rigidbody2D>().AddForce(_sm.transform.right * 1000);
            }
            else
            {
                GameObject projectile = GameObject.Instantiate(_sm.abilitySet[0].ability, _sm.transform.position + new Vector3(-2, 0, 0), Quaternion.Euler(0, 0, 90));
                projectile.GetComponent<Rigidbody2D>().AddForce(_sm.transform.right * -1000);
            }
            _sm.playerAnim.SetBool("isAttacking", true);
        }
        else if (Input.GetKeyUp(KeyCode.Space))
        {
            _sm.playerAnim.SetBool("isAttacking", false);         
        }
    }
}
