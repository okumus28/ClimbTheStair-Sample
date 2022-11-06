using TMPro;
using UnityEngine;

public class DistanceMeter : MonoBehaviour
{
    public TextMeshProUGUI distanceText;

    private void OnEnable()
    {
        CharacterStats.PositionY += DistanceTextUpdate;
    }
    void OnDisable()
    {
        CharacterStats.PositionY -= DistanceTextUpdate;
    }

    public void DistanceTextUpdate(float distance)
    {
        distanceText.text = distance.ToString("n1") + "m";
    }

}
