using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class WeaponRenderer : MonoBehaviour
{
    [SerializeField] protected int playerSortingOrder = 0;
    protected SpriteRenderer spriteRenderer;

    protected virtual void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void FlipSprite(bool val)
    {
        int flipModifier = val ? -1 : 1;
        transform.localScale = new Vector3(transform.localScale.x, flipModifier*Mathf.Abs(transform.localScale.y),     transform.localScale.z);
    }

    public void RenderBehindHead(bool val)
    {
        if(val)
        {
            spriteRenderer.sortingOrder = playerSortingOrder - 1;
        }
        else
        {
            spriteRenderer.sortingOrder = playerSortingOrder + 1;
        }
    }
}
