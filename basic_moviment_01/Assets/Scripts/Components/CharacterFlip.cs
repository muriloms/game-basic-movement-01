using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterFlip : CharacterComponents
{
    
    // Returns if our character is facing Right
    public bool FacingRight { get; set; }

    private void Awake()
    {
        FacingRight = true;
    }

    

    // Makes our character face the direction in which is moving
    public void FaceDirection(int newDirection)
    {
        if (newDirection == 1)
        {
            _controller.SetDirectionCharacter(new Vector3(0, 0, 0));
            FacingRight = true;
        }
        else
        {
            _controller.SetDirectionCharacter(new Vector3(0, 180, 0));
            FacingRight = false;
        }
    }
}
