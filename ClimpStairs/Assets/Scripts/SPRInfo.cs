using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SPRInfo : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI levelUpPriceText;
    [SerializeField] TextMeshProUGUI levelText;
    [SerializeField] Button levelUpButton;

    int currentLevel;
    int currentLevelPrice;
    public float currentLevelValue;

    [SerializeField] int defLevelPrice;
    [SerializeField] float defaultValue;
    [SerializeField] float plusValue;

    void OnEnable()
    {
        CharacterStats.CurrentCash += GetCash;

        currentLevel = PlayerPrefs.GetInt("CurrentLevel"+ name);
        //levelUpButton.onClick.RemoveAllListeners();
        //levelUpButton.onClick.AddListener(() => LevelUpButton());

        Control();
    }

    void OnDisable()
    {
        CharacterStats.CurrentCash -= GetCash;
    }

    public void LevelUpButton()
    {
        currentLevel++;
        PlayerPrefs.SetInt("CurrentLevel" + name, currentLevel);

        Control();
        CharacterStats.Instance.Cash -= currentLevelPrice;
    }

    void Control()
    {
        levelText.text = "LVL " + currentLevel;

        currentLevelPrice = currentLevel * defLevelPrice + (int)Mathf.Pow(currentLevel, 2.5f);
        levelUpPriceText.text = currentLevelPrice.ToString();

        currentLevelValue = defaultValue + currentLevel * plusValue;
    }

    void GetCash(float value)
    {
        levelUpButton.interactable = currentLevelPrice < value;
    }
}
