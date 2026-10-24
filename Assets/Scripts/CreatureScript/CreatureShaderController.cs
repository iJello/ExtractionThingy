
using UnityEngine;
using System.Collections;

public class CreatureShaderController : MonoBehaviour
{
    
    public Renderer[] targetRenderers;
    public float fadeInTime = 0.08f;
    public float fadeOutTime = 0.35f;

    private MaterialPropertyBlock propertyBlock;
    private Coroutine flashCoroutine;

    private static readonly int DamageColor = Shader.PropertyToID("_DamageColor");

    private static readonly int FlashAmount = Shader.PropertyToID("_FlashAmount");

    private void Awake()
    {
        propertyBlock = new MaterialPropertyBlock();

        if (targetRenderers == null || targetRenderers.Length == 0)
        {
            targetRenderers = GetComponentsInChildren<Renderer>();
        }
    }

    public void FlashElement(Color elementColor)
    {
        if (flashCoroutine != null)
        {
            StopCoroutine(flashCoroutine);
        }
        flashCoroutine = StartCoroutine(ElementFlash(elementColor));
    }

    private IEnumerator ElementFlash(Color elementColor)
    {
        SetFlashColor(elementColor);

        float time = 0f;

        
        while (time < fadeInTime)
        {
            time += Time.deltaTime;

            float amount = Mathf.SmoothStep(0f, 1f, time / fadeInTime);

            SetFlashAmount(amount);
            yield return null;
        }

        SetFlashAmount(1f);

        
        time = 0f;

        while (time < fadeOutTime)
        {
            time += Time.deltaTime;

            float amount = Mathf.SmoothStep(1f, 0f, time / fadeOutTime);

            SetFlashAmount(amount);
            yield return null;
        }

        SetFlashAmount(0f);
        flashCoroutine = null;
    }

    private void SetFlashColor(Color color)
    {
        foreach (Renderer rend in targetRenderers)
        {
            if (rend == null) continue;

            rend.GetPropertyBlock(propertyBlock);
            propertyBlock.SetColor(DamageColor, color);
            rend.SetPropertyBlock(propertyBlock);
        }
    }

    private void SetFlashAmount(float amount)
    {
        foreach (Renderer rend in targetRenderers)
        {
            if (rend == null) continue;

            rend.GetPropertyBlock(propertyBlock);
            propertyBlock.SetFloat(FlashAmount, amount);
            rend.SetPropertyBlock(propertyBlock);
        }
    }
}
