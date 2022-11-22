using UnityEngine;

public class AttackState : StateMachineBehaviour
{
    Transform target;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {    
        float distance = Vector2.Distance(target.position, animator.transform.position);
        target.GetComponent<PlayerHealth>().OnAttackZombie();       
        if (distance > 2f)
            animator.SetBool("isAttacking", false);

        if (animator.gameObject.name.Equals("BossZombie"))
        {
            float zombieDist = Vector2.Distance(target.position, animator.transform.position);
            target.GetComponent<PlayerHealth>().OnAttackZombie();
            if (zombieDist > 4)
                animator.SetBool("isAttacking", false);
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        target.GetComponent<PlayerHealth>().isAttackingZombie = false;
    }

    

}
