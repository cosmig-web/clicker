using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;

public class Clicker : MonoBehaviour
{
    [Header("Animation settings")]
    public float scale = 1.2f;
    public float duration = 0.1f;
    public Ease ease;
    public new AudioSource audio;

    private int clicks = 0;
    public TextMeshProUGUI clickCount;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        clicks++;
        UIManager.instance.UpdateClicks(clicks);
        transform.DOScale(1, duration).ChangeStartValue(scale * Vector3.one).SetEase(ease);


    }
}
