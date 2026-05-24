using DG.Tweening;
using UnityEngine;

public class ShakeFeedback : Feedback
{
    [SerializeField] private GameObject objectToShake = null;
    [SerializeField] private float duration = 0.5f, strength = 1f, randomness = 90f;
    [SerializeField] private int vibrato = 10;
    [SerializeField] private bool snapping = false;
    [SerializeField] private bool fadeOut = true;
    public override void CompletePreviousFeedback()
    {
        objectToShake.transform.DOComplete();
    }

    public override void CreateFeedback()
    {
        CompletePreviousFeedback();
        objectToShake.transform.DOShakePosition(duration, strength, vibrato, randomness, snapping, fadeOut);
    }
}
