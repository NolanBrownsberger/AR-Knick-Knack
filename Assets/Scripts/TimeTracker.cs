using UnityEngine;
using TMPro;
using System;

public class TimeAPI : MonoBehaviour
{
    // Time Display and Lighting
    public GameObject timeTextObject;
    public Light sunLight;
    public Light tentLight;
    private int timeOffset = -2;

    // Ambient Sound
    public AudioSource audioSource;
    public AudioClip dayClip;
    public AudioClip nightClip;
    private bool isNight = false;

    void Start()
    {
        PlayAmbient();

        // Update immediately, then every 60 seconds
        UpdateTimeAndSun();
        InvokeRepeating("UpdateTimeAndSun", 60f, 60f);
    }

    void UpdateTimeAndSun()
    {
        // subtract 2 hours
        System.DateTime adjustedTime = System.DateTime.Now.AddHours(timeOffset);

        int currenthour = adjustedTime.Hour;

        // tent light
        if (currenthour >= 20 || currenthour < 4)
        {
            tentLight.intensity = .05f;
        }
        else
        {
            tentLight.intensity = 0f;
        }

        // Time Display
        string currentTime = adjustedTime.ToString("hh:mm tt");
        timeTextObject.GetComponent<TextMeshPro>().text = currentTime;

        // Sun Rotation
        float hour = adjustedTime.Hour + adjustedTime.Minute / 60f;
        float sunAngle = (hour / 24f) * 360f - 90f;
        sunLight.transform.rotation = Quaternion.Euler(sunAngle, 170f, 0f);

        // Ambient Audio
        UpdateAmbientSound(currenthour);
    }

    void UpdateAmbientSound(int currentHour)
    {
        if (audioSource == null) return;

        bool nightTime = (currentHour >= 20 || currentHour < 6);

        if (nightTime != isNight)
        {
            isNight = nightTime;
            PlayAmbient();
        }
    }

    void PlayAmbient()
    {
        if (audioSource == null) return;

        audioSource.Stop();
        audioSource.clip = isNight ? nightClip : dayClip;
        audioSource.loop = true;
        audioSource.Play();
    }
}