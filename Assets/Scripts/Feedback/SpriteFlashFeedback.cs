using System.Collections;
using UnityEngine;

public class SpriteFlashFeedback : Feedback
{
    [SerializeField] private SpriteRenderer spriteRenderer = null;
    [SerializeField] private float flashTime = 0.1f;
    [SerializeField] private Material flashMaterial = null;

    private Shader originalMaterialShader;

    void Start()
    {
        if (spriteRenderer == null)
        {
            spriteRenderer = GetComponent<SpriteRenderer>();
        }

        if (spriteRenderer != null)
        {
            originalMaterialShader = spriteRenderer.material.shader;
        }
    }
    public override void CompletePreviousFeedback()
    {
        StopAllCoroutines();
        spriteRenderer.material.shader = originalMaterialShader;
    }

    public override void CreateFeedback()
    {
        if (!spriteRenderer.material.HasProperty("_MakeSolidColor"))
        {
            spriteRenderer.material.shader = flashMaterial.shader;
        }
        spriteRenderer.material.SetInt("_MakeSolidColor", 1);
        StartCoroutine(WaitBeforeChangingBack());
    }

    private IEnumerator WaitBeforeChangingBack()
    {
        yield return new WaitForSeconds(flashTime);
        if (spriteRenderer.material.HasProperty("_MakeSolidColor"))
        {
            spriteRenderer.material.SetInt("_MakeSolidColor", 0);
        }
        else
        {
            spriteRenderer.material.shader = originalMaterialShader;
        }
    }
}
