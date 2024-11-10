using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    [Header("Granny")]
    public ButtonFun middleButton;

    public float middlePrice = 10;

    public int middleCount = 0;

    public int mpb = 1;

    public float cookTime = 1;

    [Header("Particles")]
    public ParticleSystem clickParticles;

    [Header("Upgrades")]
    public ButtonFun upgrade;
    public float upgradePrice = 100;
    public int upgradeCount = 0;

    private Clicker clicker;
    void Start()
    {
        clicker = FindAnyObjectByType<Clicker>();

        InvokeRepeating("Buy", 0, cookTime);
        middleCount = PlayerPrefs.GetInt("middleCount", 0);
        middlePrice = PlayerPrefs.GetInt("middlePrice", 10);
        upgradeCount = PlayerPrefs.GetInt("upgradeCount", 0);
        upgradeCount = PlayerPrefs.GetInt("upgradeCount", 100);
        middleButton.UpdateText((int)Mathf.Ceil(middlePrice),middleCount);
        
    }


    public void BuyMiddleSchoolers()
    {
        if (clicker.clicks >= middlePrice)
        {
            clicker.clicks -= (int)Mathf.Ceil(middlePrice);
            UIManager.instance.UpdateClicks(clicker.clicks);

            middleCount++;
            middlePrice = middlePrice * 1.1f;
            middleButton.UpdateText((int)Mathf.Ceil(middlePrice), middleCount);
        }
    }

    public void BuyUpgrade()
    {

        if (clicker.clicks >= upgradePrice)
        {
            clicker.clicks -= (int)Mathf.Ceil(upgradePrice);
            UIManager.instance.UpdateClicks(clicker.clicks);

            
            upgradePrice = upgradePrice * 2f;
            upgradeCount++;
            upgrade.UpdateText((int)Mathf.Ceil(upgradePrice), upgradeCount);

            clicker.UpdateCookie();
        }
        if(upgradeCount == 6)
        {
            upgrade.enabled = false;
        }
    }
    void Buy()
    {
        var particles = Mathf.Min(middleCount * mpb, 100);
        clickParticles.Emit(particles);
        clicker.clicks += middleCount * mpb;
        UIManager.instance.UpdateClicks(clicker.clicks);
        
        
    }
    private void OnApplicationPause(bool pause)
    {
        if(pause)
        {
            Save();
        }
    }
    private void OnApplicationQuit()
    {
        Save();
    }
    public void Save()
    {
        PlayerPrefs.SetInt("middleCount", middleCount);
        PlayerPrefs.SetInt("middlePrice", (int)middlePrice);
        PlayerPrefs.SetInt("upgradeCount", upgradeCount);
        PlayerPrefs.SetInt("upgradePrice", (int)upgradePrice);
        PlayerPrefs.Save();
    }
    
}
