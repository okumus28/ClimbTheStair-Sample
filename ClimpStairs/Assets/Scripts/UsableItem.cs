using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public abstract class UsableItem : MonoBehaviour
{
    [SerializeField] int maxValue;
    public int currentValue;

    [SerializeField] Slider valueSlider;
    [SerializeField] TextMeshProUGUI valueText;
    [SerializeField] Button useButton;

    public abstract void UseItem();

    private void OnEnable()
    {
        CharacterStats.ClimbCount += GetClimbingStairsCount;
        currentValue = PlayerPrefs.GetInt("CurrentValue" + name);

        valueSlider.value = currentValue;
        valueText.text = currentValue.ToString() + "/" + maxValue.ToString();

        useButton.onClick.AddListener(UseButton);
    }
    private void OnDisable()
    {
        CharacterStats.ClimbCount -= GetClimbingStairsCount;
        useButton.onClick.RemoveAllListeners();
    }

    void GetClimbingStairsCount()
    {
        currentValue++;
        valueSlider.value = currentValue;
        valueText.text = currentValue.ToString() + "/" + maxValue.ToString();
        PlayerPrefs.SetInt("CurrentValue" + name , currentValue);

        if (currentValue >= maxValue)
        {
            useButton.gameObject.SetActive(true);
            valueSlider.gameObject.SetActive(false);
        }
        else
        {
            useButton.gameObject.SetActive(false);
            valueSlider.gameObject.SetActive(true);
        }
    }
    public void UseButton()
    {
        currentValue = 0;
        UseItem();
    }
}
