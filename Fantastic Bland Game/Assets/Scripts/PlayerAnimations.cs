using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimations : MonoBehaviour
{
    [SerializeField] private PlayerTurn playerTurn;
    [SerializeField] private Animator animator;

    void Update()
    {
        if (playerTurn.IsPlayerTurn())
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                animator.SetTrigger("JumpingTrigger");
            }

            bool isWalking = Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0;
            animator.SetBool("isWalking", isWalking);
        }
    }
}
