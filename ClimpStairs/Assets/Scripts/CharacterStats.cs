using System;
using UnityEngine;

public class CharacterStats : MonoSingleton<CharacterStats>
{
    public static event Action<float> PositionY;
    public static event Action<float> CurrentCash;

    [SerializeField] GameObject diedParticles;
    [SerializeField] ParticleSystem sparkParticles;
    [SerializeField] Material mat;
    [SerializeField] private float _cash;
    public float Cash 
    { 
        get { return _cash; }
        set 
        { 
            _cash = value;
            PlayerPrefs.SetFloat("PlayerCash" , _cash);
            GetCash();
        }
    }

    public float currentStamina;

    public float Stamina 
    {
        get { return stamina.currentLevelValue; }
    }
    public float Income
    {
        get{ return income.currentLevelValue; }
    }
    public float Speed
    {
        get { return speed.currentLevelValue; }
    }

    public SPRInfo stamina;
    public SPRInfo income;
    public SPRInfo speed;
    
    void Start()
    {
        Cash = PlayerPrefs.GetFloat("PlayerCash");
        currentStamina = Stamina;
        sparkParticles.Stop();
        mat.color = new Color(1,1,1);
    }

    public void Distance()
    {
        PositionY?.Invoke(transform.position.y);
        currentStamina -= 0.2f;
        if (currentStamina <= 0) GameOver();
        ColorUpdate();        
    }

    public void GetCash()
    {
        CurrentCash?.Invoke(_cash);
    }

    void GameOver()
    {
        gameObject.SetActive(false);
        GameObject go = Instantiate(diedParticles, transform.position , Quaternion.identity);
        Destroy(go, .75f);

        UIController.Instance.canRun = false;
        UIController.Instance.GameOverPanel.SetActive(true);
    }

    void ColorUpdate()
    {
        if (currentStamina <= Stamina * 0.2f)
        {
            if (!sparkParticles.isPlaying) sparkParticles.Play();
            float colorValue = (currentStamina / (Stamina * 0.2f));
            mat.color = new Color(1, colorValue, colorValue);
        }
        else
        {
            sparkParticles.Stop();
            mat.color = new Color(1,1,1);
        }
    }

    public void StaminaRegenaration()
    {
        if (currentStamina <= Stamina * 0.2f)
        {
            currentStamina += 0.5f * Time.deltaTime;
            ColorUpdate();
        }
    }
}
