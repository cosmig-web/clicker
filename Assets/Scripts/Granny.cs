using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class Granny : MonoBehaviour
{
    public TextMeshProUGUI middleCount;
    public TextMeshProUGUI clicks;
    void Update()
    {
        if (float.Parse(middleCount.text) > 0)
        {
            InvokeRepeating("MiddleScooler()", 2, float.Parse(middleCount.text));
        }
        
    }
    private void Start()
    {
        
    }

    public void MiddleSchooler()
    {
        clicks.text += (1).ToString();
    }
}
