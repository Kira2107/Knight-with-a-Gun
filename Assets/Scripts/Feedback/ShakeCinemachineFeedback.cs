using UnityEngine;
using Unity.Cinemachine;
using System.Collections;

public class ShakeCinemachineFeedback : Feedback
{
    [SerializeField] private CinemachineCamera cinemachineCamera = null;
    [SerializeField][Range(0f, 5f)] private float amplitude = 1f, intensity = 1f;
    [SerializeField][Range(0f, 1f)] private float duration = 0.1f;
    private CinemachineBasicMultiChannelPerlin noise;

    void Start()
    {
        if (cinemachineCamera != null)
        {
            cinemachineCamera = FindAnyObjectByType<CinemachineCamera>();
        }
        noise = cinemachineCamera.GetComponent<CinemachineBasicMultiChannelPerlin>();
    }

    public override void CompletePreviousFeedback()
    {
        StopAllCoroutines();
        noise.AmplitudeGain = 0f;
    }

    public override void CreateFeedback()
    {
        noise.AmplitudeGain = amplitude;
        noise.FrequencyGain = intensity;
        StartCoroutine(ShakeCoroutine());
    }

    IEnumerator ShakeCoroutine()
    {
        for(float i = duration; i > 0; i -= Time.deltaTime)
        {
            noise.AmplitudeGain = Mathf.Lerp(0, amplitude, i / duration);
            yield return null;
        }

        noise.AmplitudeGain = 0;
    }
}
