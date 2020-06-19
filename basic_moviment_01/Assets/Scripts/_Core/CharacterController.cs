using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    // Controlar movimento atual do agente
    public Vector2 CurrentMovement { get; set; }
    public float CurrentMoveHorizontal { get; set; }
    public float CurrentMoveVertical { get; set; }

    // Controlar direcao 
    public Vector3 DirectionComponent { get; set; }

    // Paramentros internos
    private Rigidbody2D myRigidbody2D;
    

    // Start is called before the first frame update
    private void Start()
    {
        myRigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        DirectionCharacter();
    }


    // Movimento horizontal
    public void MoveHorizontalCharacter(float CurrentMoveHorizontal)
    {
        Vector2 movimentHorizontal = new Vector2(CurrentMoveHorizontal, myRigidbody2D.velocity.y);
        myRigidbody2D.velocity = movimentHorizontal;
        
    }
        

    // Movimento vertical
    public void MoveVerticalCharacter(float CurrentMoveVertical)
    {
        Vector2 movimentVertical = new Vector2(myRigidbody2D.velocity.x, CurrentMoveVertical);
        myRigidbody2D.velocity = movimentVertical;
    }


    // Direcao do agente
    private void DirectionCharacter()
    {
        myRigidbody2D.transform.eulerAngles = DirectionComponent;
    }

    // Definir nova direcao
    public void SetDirectionCharacter(Vector3 newDirection)
    {
        DirectionComponent = newDirection;
    }
    


}
