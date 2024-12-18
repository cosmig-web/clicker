using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;
using UnityEngine.SocialPlatforms.Impl;

public class Clicker : MonoBehaviour
{
    [Header("Animation settings")]
    public float scale = 1.2f;
    public float duration = 0.1f;
    public Ease ease;
    [Header("Sound")]
    private new AudioSource audio;
    [Header("Particles")]
    public ParticleSystem clickParticles;
    public AudioClip clip;
    [Header("Cps")]
    public TextMeshProUGUI cps;
    private int click = 0;

    [Header("Settings")]
    public int clickValue = 1;
    public List<GameObject> updates;
    [HideInInspector] public int updateIdex = 0; 

    [HideInInspector]public int clicks = 0;
    public TextMeshProUGUI clickCount;

    void Start()
    {
        audio = GetComponent<AudioSource>();
        InvokeRepeating("Click", 0, 1);
        clicks = PlayerPrefs.GetInt("clicks", 0);
        clickValue = PlayerPrefs.GetInt("clickValue", 1);
        updateIdex = PlayerPrefs.GetInt("updateIdex", 0);
        UpdateCookie();

    }

    private void OnMouseDown()
    {
        clickParticles.Emit(1);

        clicks += clickValue;
        UIManager.instance.UpdateClicks(clicks);
        
        transform.DOScale(1, duration).ChangeStartValue(scale * Vector3.one).SetEase(ease);
        audio.pitch = Random.Range(2.8f, 3);
        audio.PlayOneShot(clip);
        click++;
        

    }
    private void OnApplicationPause(bool pause)
    {
        if (pause)
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
        PlayerPrefs.SetInt("clicks", clicks);
        PlayerPrefs.SetInt("clickValue", clickValue);
        PlayerPrefs.SetInt("updateIdex", updateIdex);
        PlayerPrefs.Save();
    }
    private void Click()
    {
        cps.text = $"cps: {click}";
        click = 0;
    }

    public void UpdateCookie()
    {
        clickValue++;
        updates[updateIdex].SetActive(false);
        updateIdex++;
        updates[updateIdex].SetActive(true);
    }
}
