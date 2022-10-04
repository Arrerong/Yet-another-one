using UnityEngine;

public class AnimationStateController : MonoBehaviour
{
    Animator animator;
    private int isJoggingHash;
    private int isJumpingHash;
    private int isAimingHash;
    public int playerIndex;

    void Start()
    {
        animator = GetComponent<Animator>();
        
        isJoggingHash = Animator.StringToHash("isJogging");
        isJumpingHash = Animator.StringToHash("isJumping");
        isAimingHash = Animator.StringToHash("isAiming");
    }

    void Update()
    {
        bool isJogging = animator.GetBool(isJoggingHash);
        bool isJumping = animator.GetBool(isJumpingHash);
        bool isAiming = animator.GetBool(isAimingHash);
        bool forwardPressed = Input.GetKey("w") || Input.GetKey("a") || Input.GetKey("s") || Input.GetKey("d");
        bool jumpPressed = Input.GetKeyDown(KeyCode.Space);
        bool aimPressed = Input.GetMouseButton(1);

        if (TurnManager.GetInstance().IsItPlayerTurn(playerIndex -1))
        {
            if (!isJogging && forwardPressed)
            {
                animator.SetBool(isJoggingHash, true);
            }

            if (isJogging && !forwardPressed)
            {
                animator.SetBool(isJoggingHash, false);
            }

            if (!isJumping && jumpPressed)
            {
                animator.SetBool(isJumpingHash, true);
            }

            if (isJumping && !jumpPressed)
            {
                animator.SetBool(isJumpingHash, false);
            }

            if (!isAiming && aimPressed)
            {
                animator.SetBool(isAimingHash, true);
            }

            if (isAiming && !aimPressed)
            {
                animator.SetBool(isAimingHash, false);
            }
        }
    }
}