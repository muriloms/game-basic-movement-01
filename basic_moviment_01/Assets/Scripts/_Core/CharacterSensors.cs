using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSensors : MonoBehaviour
{
    [Header("Ground Sensors")]
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private Vector3 groundOffSet = new Vector3(0,-0.8f,0);
    [SerializeField] private float groundRadius = 0.25f;


    // Controle Sensores
    public bool OnGround { get; set; }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        OnGround = CheckOnGround();
    }

    
    // Chegar posicao do agente em relacao ao solo
    private bool CheckOnGround()
    {
        bool checkOnGround = Physics2D.OverlapCircle(transform.position + new Vector3(0, groundOffSet.y), groundRadius, groundLayer);

        return checkOnGround;
    }

    // Visualizar Check On Ground
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position + new Vector3(0, groundOffSet.y), groundRadius);
    }
}
