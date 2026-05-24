using UnityEngine;

public class AgentSounds : AudioPlayer
{
    [SerializeField] private AudioClip hitClip = null, deathClip = null, voiceLineClip = null;

    public void PlayHitSound()
    {
        if (hitClip != null)
        {
            PlayClipWithVariablePitch(hitClip);
        }
    }

    public void PlayDeathSound()
    {
        if (deathClip != null)
        {
            PlayClip(deathClip);
        }
    }

    public void PlayVoiceLineSound()
    {
        if (voiceLineClip != null)
        {
            PlayClipWithVariablePitch(voiceLineClip);
        }
    }
}
