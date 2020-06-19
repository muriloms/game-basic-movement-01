using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : CharacterComponents
{
    [Header("Settings")]
    [SerializeField] private float walkSpeed = 4f;

    // Controle da velocidade de movimento - andar
    public float MoveSpeed { get; set; }

    // Parametros internos
    private readonly int walkMoveParamater = Animator.StringToHash("isWalk");

    protected override void Start()
    {
        base.Start();
        MoveSpeed = walkSpeed;
    }

    protected override void HandleAbility()
    {
        base.HandleAbility();

        MoveCharacter();
        UpdateAnimations();
   
    }

    // Movimentar agente pela velocidade atual
    private void MoveCharacter()
    {
        float movement = horizontalInput * MoveSpeed;
        _controller.MoveHorizontalCharacter(movement);
        
        if(movement > 0)
        {
            _flip.FaceDirection(1);
        }
        else if(movement < 0)
        {
            _flip.FaceDirection(-1);
        }
        else
        {
            return;
        }
        
    }

    // Update Animation
    private void UpdateAnimations()
    {
        if (Mathf.Abs(horizontalInput) > 0.1f)
        {
            if (_character.CharacterAnimator != null)
            {
                _character.CharacterAnimator.SetBool(walkMoveParamater, true);
            }
        }
        else
        {
            if (_character.CharacterAnimator != null)
            {
                _character.CharacterAnimator.SetBool(walkMoveParamater, false);
            }
        }
    }

    public void ResetSpeed()
    {
        MoveSpeed = walkSpeed;
    }
}
