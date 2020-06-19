using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterJump : CharacterComponents
{
    [Header("Settings")]
    [SerializeField] private float jumpForce = 10f;
    [SerializeField] private float jumpTime = 0.02f;

    // Controle forca do pulo
    public float JumpForce { get; set; }
    
    // Parametros internos
    private bool isJumping;
    private float jumpTimeCounter;

    private readonly int jumpParamater = Animator.StringToHash("isJump");

    protected override void Start()
    {
        base.Start();
        JumpForce = jumpForce;
    }

    
    protected override void HandleAbility()
    {
        base.HandleAbility();

        if (jumpPressed && _sensors.OnGround)
        {
            // Parametros definidos para pulo
            isJumping = true;
            jumpTimeCounter = jumpTime;

            // Acao pulo
            Jump();

            // Animation
            UpdateAnimations();
        }

        // Pulo Duplo
        if (jumpPressed && isJumping)
        {
            if(jumpTimeCounter > 0)
            {
                Jump();
                jumpTimeCounter -= Time.deltaTime;
            }
            else
            {
                isJumping = false;
            }
        }

    }

    private void Jump()
    {
        _controller.MoveVerticalCharacter(JumpForce);

    }

    // Update Animation
    private void UpdateAnimations()
    {
        if (jumpPressed)
        {
            if (_character.CharacterAnimator != null)
            {
                _character.CharacterAnimator.SetTrigger(jumpParamater);
            }
        }
        
    }
}
