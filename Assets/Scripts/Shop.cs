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

    private Clicker clicker;
    void Start()
    {
        clicker = FindAnyObjectByType<Clicker>();

        InvokeRepeating("Buy", 0, cookTime);
        PlayerPrefs.GetInt("middleCount", 0);
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
    void Buy()
    {
        var particles = Mathf.Min(middleCount * mpb, 100);
        clickParticles.Emit(particles);
        clicker.clicks += middleCount * mpb;
        UIManager.instance.UpdateClicks(clicker.clicks);
        PlayerPrefs.SetInt("middleCount", 0);
        PlayerPrefs.Save("middleCount", 0);
    }
}
