using System;
using System.Collections;
using UnityEngine;

public class TimeController : MonoBehaviour
{
    public static TimeController Instance { get; private set; }

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void ResetTimeScale()
    {
        StopAllCoroutines();
        Time.timeScale = 1f;
    }

    public void ModifyTimeScale(float endTimeScale, float timeToWait, Action OnCompleteCallback = null)
    {
        StartCoroutine(TimeScaleCoroutine(endTimeScale, timeToWait, OnCompleteCallback));
    }

    IEnumerator TimeScaleCoroutine(float endTimeScale, float timeToWait, Action OnCompleteCallback)
    {
        yield return new WaitForSecondsRealtime(timeToWait);

        Time.timeScale = endTimeScale;
        OnCompleteCallback?.Invoke();

    }
}
