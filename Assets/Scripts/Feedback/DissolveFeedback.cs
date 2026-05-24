using DG.Tweening;
using UnityEngine;
using UnityEngine.Events;

public class DissolveFeedback : Feedback
{
    [SerializeField] private SpriteRenderer spriteRenderer = null;
    [SerializeField] private float dissolveTime = 0.05f;
    [field: SerializeField] public UnityEvent DeathCallback { get; set; }

    public override void CompletePreviousFeedback()
    {
        spriteRenderer.DOComplete();
        spriteRenderer.material.DOComplete();
    }

    public override void CreateFeedback()
    {
        var sequence = DOTween.Sequence();
        sequence.Append(spriteRenderer.material.DOFloat(0, "_Dissolve", dissolveTime));
        if(DeathCallback != null)
        {
            sequence.AppendCallback(() => DeathCallback.Invoke());
        }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
