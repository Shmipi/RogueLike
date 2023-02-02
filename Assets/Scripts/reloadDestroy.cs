using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class reloadDestroy : StateMachineBehaviour
{

    private GameObject reloadObj;
    private GameObject player;
    private GameObject reloadPoint;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        player = GameObject.FindGameObjectWithTag("Player");
        reloadPoint = GameObject.FindGameObjectWithTag("ReloadPoint");
        reloadObj = GameObject.FindGameObjectWithTag("Reload");
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        reloadObj.GetComponent<Transform>().position = reloadPoint.GetComponent<Transform>().position;
        reloadObj.GetComponent<Transform>().rotation = reloadPoint.GetComponent<Transform>().rotation;
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        player.GetComponent<PlayerMovement>().ammo = player.GetComponent<PlayerMovement>().magSize;
        Destroy(reloadObj);
    }

    // OnStateMove is called right after Animator.OnAnimatorMove()
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that processes and affects root motion
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK()
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that sets up animation IK (inverse kinematics)
    //}
}
