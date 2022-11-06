using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIController : MonoSingleton<UIController>
{
    [SerializeField] TextMeshProUGUI cashText;
    public bool canRun;
    public GameObject GameOverPanel;
    void OnEnable()
    {
        CharacterStats.CurrentCash += GetCash;
    }
    void OnDisable()
    {
        CharacterStats.CurrentCash -= GetCash;
    }

    void GetCash(float value)
    {
        cashText.text = ((int)value).ToString();
    }

    public void ChangeCanRun(bool value)
    {
        canRun = value;
    }

    public void RestartButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
