using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animationStateController : MonoBehaviour
{
    Animator animator;
    GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //if (gameManager.gameOver)
        //{
        //    animator.SetBool("isGameOver", true);
        //}
            bool isWalking = animator.GetBool("isWalking");
            bool wasdPressed = (Input.GetKey("w")) || (Input.GetKey("a")) || (Input.GetKey("s")) || (Input.GetKey("d"));

            if (!isWalking && wasdPressed)
            {
                animator.SetBool("isWalking", true);
            }
            if (isWalking && !wasdPressed)
            {
                animator.SetBool("isWalking", false);
            }
        
    }
}
