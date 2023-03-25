using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeScaleController : MonoBehaviour
{
    public float TimeScale { get => currentTimeScale; }

    private List<float> timeScales = new List<float>();
    private float currentTimeScale = 1f;

    private void Start()
    {
        timeScales.Add(0f);
        timeScales.Add(1f);
        timeScales.Add(2f);
        timeScales.Add(3f);
    }

    public void SetupTimeScale(float scale)
    {
        if (timeScales.Contains(scale))
            ChangeTimeScale(scale);
    }

    private void ChangeTimeScale(float scale)
    {
        currentTimeScale = scale;
        Time.timeScale = currentTimeScale;
    }
}
