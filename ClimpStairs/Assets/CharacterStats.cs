using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStats : MonoSingleton<CharacterStats>
{
    public static event Action<float> PositionY;

    public void Distance()
    {
        PositionY?.Invoke(transform.position.y);
    }
}
