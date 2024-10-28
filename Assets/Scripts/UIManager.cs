using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


public class UIManager : MonoBehaviour
{
    public static UIManager instance;

    public TextMeshProUGUI text;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(instance);
            Debug.LogWarning("There is already an instace of UiManager");
        }
    }

    public void UpdateClicks(int clicks)
    {
        text.text = clicks.ToString("D3");
    }
}
