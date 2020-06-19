using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterComponents : MonoBehaviour
{
    // Parametros para movimento
    protected float horizontalInput;

    // Pulo
    protected bool jumpPressed;

    // Dash
    protected bool dashPressed;

    // Componentes
    protected CharacterController _controller;
    protected CharacterMovement _movement;
    protected CharacterJump _jump;
    protected CharacterSensors _sensors;
    protected CharacterFlip _flip;
    protected Animator animator;
    protected Character _character;


    // Start is called before the first frame update
    protected virtual void Start()
    {
        _controller = GetComponent<CharacterController>();
        _character = GetComponent<Character>();
        _movement = GetComponent<CharacterMovement>();
        _jump = GetComponent<CharacterJump>();
        _sensors = GetComponent<CharacterSensors>();
        _flip = GetComponent<CharacterFlip>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        HandleAbility();
    }

    // Método principal -- lógica de cada habilidade
    protected virtual void HandleAbility()
    {
        InternalInput();
        HandleInput();
    }

    /// Input necessario para executar acoes
    protected virtual void HandleInput()
    {

    }

    /// Input principais para controlar o agente - jogador
    protected virtual void InternalInput()
    {
        if (_character.CharacterType == Character.CharacterTypes.Player)
        {
            // Movimento horizontal
            horizontalInput = Input.GetAxisRaw("Horizontal");

            // Pulo
            jumpPressed = Input.GetButtonDown("Jump");

            // Dash
            dashPressed = Input.GetKeyDown(KeyCode.E);

        }
    }
}
