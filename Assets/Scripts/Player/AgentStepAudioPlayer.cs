using UnityEngine;

public class AgentStepAudioPlayer : AudioPlayer
{
    [SerializeField] private AudioClip stepClip;

    public void PlayStepSound()
    {
        if (stepClip != null)
        {
            PlayClipWithVariablePitch(stepClip);
        }
        else
        {
            Debug.LogWarning("Step clip is not assigned. Please assign an AudioClip in the inspector.");
        }
    }
}
