using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemWater : UsableItem
{
    public override void UseItem()
    {
        CharacterStats.Instance.currentStamina += 5;        
    }
}
