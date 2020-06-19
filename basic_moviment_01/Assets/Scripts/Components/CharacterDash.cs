using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterDash : CharacterComponents
{
    public enum DashState
    {
        Ready,
        Dashing,
        Cooldown
    }

    [Header("Settings")]
    [SerializeField] private float speedDash = 4f;
    [SerializeField] private float dashTimer;
    [SerializeField] private float maxDash = 2f;

    // Parametros internos
    private Vector2 savedVelocity;
    private DashState dashState;
    
    private readonly int dashMoveParamater = Animator.StringToHash("isDash");


    protected override void HandleAbility()
    {
        base.HandleAbility();

        UpdateAnimations();

        // Definir possibilidade de executar o Dash
        switch (dashState)
        {
            case DashState.Ready:
                if (dashPressed)
                {
                    Dash();
                    
                    dashState = DashState.Dashing;
                }
                break;
            case DashState.Dashing:
                dashTimer += Time.deltaTime * 3;
                if (dashTimer >= maxDash)
                {
                    dashTimer = maxDash;
                    StopDash();
                    dashState = DashState.Cooldown;
                }
                break;
            case DashState.Cooldown:
                dashTimer -= Time.deltaTime;
                if (dashTimer <= 0)
                {
                    dashTimer = 0;
                    dashState = DashState.Ready;
                }
                break;
        }
    }

    // Acao do Dash
    private void Dash()
    {
        _movement.MoveSpeed = _movement.MoveSpeed * speedDash;
    }

    // Parar dash
    private void StopDash()
    {
        _movement.ResetSpeed();
    }

    // Update Animation
    private void UpdateAnimations()
    {
        if (dashPressed)
        {
            if (_character.CharacterAnimator != null)
            {
                _character.CharacterAnimator.SetTrigger(dashMoveParamater);
            }
        }

    }
}

