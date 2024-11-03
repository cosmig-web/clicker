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
    [Header("Sound")]
    private AudioSource audio;
    public AudioClip clip;

    [HideInInspector]public int clicks = 0;
    public TextMeshProUGUI clickCount;

    void Start()
    {
        audio = GetComponent<AudioSource>();
    }

    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        clicks++;
        UIManager.instance.UpdateClicks(clicks);
        transform.DOScale(1, duration).ChangeStartValue(scale * Vector3.one).SetEase(ease);
        audio.pitch = Random.Range(2.8f, 3);
        audio.PlayOneShot(clip);


    }
}
