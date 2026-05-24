using UnityEngine;

public class WeaponAudio : AudioPlayer
{
    [SerializeField] private AudioClip shootBulletClip;
    [SerializeField] private AudioClip outOfBulletsClip;

    public void PlayShootSound()
    {
        if (shootBulletClip != null)
        {
            PlayClip(shootBulletClip);
        }
        else
        {
            Debug.LogWarning("Shoot clip is not assigned. Please assign an AudioClip in the inspector.");
        }
    }

    public void PlayOutOfBulletsSound()
    {
        if (outOfBulletsClip != null)
        {
            PlayClip(outOfBulletsClip);
        }
        else
        {
            Debug.LogWarning("Out of bullets clip is not assigned. Please assign an AudioClip in the inspector.");
        }
    }
}
