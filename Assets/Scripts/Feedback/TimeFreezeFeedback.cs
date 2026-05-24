using UnityEngine;

public class TimeFreezeFeedback : Feedback
{
    [SerializeField] float freezeTimeDelay = 0.01f, unFreezeTimeDelay = 0.02f;
    [SerializeField][Range(0, 1)] float timeFreezeValue = 0.2f;

    public override void CompletePreviousFeedback()
    {
        TimeController.Instance.ResetTimeScale();
    }

    public override void CreateFeedback()
    {
        TimeController.Instance.ModifyTimeScale(timeFreezeValue, freezeTimeDelay, () => TimeController.Instance.ModifyTimeScale(1f, unFreezeTimeDelay));
    }
}
