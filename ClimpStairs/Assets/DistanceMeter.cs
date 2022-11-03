using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DistanceMeter : MonoBehaviour
{
    public TextMeshProUGUI distanceText;

    private void Start()
    {
        CharacterStats.PositionY += DistanceTextUpdate;
    }

    public void DistanceTextUpdate(float distance)
    {
        distanceText.text = distance.ToString("n1") + "m";
    }
}
