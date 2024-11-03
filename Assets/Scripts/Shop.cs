using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    [Header("Granny")]
    public ButtonFun middleButton;

    public float middlePrice = 10;

    public int middleCount = 0;

    private Clicker clicker;
    void Start()
    {
        clicker = FindAnyObjectByType<Clicker>();
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
}
