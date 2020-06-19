using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : Singleton<LevelManager>
{
    [SerializeField] private Character playableCharacter;

    private void Awake()
    {
        Camera2D.Instance.Target = playableCharacter.transform;
    }
}
